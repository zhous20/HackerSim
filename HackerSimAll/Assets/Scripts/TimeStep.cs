using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeStep
{
    public static int prevtime = 0;
    public static double factor;
    public static int count = 1;
    public static bool alt = false;

    public static void TimeEvent(int gameMinutes, SEAttributes player)
    {
        if (gameMinutes % 7 == 0 && gameMinutes != prevtime) // In ~ 12 hours (1 day), their hunger, tiredness and fitness will be at 0
        {
            for(int i = 0; i >= 0; i -= 15)
            {
              SEAttributesController.IncreaseTired(player);
              SEAttributesController.DecreaseFitness(player);
            }

            SEAttributesController.IncreaseHunger(player);
            SEAttributesController.DecreaseMood(player);

            if(alt)
            {
              if(AddItem.isTree)
              {
                SEAttributesController.IncreaseMood(player);
                SEAttributesController.DecreaseHunger(player);
              }
              if(AddItem.isPlant)
                SEAttributesController.IncreaseMood(player);
            }
            alt = !alt;
        }
        if(player.currState != "" && gameMinutes % 4 == 0 && gameMinutes != prevtime)
        {
          if (player.currState == "entertainment")
          {
              SEAttributesController.IncreaseMood(player);
              if(gameMinutes % 2 == 0 && ChangeTv.upgrade)
                SEAttributesController.IncreaseMood(player);
          }

          else if (player.currState == "working")
          {
              SEAttributesController.DecreaseMood(player);
              if (gameMinutes % 2 == 0)
              {
                  SEAttributesController.IncreaseTired(player);
                  if(gameMinutes % (6 - ChangeChair.upgrade) == 0)
                  {
                    SEAttributesController.DecreaseTired(player);
                  }
              }
          }

          else if (player.currState == "exercising")
          {
              SEAttributesController.IncreaseFitness(player);
              UnityEngine.Debug.Log("happening");
              if(AddItem.isTread && gameMinutes % 2 == 0)
              {
                SEAttributesController.IncreaseFitness(player);
              }
          }

          else if(player.currState == "sleeping")
          {
            SEAttributesController.Rest(player);
            SEAttributesController.IncreaseMood(player);
          }
        }
        //UnityEngine.Debug.Log(gameMinutes);
        if(gameMinutes % 25 == 0 && gameMinutes != prevtime)
        {
          //factor = ((double)player.Mood + player.Hunger + player.Tired + player.Fitness)/400;
          player.PlayerAge = player.PlayerAge + 1;
          SaveSEAttributes.SavePlayer(player);
          //UnityEngine.Debug.Log("worked" + player.PlayerAge);
          //UnityEngine.Debug.Log(factor);
        }
        prevtime = gameMinutes;
        CheckDeath(player);
    }
    public static void CheckDeath(SEAttributes player)
    {
      //death by lack of sleep, obesity, starvation and depression the 4 horsemen of engineering
      if(player.Tired == 0 || player.Fitness == 0 || player.Hunger == 0 || player.Mood == 0)
      {
        SceneManager.LoadScene("Death");
      }
    }
}
