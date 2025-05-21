using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBehaviour : MonoBehaviour
{
    bool touchDelayDone = false;
    void Start()
    {
        StartCoroutine(canBeTouched());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Destroy(gameObject);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && touchDelayDone)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator canBeTouched()
    {
        yield return new WaitForSeconds(2.2f);
        touchDelayDone = true;
    }

}
