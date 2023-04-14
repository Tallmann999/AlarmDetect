using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class FootSteps : MonoBehaviour
{
    private PlayerMover _playerMover;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _footSteps;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    public void PlayOneShootStep()
    {
        if (_playerMover.Direction == Vector2.zero)
        {
            _audioSource.Stop();
        }
        else
        {
            _audioSource.clip = _footSteps[Random.Range(0, _footSteps.Length)];
            _audioSource.Play();
        }
    }
}
