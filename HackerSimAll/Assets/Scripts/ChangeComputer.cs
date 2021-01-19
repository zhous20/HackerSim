using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeComputer : MonoBehaviour
{
    // can take of the animators
    // if you do not want to add the sparkle animation later
    private SpriteRenderer rend;
    private Sprite oldComp, newComp;
    private Animator animator;
    public static bool upgrade;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        oldComp = Resources.Load<Sprite>("oldComp");
        newComp = Resources.Load<Sprite>("newComp");

        rend.sprite = oldComp;

        //move to update later on when you have a condition that isnt public
        if(upgrade == true)
        {
          rend.sprite = newComp;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
