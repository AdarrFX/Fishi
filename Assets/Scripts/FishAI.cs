using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{
    // Start is called before the first frame update

    float targetYRange;
    float moveTarget;
    float fishVelocity;
    float velocityGain = 1.0f;
    float posChange;

    float timeToWaitUntilNewTarget;

    RectTransform fishTransform;

    void Start()
    {
        fishTransform = GetComponent<RectTransform>();
        timeToWaitUntilNewTarget = 1.0f;

        // The range that the fish AI will target is based on the height of the column the slider sits in.
        targetYRange = transform.parent.GetComponent<RectTransform>().sizeDelta.y;

        StartCoroutine(WaitUntilNewTarget());
    }

    // Update is called once per frame
    void Update()
    {
        RunFishAI();
    }

    void RunFishAI() {

        fishVelocity = moveTarget - fishTransform.anchoredPosition.y * velocityGain;

        posChange = fishTransform.anchoredPosition.y;
        posChange += fishVelocity * Time.deltaTime;

        fishTransform.anchoredPosition = new Vector2(fishTransform.anchoredPosition.x, posChange);

    }

    void ChooseNewTarget()
    {
        moveTarget = Random.Range(0, targetYRange);
    }

    IEnumerator WaitUntilNewTarget()
    {
        ChooseNewTarget();
        timeToWaitUntilNewTarget = Random.Range(1.0f, 2.5f);

        yield return new WaitForSeconds(timeToWaitUntilNewTarget);

        StartCoroutine(WaitUntilNewTarget());
    }

}
