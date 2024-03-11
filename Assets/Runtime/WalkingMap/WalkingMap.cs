using System.Collections.Generic;
using UnityEngine;

namespace com.karabaev.pathFinding.WalkingMap
{
  public class WalkingMap
  {
    private static readonly Vector2Int[] NeighboursTemplate = { new(1, 0), new(0, 1), new(-1, 0), new(0, -1) };
    
    private readonly Dictionary<Vector2Int, WalkingMapNode> _nodes;

    public IReadOnlyDictionary<Vector2Int, WalkingMapNode> Nodes => _nodes;

    public WalkingMapNode this[Vector2Int coords] => _nodes[coords];

    private WalkingMapNode[] GetNeighbors(WalkingMapNode node)
    {
      var result = new List<WalkingMapNode>(NeighboursTemplate.Length);

      foreach(var templateItem in NeighboursTemplate)
      {
        var position = node.Position + templateItem;

        if(!_nodes.ContainsKey(position))
          continue;
        
        result.Add(_nodes[position]);
      }

      return result.ToArray();
    }
    
    public WalkingMap(IReadOnlyList<MapNode> map)
    {
      _nodes = new Dictionary<Vector2Int, WalkingMapNode>(map.Count);

      foreach(var node in map)
        _nodes.Add(node.Position, new WalkingMapNode(node.Position, node.Type == MapNodeType.Free, 1.0f));

      foreach(var node in _nodes.Values)
        node.Neighbours = GetNeighbors(node);
    }
  }
}