using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Total_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform phalanx1;
    [SerializeField] Transform phalanx2;
    [SerializeField] Transform phalanx3;
    Test_Script ts;
    [SerializeField] CatapultBall catapultBall;



    RotateScript rtScript;

    public float forceMultiplier = 100;
    void Start()
    {
        ts = GetComponentInChildren<Test_Script>();
    }

    // Update is called once per frame
    void Update()
    {




        SetRotation();
        SetPower();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            catapultBall.ChangeFireMode();
            ts.Fire();
        }

    }

    private void SetPower()
    {
        if(phalanx2.eulerAngles.z > 180) { ts.forceAmount = 0; return; }

        ts.forceAmount = (phalanx2.eulerAngles.y-180) * forceMultiplier;
    }

    private void SetRotation()
    {
        transform.eulerAngles = new Vector3(
        transform.eulerAngles.x,
        phalanx3.eulerAngles.y-180,
        transform.eulerAngles.z);


    }
}
