using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RodController : MonoBehaviour
{
    public GameObject gameLogicManager;
    GameLogic gameLogicScript;
    AudioSource reelingSound;
    AudioSource whippingSound;

    public AudioClip whipclip;
    public AudioClip reelclip;

    RectTransform rodHandle;
    Vector3 newRotation;
    float handleRotationSpeed;
    Animator rodAnimator;

    private bool isBeingReeled;
    private bool isBeingTouched;
    private bool touchEnded;
    private bool touchBegan;

    void Start()
    {
        rodHandle = transform.GetChild(0).GetComponent<RectTransform>();
        gameLogicScript = gameLogicManager.GetComponent<GameLogic>();

        AudioSource[] audiosources = GetComponents<AudioSource>();

        reelingSound = audiosources[0];
        whippingSound = audiosources[1];

        reelingSound.clip = reelclip;
        whippingSound.clip = whipclip;

        rodAnimator = GetComponent<Animator>();
        handleRotationSpeed = 2000.0f;

        isBeingReeled = false;
        isBeingTouched = false;
        touchEnded = false;
        touchBegan = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began ||
                touch.phase == TouchPhase.Moved ||
                touch.phase == TouchPhase.Stationary)
            {
                isBeingReeled = true;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                touchEnded = true;
            } else if (touch.phase == TouchPhase.Began)
            {
                touchBegan = true;
            }
        }

        if (Input.GetKey(KeyCode.Space) && gameLogicScript.IsFishBiting())
        {
            isBeingReeled = true;
        }

        if (gameLogicScript.IsFishBiting())
        {
            rodAnimator.SetBool("fishIsBiting", true);
        } else
        {
            rodAnimator.SetBool("fishIsBiting", false);
            reelingSound.Stop();
        }

        if (isBeingReeled)
        {
            newRotation = new Vector3(0, 0, rodHandle.eulerAngles.z + handleRotationSpeed * Time.deltaTime);
            rodHandle.eulerAngles = newRotation;
            rodAnimator.SetBool("fishIsReeling", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) || touchBegan && gameLogicScript.IsFishBiting())
        {
            reelingSound.Play();
        }

        if (!isBeingReeled && gameLogicScript.IsFishBiting())
        {
            newRotation = new Vector3(0, 0, rodHandle.eulerAngles.z - handleRotationSpeed* 0.1f * Time.deltaTime);
            rodHandle.eulerAngles = newRotation;
        }

        if (Input.GetKeyUp(KeyCode.Space) || touchEnded)
        {
            rodAnimator.SetBool("fishIsReeling", false);
            reelingSound.Pause();
        }

        if (Input.GetKeyUp(KeyCode.Space) || touchEnded && !gameLogicScript.IsFishBiting())
        {
            rodHandle.eulerAngles = new Vector3();
        }

        isBeingReeled = false;
        touchEnded = false;
        touchBegan = false;

    }
}
