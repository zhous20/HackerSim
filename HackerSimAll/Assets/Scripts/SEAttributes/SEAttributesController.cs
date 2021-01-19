using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEAttributesController
{

    public static void IncreaseMood(SEAttributes player) // SE gets happier when using entertainment
    {
        if(player.Mood < 100)
          player.Mood += 1;
        SaveSEAttributes.SavePlayer(player);
    }

    public static void DecreaseMood(SEAttributes player) // SE gets more sad when working
    {
        if(player.Mood > 0)
          player.Mood -= 1;
        SaveSEAttributes.SavePlayer(player);
    }

    public static void IncreaseTired(SEAttributes player) // SE gets more tired over time
    {
        if(player.Tired > 0)
          player.Tired -= 1;
        SaveSEAttributes.SavePlayer(player);
    }

    public static void DecreaseTired(SEAttributes player) // SE gets less tired
    {
        if(player.Tired < 100)
          player.Tired += 1;
        SaveSEAttributes.SavePlayer(player);
    }

    public static void Rest(SEAttributes player) // SE sleeps and is not tired
    {
        if(player.Tired <= 90)
          player.Tired += 10;
        else if(player.Tired > 90)
          player.Tired = 100;
        SaveSEAttributes.SavePlayer(player);
    }

    public static void IncreaseHunger(SEAttributes player) // SE gets more hungry over time
    {
        if(player.Hunger > 0)
          player.Hunger -= 1;
        SaveSEAttributes.SavePlayer(player);
    }

    public static void DecreaseHunger(SEAttributes player) // When SE eats
    {
        if(player.Hunger < 100)
          player.Hunger += 1;
        SaveSEAttributes.SavePlayer(player);
    }

    public static void IncreaseFitness(SEAttributes player) // When SE eats
    {
        if(player.Fitness < 100)
          player.Fitness += 1;
        SaveSEAttributes.SavePlayer(player);
    }

    public static void DecreaseFitness(SEAttributes player) // When SE eats
    {
        if(player.Fitness > 0)
          player.Fitness -= 1;
        SaveSEAttributes.SavePlayer(player);
    }

    public static void AdjustCurrency(SEAttributes player, double deltaCurrency) // When money is earned (+) or spent (-)
    {
        player.PlayerCurrency += deltaCurrency;
        SaveSEAttributes.SavePlayer(player);
    }
}
