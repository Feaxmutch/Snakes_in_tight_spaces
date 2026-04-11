using ViewModel;

public class StartEvent : GlobalEvent
{
    private LevelBroadcaster _broadcaster;

    private void Awake()
    {
        _broadcaster = new();
        _broadcaster.Initialize();
    }

    private void OnEnable()
    {
        _broadcaster.Started += OnInvoke;
    }

    private void OnDisable()
    {
        _broadcaster.Started -= OnInvoke;
    }
}