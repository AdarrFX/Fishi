using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public SliderPhysics slider;
    void Start()
    {
        slider = GetComponent<SliderPhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Do a thing
        }
    }
}
