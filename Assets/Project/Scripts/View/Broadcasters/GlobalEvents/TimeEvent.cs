using UnityEngine;

public class TimeEvent : GlobalEvent
{
    [SerializeField] private float _triggerTime;

    private float _time;
    private bool _invoked;

    void Awake()
    {
        _invoked = false;
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _triggerTime && _invoked == false)
        {
            OnInvoke();
            _invoked = true;
        }
    }
}