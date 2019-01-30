using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBehavior : AIBehavior
{

    // Update is called once per frame
    void Update()
    {
        _steering.Restore();
        _steering.linear.x = Input.GetAxis("Horizontal");
        _steering.linear.z = Input.GetAxis("Vertical");
        _steering.linear.Normalize();
    }

//    public override Steering GetSteering()
//    {
//        return _steering;
//    }
}
