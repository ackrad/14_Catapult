using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform phalanx1;
    [SerializeField] Transform phalanx2;
    [SerializeField] Transform phalanx3;
    [SerializeField] float spinSpeed = 1f;

    Vector3 phalanx1EulerAngles;
    Vector3 phalanx2EulerAngles;
    Vector3 phalanx3EulerAngles;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TUNAYA NOT : Buraya Inputlarý besleyebilirsin. Þu anda 1-6 ya kadar rakamlarla açýlarý kontrol ediyorsun

        if (Input.GetKey(KeyCode.Alpha1))
        {
            phalanx1.Rotate(new Vector3(0, 0, +spinSpeed * Time.deltaTime), Space.Self);

        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            phalanx1.Rotate(new Vector3(0, 0, -spinSpeed * Time.deltaTime), Space.Self);

        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            phalanx2.Rotate(new Vector3(0, 0, +spinSpeed * Time.deltaTime), Space.Self);

        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            phalanx2.Rotate(new Vector3(0, 0, -spinSpeed * Time.deltaTime), Space.Self);

        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            phalanx3.Rotate(new Vector3(0, 0, +spinSpeed * Time.deltaTime), Space.Self);

        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
          //  phalanx3.eulerAngles = new Vector3(0, 0, phalanx3.eulerAngles.z - spinSpeed * Time.deltaTime);

            phalanx3.Rotate(new Vector3(0, 0, -spinSpeed * Time.deltaTime), Space.Self);

        }



        // aþaðýdaki þekilde olabilir

        /*

        phalanx1EulerAngles = new Vector3(0, 0, phalanx1acisi);
        phalanx2EulerAngles = new Vector3(0, 0, phalanx1acisi);

        phalanx3EulerAngles = new Vector3(0, 0, phalanx1acisi);


        phalanx1.eulerAngles = phalanx1EulerAngles;
        phalanx2.eulerAngles = phalanx2EulerAngles;
        phalanx3.eulerAngles = phalanx3EulerAngles;
        */
    }
}
