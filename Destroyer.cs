using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        //If the object that triggered the event, is tagged player
        if (collider2D.tag == "Player")
        {
            Debug.Break();
            return;
        }

        if (collider2D.gameObject.transform.parent)
        {
            Destroy(collider2D.gameObject.transform.parent.gameObject);
        } else
        {
            Destroy(collider2D.gameObject);
        }
    }
}
