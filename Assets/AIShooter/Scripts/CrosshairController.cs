

using UnityEngine;
using UnityEngine.Events;

public class CrosshairController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset; 
    private Camera _camera;
    [SerializeField] private string layer = "Floor";
    [SerializeField] private UnityEvent onShoot;

    private int _layerMask;
    // Start is called before the first frame update
    void Start()
    {
        _layerMask = 1 << LayerMask.NameToLayer(layer);
        if (_camera == null)
        {
            _camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            onShoot.Invoke();
        }
        
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
        {
            transform.position = hit.point + _offset;
        }
        else
        {
            transform.position = Vector3.zero + _offset;
            if (_player != null)
            {
                transform.position += _player.position;                
            }
        }
    }
}
