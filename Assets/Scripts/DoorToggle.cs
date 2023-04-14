using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToggle : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _doorOpen;
    private float _waitingTime = 0.2f;

    private void Start()
    {
        _audioSource.GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(PlaySoundAndDisable());
        }
    }

    private IEnumerator PlaySoundAndDisable()
    {
        _audioSource.clip = _doorOpen;
        _audioSource.Play();
        yield return new WaitForSeconds(_waitingTime);
        gameObject.SetActive(false);
    }
}
