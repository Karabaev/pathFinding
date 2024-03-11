using System.Linq;
using com.karabaev.pathFinding;
using com.karabaev.pathFinding.AStar;
using com.karabaev.pathFinding.Heuristic;
using com.karabaev.pathFinding.WalkingMap;
using NUnit.Framework;
using UnityEngine;

namespace com.karabaev.pathfinding.tests
{
  public class AStarManhattanPathFindingTests
  {
    private readonly IPathFindingService _pathFindingService = new AStarPathFindingService();
    private readonly IPathFindingHeuristicStrategy _heuristicStrategy = new ManhattanHeuristicStrategy();

    [Test]
    public void OriginNowContainsAndDestinationContainsInPathTest()
    {
      var walkingMap = new WalkingMap(new[]
      {
        new MapNode(new Vector2Int(0, 0), MapNodeType.Free),
        new MapNode(new Vector2Int(1, 0), MapNodeType.Free),
        new MapNode(new Vector2Int(2, 0), MapNodeType.Free),
        new MapNode(new Vector2Int(0, 1), MapNodeType.Free),
        new MapNode(new Vector2Int(1, 1), MapNodeType.Free),
        new MapNode(new Vector2Int(2, 1), MapNodeType.Free),
        new MapNode(new Vector2Int(0, 2), MapNodeType.Free),
        new MapNode(new Vector2Int(1, 2), MapNodeType.Free),
        new MapNode(new Vector2Int(2, 2), MapNodeType.Free),
      });

      var origin = Vector2Int.zero;
      var destination = new Vector2Int(1, 1);
      var path = _pathFindingService.FindPath(origin, destination, walkingMap, _heuristicStrategy);

      Assert.That(!path.Contains(origin));
      Assert.That(path.Contains(destination));
      Assert.That(path, Has.Count.EqualTo(2));
    }

    [Test]
    public void FreeLocationTest()
    {
      var nodes = new MapNode[]
      {
        new(new (0, 0), MapNodeType.Free),
        new(new (1, 0), MapNodeType.Free),
        new(new (2, 0), MapNodeType.Free),
        new(new (3, 0), MapNodeType.Free),
        new(new (4, 0), MapNodeType.Free),
      
        new(new (0, 1), MapNodeType.Free),
        new(new (1, 1), MapNodeType.Free),
        new(new (2, 1), MapNodeType.Free),
        new(new (3, 1), MapNodeType.Free),
        new(new (4, 1), MapNodeType.Free),
      
        new(new (0, 2), MapNodeType.Free),
        new(new (1, 2), MapNodeType.Free),
        new(new (2, 2), MapNodeType.Free),
        new(new (3, 2), MapNodeType.Free),
        new(new (4, 2), MapNodeType.Free),
      
        new(new (0, 3), MapNodeType.Free),
        new(new (1, 3), MapNodeType.Free),
        new(new (2, 3), MapNodeType.Free),
        new(new (3, 3), MapNodeType.Free),
        new(new (4, 3), MapNodeType.Free),
      
        new(new (0, 4), MapNodeType.Free),
        new(new (1, 4), MapNodeType.Free),
        new(new (2, 4), MapNodeType.Free),
        new(new (3, 4), MapNodeType.Free),
        new(new (4, 4), MapNodeType.Free),
      
        new(new (0, 5), MapNodeType.Free),
        new(new (1, 5), MapNodeType.Free),
        new(new (2, 5), MapNodeType.Free),
        new(new (3, 5), MapNodeType.Free),
        new(new (4, 5), MapNodeType.Free)
      };
    
      var walkingMap = new WalkingMap(nodes);

      var destinationX = nodes.Max(n => n.Position.x);
      var destinationY = nodes.Max(n => n.Position.y);
      var destination = new Vector2Int(destinationX, destinationY);
      var path = _pathFindingService.FindPath(Vector2Int.zero, destination, walkingMap, _heuristicStrategy);
      Assert.That(path, Has.Count.EqualTo(9));
    }

    [Test]
    public void LocationWithObstaclesTest()
    {
      var nodes = new MapNode[]
      {
        new(new (0, 5), MapNodeType.Free), new(new (1, 5), MapNodeType.Free), new(new (2, 5), MapNodeType.Free), new(new (3, 5), MapNodeType.Free), new(new (4, 5), MapNodeType.Free),
        new(new (0, 4), MapNodeType.Free), new(new (1, 4), MapNodeType.Impassable), new(new (2, 4), MapNodeType.Free), new(new (3, 4), MapNodeType.Impassable), new(new (4, 4), MapNodeType.Free),
        new(new (0, 3), MapNodeType.Free), new(new (1, 3), MapNodeType.Impassable), new(new (2, 3), MapNodeType.Free), new(new (3, 3), MapNodeType.Impassable), new(new (4, 3), MapNodeType.Free),
        new(new (0, 2), MapNodeType.Free), new(new (1, 2), MapNodeType.Impassable), new(new (2, 2), MapNodeType.Free), new(new (3, 2), MapNodeType.Impassable), new(new (4, 2), MapNodeType.Free),
        new(new (0, 1), MapNodeType.Impassable), new(new (1, 1), MapNodeType.Impassable), new(new (2, 1), MapNodeType.Impassable), new(new (3, 1), MapNodeType.Impassable), new(new (4, 1), MapNodeType.Free),
        new(new (0, 0), MapNodeType.Free), new(new (1, 0), MapNodeType.Free), new(new (2, 0), MapNodeType.Free), new(new (3, 0), MapNodeType.Free), new(new (4, 0), MapNodeType.Free),
      };
    
      var walkingMap = new WalkingMap(nodes);
      var path = _pathFindingService.FindPath(Vector2Int.zero, new Vector2Int(2, 2), walkingMap, _heuristicStrategy);

      Assert.That(path, Has.Count.EqualTo(14));
    }

    [Test]
    public void NotReachablePointTest()
    {
      var nodes = new MapNode[]
      {
        new(new (0, 5), MapNodeType.Free), new(new (1, 5), MapNodeType.Free), new(new (2, 5), MapNodeType.Free), new(new (3, 5), MapNodeType.Free), new(new (4, 5), MapNodeType.Free),
        new(new (0, 4), MapNodeType.Free), new(new (1, 4), MapNodeType.Impassable), new(new (2, 4), MapNodeType.Impassable), new(new (3, 4), MapNodeType.Impassable), new(new (4, 4), MapNodeType.Free),
        new(new (0, 3), MapNodeType.Free), new(new (1, 3), MapNodeType.Impassable), new(new (2, 3), MapNodeType.Free), new(new (3, 3), MapNodeType.Impassable), new(new (4, 3), MapNodeType.Free),
        new(new (0, 2), MapNodeType.Free), new(new (1, 2), MapNodeType.Impassable), new(new (2, 2), MapNodeType.Free), new(new (3, 2), MapNodeType.Impassable), new(new (4, 2), MapNodeType.Free),
        new(new (0, 1), MapNodeType.Impassable), new(new (1, 1), MapNodeType.Impassable), new(new (2, 1), MapNodeType.Impassable), new(new (3, 1), MapNodeType.Impassable), new(new (4, 1), MapNodeType.Free),
        new(new (0, 0), MapNodeType.Free), new(new (1, 0), MapNodeType.Free), new(new (2, 0), MapNodeType.Free), new(new (3, 0), MapNodeType.Free), new(new (4, 0), MapNodeType.Free),
      };
    
      var walkingMap = new WalkingMap(nodes);
      var path = _pathFindingService.FindPath(Vector2Int.zero, new Vector2Int(2, 2), walkingMap, _heuristicStrategy);

      Assert.That(path, Has.Count.EqualTo(0));
    }
  }
}