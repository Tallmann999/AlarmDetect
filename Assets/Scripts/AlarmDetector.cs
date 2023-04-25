using UnityEngine;

[RequireComponent(typeof(Alarm))]
public class AlarmDetector : MonoBehaviour
{
    private Alarm _alarm;

    private void Start()
    {
        _alarm = GetComponent<Alarm>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover playerMover))
        {
            _alarm.IncreasesSound();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover playerMover))
        {
            _alarm.ReducesSound();
        }
    }
}
