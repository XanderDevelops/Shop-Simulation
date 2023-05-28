using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //This scipt takes care of every general thing, and was done during the interview test time

    public TextMeshProUGUI coinsText;
    public static int coins;
    public GameObject[] sellButtons;

    void Start()
    {
        if(!PlayerPrefs.HasKey("Coins")){
            PlayerPrefs.SetInt("Coins", 100);
        }

        coins = PlayerPrefs.GetInt("Coins");
    }

    void Update()
    {
        coinsText.text = coins.ToString() + " coins";
    }
}
