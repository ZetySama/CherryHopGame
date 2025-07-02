using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
                if(collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);  // Platform ile temas halinde player platformun �ocu�u olur
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
               if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);     // temas� keserse platform parent olmaz, null olr
        }
    }
}
