using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelpSway : MonoBehaviour
{
    public float wiggleMagnitude;
    public float wiggleSpeed;
    private HingeJoint2D joint;
    private JointMotor2D motor;
    // Start is called before the first frame update
    void Start()
    {
        //boneV = Vector3.zero;
        joint = GetComponent<HingeJoint2D>();
        motor = joint.motor;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        //this.transform.localRotation = targetDir.localRotation;//Vector3.SmoothDamp(this.transform.localRotation, targetDir.position, ref boneV, smoothSpeed);

        motor.motorSpeed = Mathf.Sin(Time.time *wiggleSpeed)* wiggleMagnitude;
        joint.motor = motor;
        //Debug.Log(motor.motorSpeed);
    }
}
