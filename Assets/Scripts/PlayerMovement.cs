using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    Vector2 lastClickedPosition;
    bool moving;
    [SerializeField]
    AudioClip barrier;
    [SerializeField]
    AudioSource audioSource;
    private bool audioPlaying;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastClickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }

        if (moving && (Vector2)transform.position != lastClickedPosition)
        {
            if(lastClickedPosition.x > -7 && lastClickedPosition.x < 7
                && lastClickedPosition.y > -4 && lastClickedPosition.y < 4)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, lastClickedPosition, step);
            }
            else
            {
                // play sound
                if (!audioPlaying)
                StartCoroutine(PlayAudio());
            }            
        }
        else
        {
            moving = false;
        }
    }

    private IEnumerator PlayAudio()
    {
        audioPlaying = true;
        audioSource.PlayOneShot(barrier);
        yield return new WaitForSeconds(1);
        audioPlaying = false;
    }
}
