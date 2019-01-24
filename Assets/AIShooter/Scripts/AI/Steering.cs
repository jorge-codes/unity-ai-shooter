using UnityEngine;

public class Steering
{
    public Vector3 linear;
    public float angular;

    public void Restore()
    {
        linear = Vector3.zero;
        angular = 0f;
    }
}
