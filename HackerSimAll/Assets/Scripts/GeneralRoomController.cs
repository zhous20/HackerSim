using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GeneralRoomController : MonoBehaviour
{
    public GameObject buttonBox;
    public GameObject dialogBox;
    public Text dialog;
    // public Text dialogText;
    // public string dialog;
    public bool playerInRange;

    public void SelectProj()
    {
        SceneManager.LoadScene("ProjectScene");
    }

    public void SelectSEAtt()
    {
        SceneManager.LoadScene("SEAttributes");
    }

    public void SelectSave()
    {
      SEAttributes player = SaveSEAttributes.LoadPlayer();
      SaveSEAttributes.SavePlayer(player);
    }

    public void SelectShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void SelectInven()
    {

    }

    public void SelectChat()
    {
      SceneManager.LoadScene("MultiplayerMenu");
    }

    public void SelectExer()
    {
      SEAttributes player = SaveSEAttributes.LoadPlayer();
      player.currState = "exercising";
      SaveSEAttributes.SavePlayer(player);
      if(dialogBox.activeInHierarchy)
      {
        dialogBox.SetActive(false);
      }
      else
      {
        dialogBox.SetActive(true);
      }
      dialog.text = "You are now exercising...";

    }

    public void SelectSleep()
    {
      SEAttributes player = SaveSEAttributes.LoadPlayer();
      player.currState = "sleeping";
      SaveSEAttributes.SavePlayer(player);
      if(dialogBox.activeInHierarchy)
      {
        dialogBox.SetActive(false);
      }
      else
      {
        dialogBox.SetActive(true);
      }
      dialog.text = "You are now sleeping..";
    }

    public void SelectTv()
    {
      SEAttributes player = SaveSEAttributes.LoadPlayer();
      player.currState = "entertainment";
      SaveSEAttributes.SavePlayer(player);
      if(dialogBox.activeInHierarchy)
      {
        dialogBox.SetActive(false);
      }
      else
      {
        dialogBox.SetActive(true);
      }
      dialog.text = "You are now playing Wii..";
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
      {
        if(buttonBox.activeInHierarchy)
        {
          buttonBox.SetActive(false);
        }
        else
        {
          buttonBox.SetActive(true);
        }
      }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if(other.CompareTag("Player"))
      {
        playerInRange = true;
      }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if(other.CompareTag("Player"))
      {
        playerInRange = false;
        buttonBox.SetActive(false);
        dialogBox.SetActive(false);
        SEAttributes player = SaveSEAttributes.LoadPlayer();
        player.currState = "";
        SaveSEAttributes.SavePlayer(player);
      }
    }
}
