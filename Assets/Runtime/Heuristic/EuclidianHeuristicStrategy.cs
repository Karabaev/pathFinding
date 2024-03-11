using System;
using UnityEngine;

namespace com.karabaev.pathFinding.Heuristic
{
  public class EuclidianHeuristicStrategy : IPathFindingHeuristicStrategy
  {
    public float Calculate(Vector2Int start, Vector2Int end)
    {
      return MathF.Sqrt(MathF.Pow(end.x - start.x, 2) + MathF.Pow(end.y - start.y, 2));
    }
  }
}