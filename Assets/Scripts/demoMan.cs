using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoMan : MonoBehaviour
{
    bool canCollide = false;
    float secondsToWait = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Respawn") && canCollide){
            GetComponent<Rigidbody>().isKinematic = true;

        }
    }

    public void StartCollisionDetection()
    {
        canCollide = false;
        StartCoroutine(ActivateCollision());


    }

    private IEnumerator ActivateCollision()
    {

        yield return new WaitForSeconds(secondsToWait);
        canCollide = true;

    }
}
