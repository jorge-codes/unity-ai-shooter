using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowingCamera : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected Transform _target;
    [SerializeField] protected float _actionRadius;
    [SerializeField] protected float _stopRadius;
    protected bool _isMoving;
    protected float[] _radii;
    protected Vector3 _relativePosition;

    protected float _distance;

    private void Start()
    {
        _isMoving = false;
        _relativePosition = transform.position;
        _radii = new float[2];
        _radii[0] = _actionRadius;
        _radii[1] = _stopRadius;
    }

    private void Update()
    {
        if (_target == null) return;
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = _target.position + _relativePosition;
        Vector3 direction = targetPosition - currentPosition;
        int isMoving = _isMoving ? 1 : 0;
        _distance = direction.magnitude;
        if (_distance > _radii[isMoving])
        {
            _isMoving = true;
            direction.Normalize();
            transform.Translate(direction * _speed * Time.deltaTime, Space.World);
        }
        else
        {
            _isMoving = false;
        }
    }
}
