using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
  // can take of the animators
  // if you do not want to add the sparkle animation later
  private SpriteRenderer rend;
  private Sprite plant, tree, tread;
  private Animator animator;
  private BoxCollider2D myCollide;
  public static bool bought = false;
  public static bool isTree = false;
  public static bool isPlant = false;
  public static bool isTread = false;

  // Start is called before the first frame update
  void Start()
  {
      animator = GetComponent<Animator>();
      rend = GetComponent<SpriteRenderer>();
      plant = Resources.Load<Sprite>("plant");
      tree = Resources.Load<Sprite>("tree");
      tread = Resources.Load<Sprite>("tread");
      myCollide = GetComponent<BoxCollider2D>();

      myCollide.enabled = !myCollide.enabled;

      //move to update later on when you have a condition that isnt public
      // if(bought == true)
      // {
      //   rend.sprite = plant;
      //   myCollide.enabled = !myCollide.enabled;
      // }
  }
    // Update is called once per frame
    void Update()
    {
      if(bought == true)
      {
        if(isTree && myCollide.CompareTag("tree"))
        {
          rend.sprite = tree;
          myCollide.enabled = true;
        }

        if(isPlant && myCollide.CompareTag("plant"))
        {
          rend.sprite = plant;
          myCollide.enabled = true;
        }

        if(isTread && myCollide.CompareTag("tread"))
        {
          rend.sprite = tread;
          myCollide.enabled = true;
        }
      }
    }
}
