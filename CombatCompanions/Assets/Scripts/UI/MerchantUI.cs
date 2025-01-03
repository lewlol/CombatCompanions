using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MerchantUI : MonoBehaviour
{
    public GameObject merchantUI;
    Transform merchant;
    
    //TradeStuff
    public Companion[] companions;

    //Slot 1
    Companion slot1Companion;
    public Image slot1Image;
    public TextMeshProUGUI slot1Name;
    public TextMeshProUGUI slot1Description;
    public TextMeshProUGUI slot1Cost;
    public Button slot1Button;
    [Space]
    //Slot 2
    Companion slot2Companion;
    public Image slot2Image;
    public TextMeshProUGUI slot2Name;
    public TextMeshProUGUI slot2Description;
    public TextMeshProUGUI slot2Cost;
    public Button slot2Button;

    [Space]
    //Slot 3
    Companion slot3Companion;
    public Image slot3Image;
    public TextMeshProUGUI slot3Name;
    public TextMeshProUGUI slot3Description;
    public TextMeshProUGUI slot3Cost;
    public Button slot3Button;

    private void Awake()
    {
        GameEvents.gameEvent.onOpenMerchantUI += OpenUI;
        GameEvents.gameEvent.onCloseMerchantUI += CloseUI;
        merchant = GameObject.FindGameObjectWithTag("Merchant").transform;
    }
    public void OpenUI()
    {
        merchantUI.SetActive(true);
        SetItems();
    }

    public void CloseUI()
    {
        merchantUI.SetActive(false);
    }

    private void SetItems()
    {
        int c1 = Random.Range(0, companions.Length);
        slot1Companion = companions[c1];
        slot1Image.sprite = slot1Companion.companionSprite;
        slot1Name.text = slot1Companion.companionName;
        slot1Description.text = slot1Companion.companionDescription;
        slot1Cost.text = slot1Companion.companionCost.ToString();

        int c2 = Random.Range(0, companions.Length);
        slot2Companion = companions[c2];
        slot2Image.sprite = slot2Companion.companionSprite;
        slot2Name.text = slot2Companion.companionName;
        slot2Description.text = slot2Companion.companionDescription;
        slot2Cost.text = slot2Companion.companionCost.ToString();

        int c3 = Random.Range(0, companions.Length);
        slot3Companion = companions[c3];
        slot3Image.sprite = slot3Companion.companionSprite;
        slot3Name.text = slot3Companion.companionName;
        slot3Description.text = slot3Companion.companionDescription;
        slot3Cost.text = slot3Companion.companionCost.ToString();

        CheckSoulCounts();
    }

    private void CheckSoulCounts()
    {
        bool canAffordSlot1 = Souls.CheckSoulCount(slot1Companion.companionCost);
        if (canAffordSlot1)
        {
            slot1Cost.color = Color.green;
            slot1Button.interactable = true;
        }
        else
        {
            slot1Cost.color = Color.red;
            slot1Button.interactable = false;
        }

        bool canAffordSlot2 = Souls.CheckSoulCount(slot2Companion.companionCost);
        if (canAffordSlot2)
        {
            slot2Cost.color = Color.green;
            slot2Button.interactable = true;
        }
        else
        {
            slot2Cost.color= Color.red;
            slot2Button.interactable = false;
        }

        bool canAffordSlot3 = Souls.CheckSoulCount(slot3Companion.companionCost);
        if (canAffordSlot3)
        {
            slot3Cost.color = Color.green;
            slot3Button.interactable = true;
        }
        else
        {
            slot3Cost.color= Color.red;
            slot3Button.interactable = false;
        }
    }

    public void BuyItem(int slot)
    {
        if(slot == 1) //Bought Slot 1
        {
            Instantiate(slot1Companion.companionPrefab, merchant.transform.position, Quaternion.identity);
            PlayerEvents.playerEvent.RemoveSouls(slot1Companion.companionCost);
        }
        else if(slot == 2) //Bought Slot 2
        {
            Instantiate(slot2Companion.companionPrefab, merchant.transform.position, Quaternion.identity);
            PlayerEvents.playerEvent.RemoveSouls(slot2Companion.companionCost);
        }
        else if(slot == 3) //Bought Slot 3
        {
            Instantiate(slot3Companion.companionPrefab, merchant.transform.position, Quaternion.identity);
            PlayerEvents.playerEvent.RemoveSouls(slot3Companion.companionCost);
        }

        CheckSoulCounts();
    }
}
