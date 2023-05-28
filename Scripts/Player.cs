using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Buy, Sell;
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Shopkeeper")){
            Debug.Log("Buy or sell?");
            Buy.SetActive(true);
        }else if(other.gameObject.CompareTag("Villager")){
            Debug.Log("sell?");
            Sell.SetActive(true);
        }
    }

    void OnCollisionExit2D(Collision2D other){
            Buy.SetActive(false);
            Sell.SetActive(false);
    }
}
