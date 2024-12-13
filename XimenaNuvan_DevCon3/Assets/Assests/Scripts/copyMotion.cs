using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class copyMotion : MonoBehaviour
{
    public Transform TargetLimb;
    public bool mirror;
    ConfigurableJoint cjoint;
    

    private void Start()
    {
        cjoint = GetComponent<ConfigurableJoint>();
    }

    private void Update()
    {

        Quaternion targetRotation = Quaternion.Inverse(TargetLimb.rotation) * transform.rotation;
        if (mirror)
        {
            targetRotation = Quaternion.Euler(targetRotation.eulerAngles.x, targetRotation.eulerAngles.y + 180f, targetRotation.eulerAngles.z);

            //cjoint.targetRotation = TargetLimb.rotation;
        }

        cjoint.targetRotation = targetRotation;
        //else
        //{
            //cjoint.targetRotation = Quaternion.Inverse(TargetLimb.rotation);
        //}
        
    }
}
