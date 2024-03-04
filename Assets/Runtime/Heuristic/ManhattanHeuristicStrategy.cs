using System;
using UnityEngine;

namespace com.karabaev.pathFinding.Heuristic
{
  public class ManhattanHeuristicStrategy : IPathFindingHeuristicStrategy
  {
    public float Calculate(Vector3 start, Vector3 end)
    {
      return MathF.Abs(end.x - start.x) + MathF.Abs(end.y - start.y) + + MathF.Abs(end.z - start.z);
    }
  }
}