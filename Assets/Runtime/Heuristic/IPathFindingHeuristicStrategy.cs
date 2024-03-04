using UnityEngine;

namespace com.karabaev.pathFinding.Heuristic
{
  public interface IPathFindingHeuristicStrategy
  {
    float Calculate(Vector3 start, Vector3 end);
  }
}