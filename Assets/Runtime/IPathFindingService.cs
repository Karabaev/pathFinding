using System.Collections.Generic;
using com.karabaev.pathFinding.Heuristic;
using UnityEngine;

namespace com.karabaev.pathFinding
{
  public interface IPathFindingService
  {
    Stack<Vector3> FindPath(Vector3 origin, Vector3 destination, WalkingMap.WalkingMap walkingMap, IPathFindingHeuristicStrategy heuristicStrategy);
  }
}