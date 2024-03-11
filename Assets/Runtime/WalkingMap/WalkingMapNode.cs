using UnityEngine;

namespace com.karabaev.pathFinding.WalkingMap
{
  public class WalkingMapNode
  {
    public Vector2Int Position { get; }

    public bool Walkable { get; }

    public float CostMultiplier { get; }

    public WalkingMapNode[] Neighbours { get; set; } = null!;

    public WalkingMapNode(Vector2Int position, bool walkable, float costMultiplier)
    {
      Position = position;
      Walkable = walkable;
      CostMultiplier = costMultiplier;
    }
  }
}