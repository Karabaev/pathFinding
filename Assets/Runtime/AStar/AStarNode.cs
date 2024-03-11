using System;
using UnityEngine;

namespace com.karabaev.pathFinding.AStar
{
  public readonly struct AStarNode : IComparable<AStarNode>
  {
    public Vector2Int Position { get; }

    /// <summary>
    /// Расстояние от начала пути до ноды. G
    /// </summary>
    public float TraversedDistance { get; }

    /// <summary>
    /// Ориентировочное расстояние от начала до конца пути. F
    /// </summary>
    public float EstimatedTotalCost { get; }

    public override bool Equals(object? obj)
    {
      return obj is AStarNode other && Equals(other);
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(Position, TraversedDistance, EstimatedTotalCost);
    }

    public bool Equals(AStarNode other)
    {
      return Position == other.Position && TraversedDistance == other.TraversedDistance && EstimatedTotalCost == other.EstimatedTotalCost;
    }

    public int CompareTo(AStarNode other)
    {
      return EstimatedTotalCost.CompareTo(other.EstimatedTotalCost);
    }

    public override string ToString()
    {
      return Position.ToString();
    }

    public AStarNode(Vector2Int position, float traversedDistance, float estimatedTotalCost)
    {
      Position = position;
      TraversedDistance = traversedDistance;
      EstimatedTotalCost = estimatedTotalCost;
    }
  }
}