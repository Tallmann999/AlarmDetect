using UnityEngine;

public class AlarmComponent : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _minVolume = 0f;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _fadeSpeed = 1f;

    private bool _isPlayerInsideTrigger = false;

    private void Update()
    {
        float targetVolume = _isPlayerInsideTrigger ? _maxVolume : _minVolume;
        float currentVolume = _audioSource.volume;
        _audioSource.volume = Mathf.MoveTowards(currentVolume, targetVolume, _fadeSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _audioSource.Play();
            _isPlayerInsideTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _audioSource.Play();
            _isPlayerInsideTrigger = false;
        }
    }
}
