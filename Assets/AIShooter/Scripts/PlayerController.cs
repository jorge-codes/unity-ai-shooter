using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _direction;
    
    // Start is called before the first frame update
    void Start()
    {
        _direction = Vector3.zero;
    }

    private void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        _direction.Normalize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }
    
}
