using UnityEngine;
using ViewModel;
using Model;
using System.Collections.Generic;

public class MenuRoot : MonoBehaviour
{
    [SerializeField] private DefaultWindowRoot[] _roots;

    private void Start()
    {
        Compose();
    }

    private void Compose()
    {
        MenuVM menuVM = new();
        List<IWindowVM> windowsViewModels = new();

        foreach (var root in _roots)
        {
            root.Compose();
            windowsViewModels.Add(root.ViewModel);
        }

        menuVM.Initialize(windowsViewModels.ToArray());
    }
}