using UnityEngine;

namespace com.karabaev.pathFinding.Heuristic
{
  public interface IPathFindingHeuristicStrategy
  {
    float Calculate(Vector2Int start, Vector2Int end);
  }
}