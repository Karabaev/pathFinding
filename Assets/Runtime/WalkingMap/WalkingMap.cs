using System.Collections.Generic;
using UnityEngine;

namespace com.karabaev.pathFinding.WalkingMap
{
  public class WalkingMap
  {
    private static readonly Vector3[] NeighboursTemplate = { new(1, 0), new(0, 1), new(-1, 0), new(0, -1) };
    
    private readonly Dictionary<Vector3, WalkingMapNode> _nodes;

    public IReadOnlyDictionary<Vector3, WalkingMapNode> Nodes => _nodes;

    public WalkingMapNode this[Vector3 coords] => _nodes[coords];

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
      _nodes = new Dictionary<Vector3, WalkingMapNode>(map.Count);

      foreach(var node in map)
        _nodes.Add(node.Position, new WalkingMapNode(node.Position, node.Type == MapNodeType.Free, 1.0f));

      foreach(var node in _nodes.Values)
        node.Neighbours = GetNeighbors(node);
    }
  }
}