using UnityEngine;

public class AlarmComponent : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _minVolume = 0f;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _fadeSpeed = 1f;

    private AlarmDetector _detector;

    private void Start()
    {
        _detector = GetComponent<AlarmDetector>();
    }

    private void Update()
    {
        float targetVolume = _detector.IsTriggerDetect ? _maxVolume : _minVolume;
        float currentVolume = _audioSource.volume;
        _audioSource.volume = Mathf.MoveTowards(currentVolume, targetVolume, _fadeSpeed * Time.deltaTime);
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }
}
