using UnityEngine;

public class AIPlayerAgent : AIAgent
{
    protected override void FixedUpdate()
    {
        transform.Translate(_velocity * _speed * Time.deltaTime, Space.World);
    }
}
