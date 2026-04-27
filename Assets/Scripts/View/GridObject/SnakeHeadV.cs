using Model;
using UnityEngine;
using ViewModel;

public class SnakeHeadV : ColoredObjectV
{
    [SerializeField] public SnakeBodyRootFactory _bodyFactory;
    [SerializeField] public UpdateBroadcaster _updateBroadcaster;
    
    private SnakeVM _vewModel;

    protected override void OnEnable()
    {
        base.OnEnable();

        if (IsInitialized)
        {
            _vewModel.Growed += CreateBody;
            Level.Started += CreateHat;
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        if (IsInitialized)
        {
            _vewModel.Growed -= CreateBody;
            Level.Started -= CreateHat;
        }
    }

    public void Initialize(SnakeVM viewModel)
    {
        _vewModel = viewModel;
        _vewModel.Growed += CreateBody;
        _vewModel.Rotation.Changed += UpdateRotation;
        Level.Started += CreateHat;
        UpdateRotation(_vewModel.Rotation.Value);
    }

    private void CreateBody(SnakeBody body)
    {
        SnakeBodyRoot root = (SnakeBodyRoot)_bodyFactory.Create();
        root.SetForceColor(_vewModel.Color.Value);
        root.SetSpeed(_vewModel.InterpolationSpeed);
        root.SetBody(body);
        root.Compose();
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