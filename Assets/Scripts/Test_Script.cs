using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_Script : MonoBehaviour
{
    HingeJoint hingeJointaccess;



    [SerializeField] float forceAmount = 10f;
    [SerializeField] Slider forceSlider;
    [SerializeField] Slider degreeSlider;
    // Start is called before the first frame update
    void Start()
    {
        hingeJointaccess = GetComponent<HingeJoint>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("xd");
            GetComponent<Rigidbody>().AddForce(transform.up * forceAmount);


        }


        forceAmount = forceSlider.value;

    }



}


