using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //This scipt takes care of the player's inventory, and was done during the interview test time

    public Item[] allItems;
    public Item[] slots;
    public GameObject[] equipBttn;
    public GameObject[] wearables;

    void Start(){
        UpdateInventory();
    }

    public void UpdateInventory(){
        for(int i = 0; i < allItems.Length; i++){
            if(PlayerPrefs.GetInt(allItems[i].itemName) > 0){

                for(int k = 0; k < slots.Length; k++){
                    if(slots[k].itemName == ""){
                        slots[k].itemName = allItems[i].itemName;
                        slots[k].itemIcon = allItems[i].itemIcon;
                        slots[k].visibleIcon.sprite = slots[k].itemIcon;
                        slots[k].buyPrice = allItems[i].buyPrice;
                        slots[k].sellPrice = allItems[i].sellPrice;
                        slots[k].consumable = allItems[i].consumable;
                        slots[k].purchased = allItems[i].purchased;

                        if(slots[k].consumable == false){
                            equipBttn[k].SetActive(true);
                        }
                        break;
                    }else if(slots[k].itemName == allItems[i].itemName){
                        break;
                    }                    

                    if(slots[k].itemName != "" && PlayerPrefs.GetInt(slots[k].itemName) == 0){
                        slots[k].visibleIcon.sprite = null;
                    }
                }
            }
        }
    }

    public void Equip(int buttonIndex)
    {
        string itemName = slots[buttonIndex].itemName;

        for (int j = 0; j < wearables.Length; j++)
        {
            if (wearables[j].tag == itemName)
            {
                if (wearables[j].activeSelf)
                {
                    wearables[j].SetActive(false);
                }
                else
                {
                    wearables[j].SetActive(true);
                }
            }
        }
    }

}
