using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Script : MonoBehaviour
{

    [SerializeField] float forceAmount = 10f;
    HingeJoint hingeJoint;
    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("xd");
            GetComponent<Rigidbody>().AddForce(transform.up * forceAmount);


        }


    }
}
