using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultBall : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;

    Rigidbody rb;
    bool isFired = false;
    
    // Start is called before the first frame update

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }


    private void Update()
    {
        if (isFired)
        {
            return;

        }

        else {


            transform.position = respawnPoint.position + new Vector3(0f, 0.5f, 0f);

        }


        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Respawn"))
        {
            isFired = false;
            transform.position = respawnPoint.position + new Vector3(0f, 0.5f, 0f);
            GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
        }
    }


    public void ChangeFireMode()
    {

        rb.isKinematic = false;
        isFired = true;

    }
}
