using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    public Sprite itemIcon;
    public string itemName;
    public int buyPrice;
    public int sellPrice;
    public bool consumable;
    public int purchased;
    public Image visibleIcon;
    public TextMeshProUGUI detailsText;
    public Inventory inventory;

    private Button buyButton;

    public void Start(){
        purchased = PlayerPrefs.GetInt(itemName);

        if(itemIcon != null)
        visibleIcon.sprite = itemIcon;

        buyButton = GetComponentInChildren<Button>();
        if (buyButton != null && buyButton.name == "Buy")
        {
            buyButton.onClick.AddListener(BuyItem);
            if(!consumable && purchased > 0){
                buyButton.interactable = false;
            }else{
                buyButton.interactable = true;
            }
        }
        else
        {
            Button sellButton = GetComponentInChildren<Button>();
            if (sellButton != null && sellButton.name == "Sell")
            {
                sellButton.onClick.AddListener(SellItem);
            }
        }
    }

    void Update(){
        if(detailsText != null)
        detailsText.text = itemName + "\n" + buyPrice.ToString() + " coins";

        if(PlayerPrefs.GetInt(itemName) > 0 && !consumable && buyButton.name == "Buy"){
                buyButton.interactable = false;
            }else if(buyButton.name == "Buy"){
                buyButton.interactable = true;
            }
    }

    public void BuyItem()
    {
        if(GameManager.coins >= buyPrice){
            GameManager.coins -= buyPrice;
            PlayerPrefs.SetInt("Coins", GameManager.coins);
            int amount = PlayerPrefs.GetInt(itemName);
            PlayerPrefs.SetInt(itemName, amount + 1);
            purchased = PlayerPrefs.GetInt(itemName);
            Debug.Log(itemName + ": " + PlayerPrefs.GetInt(itemName));
            if(!consumable && purchased > 0){
                buyButton.interactable = false;
            }
            inventory.UpdateInventory();
        }
    }

    public void SellItem()
    {
        if(PlayerPrefs.GetInt(itemName) > 0){
            GameManager.coins += sellPrice;
            PlayerPrefs.SetInt("Coins", GameManager.coins);
            int amount = PlayerPrefs.GetInt(itemName);
            PlayerPrefs.SetInt(itemName, amount - 1);
            purchased = PlayerPrefs.GetInt(itemName);
            Debug.Log(itemName + ": " + PlayerPrefs.GetInt(itemName));
            if(purchased == 0 && buyButton.name == "Buy"){
                buyButton.interactable = true;
            }
            inventory.UpdateInventory();
        }
    }
}