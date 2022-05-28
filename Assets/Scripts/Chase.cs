using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float stoppingDistance;
    private Transform target;
    [SerializeField]
    AudioClip artemisHey;
    [SerializeField]
    AudioSource audioSource;
    private bool audioPlaying;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            // make animal face the correct direction
            if (transform.position.x < target.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            // play sound effect if catch player
            if (!audioPlaying)
            {
                audioPlaying = true;
                audioSource.PlayOneShot(artemisHey);
            }
        }

        // make animal sprite behind or in front of player
        if (transform.position.y < target.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 3;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = 1;
        }

        // only allow for new audio after a mouse click
        if (Input.GetMouseButtonDown(0))
            audioPlaying = false;
    }
}
