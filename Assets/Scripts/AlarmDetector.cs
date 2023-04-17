using UnityEngine;

[RequireComponent(typeof(AlarmComponent))]
public class AlarmDetector : MonoBehaviour
{
    private AlarmComponent _alarmComponent;

    public bool IsTriggerDetect { get; private set; }

    private void Start()
    {
        _alarmComponent = GetComponent<AlarmComponent>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover playerMover))
        {
            IsTriggerDetect = true;
            _alarmComponent.PlaySound();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover playerMover))
        {
            IsTriggerDetect = false;
            _alarmComponent.PlaySound();
        }
    }
}
