using System.Collections;
using UnityEngine;

public class DoorToggle : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _doorOpen;

    private float _waitingTime = 0.2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover playerMover))
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
