using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowingCamera : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected Transform _target;
    [SerializeField] protected float _stopRadius;
    protected Vector3 _relativePosition;
//    protected Camera _camera;

    protected float _distance;
//    protected Quaternion _relativeRotation;

    private void Start()
    {
//        _camera = GetComponent<Camera>();
        _relativePosition = transform.position;
    }

    private void Update()
    {
        if (_target == null) return;
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = _target.position + _relativePosition;
        Vector3 direction = targetPosition - currentPosition;
        _distance = direction.magnitude;
        if (_distance > _stopRadius)
        {
            direction.Normalize();
            transform.Translate(direction * _speed * Time.deltaTime, Space.World);
        }
    }
}
