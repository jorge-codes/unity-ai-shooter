using UnityEngine;

public class LookAtObjectController : MonoBehaviour
{
    public Transform _target;
    
    // Start is called before the first frame update
    void Start()
    {
        if (_target == null)
        {
            Debug.LogError("No target assigned");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null) return;
        if (_target.position.Equals(transform.position))
        {
            transform.LookAt(transform.position + transform.forward);
        }
        transform.LookAt(_target);
    }
}
