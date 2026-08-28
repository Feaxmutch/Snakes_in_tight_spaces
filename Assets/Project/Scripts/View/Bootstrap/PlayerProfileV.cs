using Model;
using UnityEngine;
public class PlayerProfileV : BootstrapComponent<PlayerProfileV>
{
    [SerializeField] private ProfileSnapshot _profileSnapshot;

    private PlayerProfile _profile;

    public IPlayerProfile Profile => _profile;

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
        _profile = new(_profileSnapshot.Name);
        _profile.SetHat(_profileSnapshot.HatID);
    }
}