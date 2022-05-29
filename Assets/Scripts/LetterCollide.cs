using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterCollide : MonoBehaviour
{
    [SerializeField]
    GameObject F, R, O, G;
    
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
