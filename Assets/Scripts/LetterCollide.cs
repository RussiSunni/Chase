using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterCollide : MonoBehaviour
{
    [SerializeField]
    GameObject F, R, O, G;
    [SerializeField]
    AudioSource player;
    [SerializeField]
    AudioClip success;
    [SerializeField]
    AudioClip victory;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (gameObject.name == "f")
        {
            F.GetComponent<SpriteRenderer>().enabled = false;
            F.GetComponent<BoxCollider2D>().enabled = false;
            player.PlayOneShot(success);
        }
           
        else if (gameObject.name == "r")
        {
            if (!F.GetComponent<SpriteRenderer>().enabled)
            {
                R.GetComponent<SpriteRenderer>().enabled = false;
                R.GetComponent<BoxCollider2D>().enabled = false;
                player.PlayOneShot(success);
            }
        }
        else if (gameObject.name == "o")
        {
            if (!F.GetComponent<SpriteRenderer>().enabled && !R.GetComponent<SpriteRenderer>().enabled)
            {
                O.GetComponent<SpriteRenderer>().enabled = false;
                O.GetComponent<BoxCollider2D>().enabled = false;
                player.PlayOneShot(success);
            }
        }
        else if (gameObject.name == "g")
        {
            if (!F.GetComponent<SpriteRenderer>().enabled && !R.GetComponent<SpriteRenderer>().enabled && !O.GetComponent<SpriteRenderer>().enabled)
            {
                G.GetComponent<SpriteRenderer>().enabled = false;
                G.GetComponent<BoxCollider2D>().enabled = false;               
                player.PlayOneShot(victory);

                Chase.complete = true;
            }
        }
    }
}
