using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_Script : MonoBehaviour
{
    HingeJoint hingeJointaccess;
    JointLimits limits;


    [SerializeField] float forceAmount = 10f;
    [SerializeField] Slider forceSlider;
    [SerializeField] Slider degreeSlider;
    // Start is called before the first frame update
    void Start()
    {
        hingeJointaccess = GetComponent<HingeJoint>();

        limits = hingeJointaccess.limits;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("xd");
            GetComponent<Rigidbody>().AddForce(transform.up * forceAmount);


        }


        forceAmount = forceSlider.value;

        limits.min = 0;
        limits.bounciness = 0;
        limits.bounceMinVelocity = 0;
        limits.max = degreeSlider.value;
        hingeJointaccess.limits = limits;
        hingeJointaccess.useLimits = true;
    }

    

}


