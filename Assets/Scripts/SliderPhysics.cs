using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPhysics : MonoBehaviour
{
    [SerializeField]
    float velocity;
    public float gravity;
    public float acceleration;

    float minimumY, maximumY;

    RectTransform sliderTransform;
    float originalYposition, currentYposition;

    void Start()
    {
        sliderTransform = GetComponent<RectTransform>();
        originalYposition = sliderTransform.anchoredPosition.y;
        currentYposition = originalYposition;
        velocity = 0;
        gravity = -800.0f;
        acceleration = 1200.0f;

        minimumY = 0;
        maximumY = sliderTransform.parent.GetComponent<RectTransform>().sizeDelta.y;
    }

    // Update is called once per frame
    void Update()
    {
        sliderTransform.anchoredPosition = new Vector2(sliderTransform.anchoredPosition.x, currentYposition);
    }

    private void FixedUpdate()
    {
        velocity += gravity * Time.fixedDeltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            velocity += acceleration * Time.fixedDeltaTime;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || 
                touch.phase == TouchPhase.Moved || 
                touch.phase == TouchPhase.Stationary)
            {
                velocity += acceleration * Time.fixedDeltaTime;
            }
        }

        currentYposition += velocity * Time.fixedDeltaTime;

        CheckBounds();

    }

    void CheckBounds()
    {
        if (currentYposition < minimumY)
        {
            currentYposition = minimumY;
            velocity = -velocity * 0.6f;
        }

        if (currentYposition + sliderTransform.sizeDelta.y > maximumY)
        {
            currentYposition = maximumY - sliderTransform.sizeDelta.y;
            velocity = -velocity * 0.3f;
        }

        if (velocity <= Mathf.Abs(0.02f) && currentYposition - minimumY < 0.5f)
        {
            velocity = 0;
            currentYposition = minimumY;
        }

    }

}
