using System.Collections.Generic;
using com.karabaev.pathFinding.Heuristic;
using UnityEngine;

namespace com.karabaev.pathFinding
{
  public interface IPathFindingService
  {
    Stack<Vector2Int> FindPath(Vector2Int origin, Vector2Int destination, WalkingMap.WalkingMap walkingMap, IPathFindingHeuristicStrategy heuristicStrategy);
  }
}