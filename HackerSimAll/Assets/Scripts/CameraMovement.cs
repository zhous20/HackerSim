using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform SE;
    public float smoothing;
    public Vector2 maxPos; // (0.34, 1.01)
    public Vector2 minPos; // (-0.25, 0.93)
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    // fixed whenever physics system is set to tic
    // late always goes last
    void LateUpdate()
    {
        if(transform.position != SE.position)
        {
          Vector3 targetPos = new Vector3(SE.position.x, SE.position.y, transform.position.z);

          targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
          targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

          transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);


        }
    }
}
