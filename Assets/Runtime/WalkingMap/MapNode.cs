using UnityEngine;

namespace com.karabaev.pathFinding.WalkingMap
{
  public readonly struct MapNode
  {
    public Vector2Int Position { get; }
    
    public MapNodeType Type { get; }

    public MapNode(Vector2Int position, MapNodeType type)
    {
      Position = position;
      Type = type;
    }
  }
}