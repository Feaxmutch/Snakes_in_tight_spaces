using UnityEngine;

public class GameplayMaterials : BootstrapComponent<GameplayMaterials>
{
    [field : SerializeField] public ChapterMaterials[] Chapters { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }
}