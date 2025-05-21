using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameLogic : MonoBehaviour
{
    public GameObject fishSliderContainer;
    public GameObject fishObject;
    public ProgressBarScript progressBar;
    public GameObject mainCanvas;
    public GameObject fishMenuPrefab;
    public List<Fish> FishTypeList;

    List<RectTransform> fishTransformList;
    bool spawnedFish;
    int totalFishCaught;

    Fish newFish;

    private void Awake()
    {
        fishTransformList = new List<RectTransform>();
    }
    void Start()
    {
        spawnedFish = false;
        progressBar.FishCaught += FishWasCaughtActions;
        totalFishCaught = 0;
        ChooseNewFish();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            AddFish();
            spawnedFish = true;
        } else if (Input.GetKeyUp(KeyCode.F))
        {
            spawnedFish = false;
        }
    }

    void FishWasCaughtActions()
    {
        totalFishCaught ++;
        GameObject fishMenuPopup = Instantiate(fishMenuPrefab, mainCanvas.transform);
        fishMenuPopup.transform.GetChild(3).GetComponent<Image>().sprite = newFish.fishSprite;
        fishMenuPopup.transform.GetChild(3).GetComponent<Image>().color = newFish.fishColor;
        fishMenuPopup.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = "A " + newFish.fishName;

        ChooseNewFish();
    }

    public int GetFishCaught()
    {
        return totalFishCaught;
    }

    public void AddFish()
    {
        fishTransformList.Add(Instantiate(fishObject, fishSliderContainer.transform).GetComponent<RectTransform>());
    }

    public List<RectTransform> GetFishList()
    {
        return fishTransformList;
    }

    public bool IsFishBiting()
    {
        return (fishTransformList.Count > 0);
    }

    void ChooseNewFish()
    {
        newFish = PickRandomFish();
    }

    Fish PickRandomFish()
    {
        if (FishTypeList.Count == 0)
        {
            Debug.LogWarning("No fish in the collection!");
            return null;
        }

        int randomIndex = UnityEngine.Random.Range(0, FishTypeList.Count);
        return FishTypeList[randomIndex];
    }

}
