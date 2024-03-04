using UnityEngine;

namespace com.karabaev.pathFinding.WalkingMap
{
  public readonly struct MapNode
  {
    public Vector3 Position { get; }
    
    public MapNodeType Type { get; }

    public MapNode(Vector3 position, MapNodeType type)
    {
      Position = position;
      Type = type;
    }
  }
}