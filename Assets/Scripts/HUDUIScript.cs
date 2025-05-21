using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDUIScript : MonoBehaviour
{
    TMPro.TextMeshProUGUI HUDtext;
    public GameLogic gameLogic;

    void Start()
    {
        HUDtext = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        HUDtext.text = "CAUGHT: " + gameLogic.GetFishCaught();
    }
}
