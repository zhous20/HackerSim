using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTv : MonoBehaviour
{
  // can take of the animators
  // if you do not want to add the sparkle animation later
  private SpriteRenderer rend;
  private Sprite oldTv, newTv;
  private Animator animator;
  public static bool upgrade = false;

  // Start is called before the first frame update
  void Start()
  {
      animator = GetComponent<Animator>();
      rend = GetComponent<SpriteRenderer>();
      oldTv = Resources.Load<Sprite>("oldTv");
      newTv = Resources.Load<Sprite>("newTv");

      rend.sprite = oldTv;

      //move to update later on when you have a condition that isnt public
      if(upgrade == true)
      {
        rend.sprite = newTv;
      }
  }

  // Update is called once per frame
  void Update()
  {
  }
}
