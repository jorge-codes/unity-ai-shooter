using System.Collections.Generic;
using UnityEngine;

public class SimplePath : MonoBehaviour
{
    [SerializeField] private Transform[] _nodes;

    public Vector3[] GetPositions()
    {
        List<Vector3> positions = new List<Vector3>(_nodes.Length);
        foreach (Transform t in _nodes)
        {
            if (t == null)
                continue;
            
            positions.Add(t.position);
        }
        
        return positions.ToArray();
    }

    public Transform[] GetNodes()
    {
        List<Transform> nodes = new List<Transform>(_nodes.Length);
        foreach (Transform t in _nodes)
        {
            if (t == null)
                continue;
            nodes.Add(t);
        }
        
        return nodes.ToArray();
    }

    private void OnDrawGizmos()
    {
        if (_nodes == null) return;
        
        Vector3 origin, target;
        Gizmos.color = Color.magenta;
        int i, j;
        for (i = 0; i < _nodes.Length; i++)
        {
            j = (i + 1) == _nodes.Length ? 0 : i + 1;
            if (_nodes[i] == null || _nodes[j] == null) continue;
            
            origin = _nodes[i].position;
            target = _nodes[j].position;
            Gizmos.DrawLine(origin, target);
        }
    }
}
