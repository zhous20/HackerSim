using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Death : MonoBehaviour
{
    public SEAttributes player;
    public GameObject TombText;
    // Start is called before the first frame update

    void Start()
    {
      player = SaveSEAttributes.LoadPlayer();
      TombText.GetComponent<Text>().text = player.PlayerName + " you died at " + Math.Round(player.PlayerAge) + " years old" + "with $ " + player.PlayerCurrency;
    }

}
