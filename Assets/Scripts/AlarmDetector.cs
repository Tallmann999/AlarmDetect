using UnityEngine;

[RequireComponent(typeof(Alarm))]
public class AlarmDetector : MonoBehaviour
{
    private Alarm _alarmComponent;

    private void Start()
    {
        _alarmComponent = GetComponent<Alarm>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover playerMover))
        {
            _alarmComponent.PlaySound();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover playerMover))
        {
            _alarmComponent.StopSound();
        }
    }
}
