using Model;
using UnityEngine;
using ViewModel;

public class SnakeHeadV : EntityV
{
    [SerializeField] public SnakeBodyRootFactory _bodyFactory;
    
    private SnakeVM _vewModel;

    public void Initialize(SnakeVM viewModel)
    {
        _vewModel = viewModel;
        _vewModel.Growed += CreateBody;
        _vewModel.Rotation.Changed += UpdateRotation;
        Level.Started += CreateHat;
        UpdateRotation(_vewModel.Rotation.Value);
    }

    protected override void Subscribe()
    {
        base.Subscribe();

        if (IsInitialized)
        {
            _vewModel.Growed += CreateBody;
            Level.Started += CreateHat;
        }
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();

        if (IsInitialized)
        {
            _vewModel.Growed -= CreateBody;
            Level.Started -= CreateHat;
        }
    }

    private void CreateBody(SnakeBody body)
    {
        SnakeBodyRoot root = (SnakeBodyRoot)_bodyFactory.Create();
        root.SetForceGroopId(_vewModel.GroopId);
        root.SetSpeed(_vewModel.InterpolationSpeed);
        root.SetBody(body);
        root.Compose(ChapterId);
    }

    private void UpdateRotation(Quaternion quaternion)
    {
        transform.localRotation = quaternion;
    }

    private void CreateHat()
    {
        int hatID = PlayerProfileV.Instance.Profile.HatID;
        HatV hat = Instantiate(HatsSelector.Instance.GetPrefab(hatID), transform.position, transform.rotation);
        hat.transform.SetParent(transform);
    }
}