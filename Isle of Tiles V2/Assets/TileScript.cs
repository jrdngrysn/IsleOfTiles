using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public string color;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(1, 5);

        if (rand == 1)
        {
            color = "blue";
            gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        else if (rand == 2)
        {
            color = "red";
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        } else if (rand == 3)
        {
            color = "yellow";
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        } else if (rand == 4)
        {
            color = "green";
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
