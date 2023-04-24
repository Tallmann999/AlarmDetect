using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AlarmDetector))]
public class AlarmComponent : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _minVolume = 0f;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _fadeSpeed = 1f;

    private float _targetVolume;
    private Coroutine _coroutine;

    public void PlaySound()
    {
        _targetVolume = 0.5f;
        _audioSource.Play();
        _coroutine = StartCoroutine(ChangeVolume());
    }

    public void StopSound()
    {
        _targetVolume = 0f;
        StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(ChangeVolume());
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
