using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChair : MonoBehaviour
{

  // can take of the animators
  // if you do not want to add the sparkle animation later
  private SpriteRenderer rend;
  private Sprite chair, chair2, chair3, chair4, chair5;
  private Animator animator;
  public static Sprite[] chairs;
  public static int upgrade;

  // Start is called before the first frame update
  void Start()
  {
      animator = GetComponent<Animator>();
      rend = GetComponent<SpriteRenderer>();
      chair = Resources.Load<Sprite>("chair");
      chair2 = Resources.Load<Sprite>("chair2");
      chair3 = Resources.Load<Sprite>("chair3");
      chair4 = Resources.Load<Sprite>("chair4");
      chair5 = Resources.Load<Sprite>("chair5");
      chairs = new Sprite[5] {chair, chair2, chair3, chair4, chair5};

      rend.sprite = chair;
      if(upgrade < 5 && upgrade >= 0)
      {
        rend.sprite = chairs[upgrade];
      }

      //move to update later on when you have a condition that isnt public

  }

  // Update is called once per frame
  void Update()
  {
  }
}
