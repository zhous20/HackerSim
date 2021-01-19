using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // To deal with Unity UI elements
using UnityEngine.SceneManagement;

public class PlayerCreation : MonoBehaviour
{
    public SEAttributes newPlayer = new SEAttributes();
    private string playerName;
    private string playerGender;
    public GameObject inputField; // Where we are typing the text

    public void SelectMale()
    {
        playerGender = "male";
    }

    public void SelectFemale()
    {
        playerGender = "female";
    }
    public void CreatePlayer()
    {
        playerName = inputField.GetComponent<Text>().text;
        newPlayer.PlayerName = playerName;
        newPlayer.PlayerGender = playerGender;
        newPlayer.PlayerAge = 15;
        newPlayer.Mood = 100;
        newPlayer.Hunger = 100;
        newPlayer.Tired = 100;
        newPlayer.Fitness = 100;
        newPlayer.PlayerCurrency = 5.00;
        newPlayer.currState = "";
        newPlayer.StartTime = System.DateTime.Now;
        SaveSEAttributes.SavePlayer(newPlayer);

        // Testing
        newPlayer = SaveSEAttributes.LoadPlayer();
        Debug.Log(newPlayer.PlayerName + newPlayer.PlayerGender + newPlayer.PlayerAge + newPlayer.PlayerCurrency);

        SceneManager.LoadScene("GeneralRoom");
    }

}
