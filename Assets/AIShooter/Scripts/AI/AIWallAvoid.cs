using UnityEngine;
using UnityEngine.Serialization;

public class AIWallAvoid : AISeek
{
    public float length;
    public float avoidanceBorder = 3f;
    public string wallLayer = "Wall";
    private int _layerMask;
    private Transform _dummyTarget;

    public override void Init(AIAgent agent)
    {
        base.Init(agent);
        _layerMask = 1 << LayerMask.NameToLayer(wallLayer);
        GameObject dummy = new GameObject();
        dummy.name = "Dummy (wall avoidance)";
        _dummyTarget = dummy.transform;
    }

    public override Steering GetSteering()
    {
        RaycastHit hit;
        _steering = base.GetSteering();
        if (Physics.Raycast(transform.position, _steering.linear, out hit, length, _layerMask))
        {
            _dummyTarget.position = hit.point + hit.normal * avoidanceBorder;
            Vector3 direction = _dummyTarget.position - transform.position;
            direction.Normalize();
            _steering.linear += direction;
        }

        return _steering;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        
        Vector3 origin = transform.position;
        Vector3 direction = _target.position - origin;
        Vector3 target = origin + direction.normalized * length;
        Gizmos.color = Color.red;
        
        Gizmos.DrawLine(origin, target);
//        Gizmos.DrawSphere(_dummyTarget.position, 0.3f);  
    }
}
