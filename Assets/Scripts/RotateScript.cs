using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotateScript : MonoBehaviour
{
    [SerializeField] Slider rotationSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(
    transform.eulerAngles.x,
    rotationSlider.value,
    transform.eulerAngles.z
    );

    }
}
