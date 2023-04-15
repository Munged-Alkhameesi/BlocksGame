using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
   
    private TextMeshProUGUI textComp;
    private int currentScore = 0;
    string x;
    // Start is called before the first frame update
    void Start()
    {
        textComp = gameObject.GetComponent<TextMeshProUGUI>();
        x = textComp.text;
    }

    // Update is called once per frame
    void Update()
    {
        if( currentScore != PlayerMovement.score)
        {
            textComp.text = x + PlayerMovement.score;
            currentScore = PlayerMovement.score;
        }
    }
    
}
