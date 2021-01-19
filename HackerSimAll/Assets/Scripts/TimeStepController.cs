using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStepController : MonoBehaviour
{
    private System.DateTime startTime;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      SEAttributes player = SaveSEAttributes.LoadPlayer();
      TimeStep.TimeEvent((System.DateTime.Now - player.StartTime).Seconds, player);
    }
}
