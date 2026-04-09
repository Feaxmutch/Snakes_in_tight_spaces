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
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        if (IsInitialized)
        {
            _vewModel.Growed -= CreateBody;
        }
    }

    public void Initialize(SnakeVM viewModel)
    {
        base.Initialize(viewModel);
        _vewModel = viewModel;
        _vewModel.Growed += CreateBody;
        _vewModel.Rotation.Changed += UpdateRotation;
        UpdateRotation(_vewModel.Rotation.Value);
    }

    private void CreateBody(SnakeBody body)
    {
        SnakeBodyRoot root = (SnakeBodyRoot)_bodyFactory.Create();
        root.Compose(body, _vewModel.InterpolationSpeed, _vewModel.Color.Value, _updateBroadcaster);
    }

    private void UpdateRotation(Quaternion quaternion)
    {
        transform.localRotation = quaternion;
    }
}