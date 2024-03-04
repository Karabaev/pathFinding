﻿using System.Collections.Generic;
using com.karabaev.pathFinding.Collections;
using com.karabaev.pathFinding.Heuristic;
using UnityEngine;

namespace com.karabaev.pathFinding.AStar
{
  public class AStarPathFindingService : IPathFindingService
  {
    private const float StraightCost = 1.0f;
    private const float DiagonalCost = 1.41421356237f;

    public Stack<Vector3> FindPath(Vector3 origin, Vector3 destination, WalkingMap.WalkingMap walkingMap,
      IPathFindingHeuristicStrategy heuristicStrategy)
    {
      var startNode = new AStarNode(origin, 0, heuristicStrategy.Calculate(origin, destination));

      var open = new BinaryHeap<Vector3, AStarNode>(n => n.Position);
      var closed = new HashSet<Vector3>();
      var links = new Dictionary<Vector3, Vector3>();

      open.Enqueue(startNode);

      while(open.Count > 0)
      {
        var currentNode = open.Dequeue();
        closed.Add(currentNode.Position);

        if(currentNode.Position == destination)
          return BuildPath(origin, destination, links);

        foreach(var neighborMapNode in walkingMap[currentNode.Position].Neighbours)
        {
          if(!neighborMapNode.Walkable)
            continue;

          if(closed.Contains(neighborMapNode.Position))
            continue;

          var traversedDistance = currentNode.TraversedDistance + CalculateCost(currentNode.Position, neighborMapNode.Position, walkingMap);
          var estimatedTotalCost = traversedDistance + heuristicStrategy.Calculate(neighborMapNode.Position, destination);
          var neighborNode = new AStarNode(neighborMapNode.Position, traversedDistance, estimatedTotalCost);

          if(!open.TryGet(neighborMapNode.Position, out var openNode))
          {
            open.Enqueue(neighborNode);
            links[neighborNode.Position] = currentNode.Position;
            continue;
          }

          if(neighborNode.TraversedDistance >= openNode!.Value.TraversedDistance)
            continue;

          open.Modify(neighborNode);
          links[neighborNode.Position] = currentNode.Position;
        }
      }

      return BuildPath(origin, destination, links);
    }

    private float CalculateCost(Vector3 source, Vector3 next, WalkingMap.WalkingMap walkingMap)
    {
      var matches = 0;
      for(var i = 0; i < 3; i++)
      {
        var sourceValue = source[i];
        var nextValue = next[i];
        
        if(sourceValue == nextValue)
          matches++;
      }

      var cost = matches >= 2 ? StraightCost : DiagonalCost;
      return cost * walkingMap[next].CostMultiplier;
    }

    private Stack<Vector3> BuildPath(Vector3 origin, Vector3 destination, Dictionary<Vector3, Vector3> links)
    {
      var path = new Stack<Vector3>();

      if(!links.ContainsKey(destination))
        return path;

      var current = destination;

      while(current != origin)
      {
        path.Push(current);
        current = links[current];
      }

      return path;
    }
  }
}