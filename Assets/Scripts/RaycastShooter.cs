using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooter : MonoBehaviour
{

    [SerializeField] Transform goalKeeper;
    [SerializeField] float jumpForce = 14f;
    [SerializeField] float jumptime = 2f;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        LayerMask layerMask = LayerMask.GetMask("RaycastHit");

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");


            goalKeeper.position = new Vector3(goalKeeper.position.x, goalKeeper.position.y, hit.point.z);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }


    public void Jump()
    {
        var rb = goalKeeper.GetComponent<Rigidbody>();
        goalKeeper.GetComponent<demoMan>().StartCollisionDetection();
        rb.isKinematic = false;
        rb.AddForce(Vector3.up * jumpForce,ForceMode.VelocityChange);




    }




}
