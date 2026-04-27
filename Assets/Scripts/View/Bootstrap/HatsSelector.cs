using UnityEngine;

public class HatsSelector : BootstrapComponent<HatsSelector>
{
    [SerializeField] private HatsList _hatsList;

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    public HatV GetPrefab(int ID)
    {
        return _hatsList.Hats[ID];
    }
}