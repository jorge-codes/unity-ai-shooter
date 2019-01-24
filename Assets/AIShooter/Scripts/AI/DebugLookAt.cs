using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLookAt : MonoBehaviour
{
    public float length = 3f;
    
    private void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Vector3 origin = transform.position;
        Vector3 target = transform.position + transform.forward * length;
        Debug.DrawLine(origin, target, Color.blue);
    }
}
