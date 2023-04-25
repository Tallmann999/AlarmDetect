using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _minVolume = 0f;
    [SerializeField] private float _maxVolume = 0.5f;
    [SerializeField] private float _fadeSpeed = 1f;

    private float _targetVolume;
    private Coroutine _activeCoroutine = null;

    public void IncreasesSound()
    {
        _targetVolume = _maxVolume;
        _audioSource.Play();

        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }

        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    public void ReducesSound()
    {
        _targetVolume = _minVolume;

        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }

        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _fadeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
