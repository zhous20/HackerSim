using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Project
{
    //private string name;
    private int id;
    private int currency_award;
    private int exp_award;
    private string desc;
    private int deadline;
    private int comptime;
    private bool completion;

   
    public Project(int ID, int currency, int experience, int Deadline)
    {
        id = ID; 
        currency_award = currency;
        exp_award = experience;
        deadline = Deadline;
        comptime = Convert.ToInt32(0.6 * currency_award + 0.4 * exp_award);
        desc = "Project " + id + ": +" + currency_award + " Currency; +" + exp_award 
            + " Experience; " + compTime+ " Minutes Needed ;" + deadline + " Hours Left ";
        completion = false;
    }
    /*public string Name
    {
        get { return name; }
        set { name = value; }
    }*/


    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public int Currency
    {
        get { return currency_award; }
    }

    public int Exp
    {
        get { return exp_award; }
    }

    public string Desc
    {
        get { return desc; }
    }

    public void resetDesc()
    {
        desc = "Project " + id + ": +" + currency_award + " Currency; +" + exp_award
            + " Experience; " + compTime + " Minutes Needed ;" + deadline + " Hours Left ";
    }

    public int Deadline
    {
        get { return deadline; }
    }

    public void deadlineMinusOne()
    {
        deadline -= 1;
    }

    public int compTime
    {
        get { return comptime; }
        
    }

    public void comptimeMinusOne()
    {
        comptime -= 1;
    }

    public void resetComptime()
    {
        comptime = Convert.ToInt32(0.6 * currency_award + 0.4 * exp_award);
    }



    public bool Completion
    {
        get { return completion; }
        set { completion = value; }
    }
}
