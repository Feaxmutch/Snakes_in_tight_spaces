using UnityEngine;

public class GameplayMaterials : BootstrapComponent<GameplayMaterials>
{
    [field : SerializeField] public StyleMaterials[] Styles { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }
}