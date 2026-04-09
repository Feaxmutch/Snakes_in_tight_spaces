using UnityEngine;

public class GameplayColors : BootstrapComponent<GameplayColors>
{
    [field : SerializeField] public ColorPack ColorPack { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }
}