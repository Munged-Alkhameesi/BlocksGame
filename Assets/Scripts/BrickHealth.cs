using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BrickHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    private void OnValidate()
    {
        gameObject.GetComponent<SpriteRenderer>().color = colorHealth[health - 1];

    }

    public List<Color> colorHealth = new List<Color>()
        {
        Color.green,
        Color.blue,
       Color.red, 
       Color.yellow
    };
    
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = colorHealth[health - 1];

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
                PlayerMovement.score++;
            }else
            {
                gameObject.GetComponent<SpriteRenderer>().color = colorHealth[health - 1];
            }
        }
    }
}