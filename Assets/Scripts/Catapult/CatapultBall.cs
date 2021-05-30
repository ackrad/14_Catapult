using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultBall : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;


    // Start is called before the first frame update


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Respawn"))
        {

            transform.position = respawnPoint.position + new Vector3(0f, 0.5f, 0f);
            GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
        }
    }

}
