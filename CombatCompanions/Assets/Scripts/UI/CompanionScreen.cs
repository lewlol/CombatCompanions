using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompanionScreen : MonoBehaviour
{
    public GameObject companionListUI;
    public CompanionInventory compInv;
    public GameObject uiParent;
    public Image activeCompanionUI;

    [Space]
    public GameObject emptyCompUI;
    List<GameObject> uiElements = new List<GameObject>();

    private void Start()
    {
        GameEvent.gameEvent.onSetActiveCompanion += ActiveCompanion;
    }
    public void GenericCompanions()
    {
        foreach(Companion companion in compInv.companions)
        {
            GameObject companionUI = Instantiate(emptyCompUI, transform.position, Quaternion.identity);
            companionUI.transform.SetParent(uiParent.transform);
            companionUI.GetComponent<Image>().sprite = companion.companionSprite;
            companionUI.GetComponentInChildren<TextMeshProUGUI>().text = companion.companionName;
            companionUI.GetComponentInChildren<TextMeshProUGUI>().color = companion.companionColour;
            companionUI.GetComponent<CompUI>().companion = companion;
            uiElements.Add(companionUI);
        }
    }

    public void UnloadCompanions()
    {
        foreach(GameObject element in uiElements)
        {
            Destroy(element);
        }

        uiElements.Clear();
    }

    public void ActiveCompanion(Companion companion)
    {
        activeCompanionUI.sprite = companion.companionSprite;
    }
}
