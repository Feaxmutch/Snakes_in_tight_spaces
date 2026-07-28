using Other;
using ViewModel;

public class AppleV : EntityV
{
    private AppleVM _viewModel;

    public void Initialize(AppleVM viewModel)
    {
        _viewModel = viewModel;
        _viewModel.IsLocked.Changed += SetStateMaterial;
        SetStateMaterial(_viewModel.IsLocked.Value);
    }

    protected override void Subscribe()
    {
        base.Subscribe();

        if (IsInitialized)
        {
            _viewModel.IsLocked.Changed += SetStateMaterial;
            SetStateMaterial(_viewModel.IsLocked.Value);
        }
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();

        if (IsInitialized)
        {
            _viewModel.IsLocked.Changed -= SetStateMaterial;
        }
    }
    
    private void SetStateMaterial(bool isLocked)
    {
        if (isLocked)
        {
            SetMaterial(Materials.LockedApple);
        }
        else
        {
            SetDefaultMaterial();
        }
    }
}