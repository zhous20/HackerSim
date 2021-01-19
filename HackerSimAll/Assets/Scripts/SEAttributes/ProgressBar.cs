using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public SEAttributes player;
    public string attribute;
    public int max;
    public int curr;
    public Image mask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = SaveSEAttributes.LoadPlayer();
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        GetCurrent();
        float fillAmount = (float)curr / (float)max;
        mask.fillAmount = fillAmount;
    }

    void GetCurrent()
    {
        if (attribute == "mood")
        {
            curr = player.Mood;
            // Debug.Log("Player Mood: " + player.Mood);
        }
        else if (attribute == "hunger")
        {
            curr = player.Hunger;
            // Debug.Log("Player Hunger: " + player.Hunger);
        }
        else if (attribute == "tired")
        {
            curr = player.Tired;
            // Debug.Log("Player Tired: " + player.Tired);
        }
        else if (attribute == "fitness")
        {
            curr = player.Fitness;
            // Debug.Log("Player Fitness: " + player.Fitness);
        }
    }
}
