using System;
using UnityEngine;

namespace com.karabaev.pathFinding.Heuristic
{
  public class ManhattanHeuristicStrategy : IPathFindingHeuristicStrategy
  {
    public float Calculate(Vector2Int start, Vector2Int end)
    {
      return MathF.Abs(end.x - start.x) + MathF.Abs(end.y - start.y);
    }
  }
}