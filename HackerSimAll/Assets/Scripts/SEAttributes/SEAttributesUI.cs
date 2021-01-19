using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SEAttributesUI : MonoBehaviour
{
    public SEAttributes player;
    public GameObject nameText;
    public GameObject ageText;
    public GameObject currencyText;

    void Start()
    {
      player = SaveSEAttributes.LoadPlayer();
      nameText.GetComponent<Text>().text = player.PlayerName;
      ageText.GetComponent<Text>().text = Math.Round(player.PlayerAge) + " years old";
      currencyText.GetComponent<Text>().text = "$ " + player.PlayerCurrency;
    }

    // void Update()
    // {
    //   player = SaveSEAttributes.LoadPlayer();
    //   nameText.GetComponent<Text>().text = player.PlayerName;
    //   ageText.GetComponent<Text>().text = Math.Round(player.PlayerAge).ToString() + " years old";
    //   UnityEngine.Debug.Log(Math.Round(player.PlayerAge));
    //   currencyText.GetComponent<Text>().text = "$ " + player.PlayerCurrency;
    // }

    public void SelectClose()
    {
      SceneManager.LoadScene("GeneralRoom");
    }
}
