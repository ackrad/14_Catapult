using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{
    Rigidbody rb;

    Vector3 startingPos;
    [SerializeField] Vector3 shoot =new Vector3 (0f,0f,0f) ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            KickBall();
        }

        if (Input.GetKeyDown(KeyCode.A)){
            rb.velocity = new Vector3(0f, 0f, 0f);
            transform.position = startingPos;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            Time.timeScale = 0.2f;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {

            Time.timeScale = 1f;
        }


    }

    private void KickBall()
    {

        rb.AddForce(shoot, ForceMode.Impulse);


    }
}
