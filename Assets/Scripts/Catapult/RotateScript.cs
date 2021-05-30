using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotateScript : MonoBehaviour
{
    [SerializeField] Slider rotationSlider;
    [SerializeField] 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles.y < 180)
        {
            rotationSlider.value = transform.eulerAngles.y;
        }
        else {
            Debug.Log(transform.eulerAngles.y-360);

            rotationSlider.value = transform.eulerAngles.y - 360;

        }
    }
}
