using UnityEngine;

public class AIPathFollower : AISeek
{
    [SerializeField] private SimplePath _path;
    [SerializeField] private float _validRadius;
    private int _current;
    private Transform[] _nodes;
    
    // Start is called before the first frame update

    public override void Init(AIAgent agent)
    {
        base.Init(agent);
        _nodes = _path.GetNodes();
        _current = 0;
        _target = _nodes[_current];
    }

// Update is called once per frame
    public override Steering GetSteering()
    {
        float distance = Vector3.Distance(_target.position, transform.position);
        _steering = base.GetSteering();
        if (distance <= _validRadius)
        {
            _current = _current + 1 >= _nodes.Length ? 0 : ++_current;    
            _target = _nodes[_current];
        }
        

        return _steering;
    }
}
