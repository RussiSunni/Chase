using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
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
            if (!audioPlaying)
                StartCoroutine(PlayAudio());
        }
    }
    private IEnumerator PlayAudio()
    {
        audioPlaying = true;
        audioSource.PlayOneShot(artemisHey);
        yield return new WaitForSeconds(1);
        audioPlaying = false;
    }
}
