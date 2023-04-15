using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    public bool auto = false;
    
    GameObject blocks;
    public static int count = 0;
    public static int score = 0;
    void Start()
    {
        blocks = GameObject.Find("Bricks");
        foreach (Transform blockwall in blocks.transform)
        {
            count += blockwall.childCount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (auto)
        {
            Auto();
        }
        else
        {
            float translation = Input.GetAxis("Horizontal") * speed;

            transform.Translate(translation * Time.deltaTime, 0, 0);
        }
    }
    void Auto()
    {
        var offset =  BallPhysics.go.transform.position.x- transform.position.x;
        if (offset > 0.9 || offset < -0.9)
        {
            transform.Translate(offset * Time.deltaTime * speed, 0, 0);
        }
    }
}
