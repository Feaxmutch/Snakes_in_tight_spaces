using UnityEngine;
using ViewModel;
using Model;
using System.Collections.Generic;

public class MenuRoot : MonoBehaviour
{
    [SerializeField] private DefaultWindowRoot[] _roots;

    private DefaultWindowRoot[] _additionalWindows;

    public void Compose()
    {
        MenuVM menuVM = new();
        List<IWindowVM> windowsViewModels = new();

        foreach (var root in _roots)
        {
            root.Compose();
            windowsViewModels.Add(root.ViewModel);
        }

        if (_additionalWindows != null)
        {
            foreach (var root in _additionalWindows)
            {
                root.Compose();
                windowsViewModels.Add(root.ViewModel);
            }
        }

        menuVM.Initialize(windowsViewModels.ToArray());
    }

    public void SetAdditionalWindows(DefaultWindowRoot[] windows)
    {
        _additionalWindows = windows;
    }
}