using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GeneralRoomView : MonoBehaviour
{
    public int timeStart = 3;
    private float secondCount = 60;
    public TextMeshProUGUI textBox;
    public Text secondBox;
    // Use this for initialization
    void Start()
    {
        textBox.text = timeStart.ToString();
        secondBox.text = secondCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        secondCount -= Time.deltaTime;
        secondBox.text = Mathf.Round(secondCount).ToString();
        if (Mathf.Round(secondCount) == 0)
        {
            secondCount = 60;
            timeStart -= 1;
            textBox.text = timeStart.ToString();
        }
        
    }
    public void openProjects()
    {
        SceneManager.LoadScene("ProjectScene");
    }
}
