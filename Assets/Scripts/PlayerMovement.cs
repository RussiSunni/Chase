using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    public static Vector2 lastClickedPosition;
    bool moving;
    [SerializeField]
    AudioClip barrier;
    [SerializeField]
    AudioSource audioSource;
    private bool audioPlaying;
    private Transform animal;

    private void Start()
    {
        animal = GameObject.FindGameObjectWithTag("Animal").GetComponent<Transform>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastClickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
            audioPlaying = false;
        }

        if (moving && (Vector2)transform.position != lastClickedPosition)
        {
            // check that mouse click is within the screen bounds
            if (lastClickedPosition.x > -7 && lastClickedPosition.x < 7
                && lastClickedPosition.y > -4 && lastClickedPosition.y < 4)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, lastClickedPosition, step);
            }
            else
            {
                // play sound effect if mouse clicks on barrier at edge of screen
                if (!audioPlaying)
                {
                    audioPlaying = true;
                    audioSource.PlayOneShot(barrier);
                }
            }
        }
        else
        {
            moving = false;
        }
    }
}
