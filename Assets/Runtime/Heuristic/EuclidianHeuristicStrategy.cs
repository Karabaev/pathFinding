using System;
using UnityEngine;

namespace com.karabaev.pathFinding.Heuristic
{
  public class EuclidianHeuristicStrategy : IPathFindingHeuristicStrategy
  {
    public float Calculate(Vector3 start, Vector3 end)
    {
      return MathF.Sqrt(MathF.Pow(end.x - start.x, 2) + MathF.Pow(end.y - start.y, 2) + MathF.Pow(end.z - start.z, 2));
    }
  }
}