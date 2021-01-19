using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    private SpriteRenderer rend;
    private Sprite boy, girl;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        boy = Resources.Load<Sprite>("boy");
        girl = Resources.Load<Sprite>("girl");

        SEAttributes player = SaveSEAttributes.LoadPlayer();

        if(player.PlayerGender == "male")
        {
          rend.sprite = boy;
          animator.SetBool("isMale", true);
        }
        else if(player.PlayerGender == "female")
        {
          rend.sprite = girl;
          animator.SetBool("isMale", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
