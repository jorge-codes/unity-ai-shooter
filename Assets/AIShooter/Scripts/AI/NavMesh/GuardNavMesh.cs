using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GuardNavMesh : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;
    private int _currentTarget;
    private NavMeshAgent _agent;
    private float _oldMagnitude;
    private float _newMagnitude;
    
    // Start is called before the first frame update
    void Start()
    {
        _newMagnitude = 0f;
        _oldMagnitude = 0f;
        _currentTarget = 0;
        _agent = GetComponent<NavMeshAgent>();
        GoToPoint(_currentTarget);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _newMagnitude = _agent.velocity.magnitude;
        if (_newMagnitude != _oldMagnitude && _newMagnitude == 0f)
        {
            _currentTarget++;
            if (_currentTarget >= _targetPoints.Length)
            {
                _currentTarget = 0;
            }
            GoToPoint(_currentTarget);
        }

        _oldMagnitude = _newMagnitude;
    }

    private void GoToPoint(int pointNumber)
    {
        _agent.destination = _targetPoints[pointNumber].position;
    }
}
