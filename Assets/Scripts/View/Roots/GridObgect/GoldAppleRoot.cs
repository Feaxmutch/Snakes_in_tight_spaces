using Model;
using System;
using UnityEngine;
using ViewModel;
using Color = Other.Color;

public class GoldAppleRoot : ColoredObjectRoot<GoldApple, AppleVM, GoldAppleV>
{
    [field: SerializeField] public AppleRoot Locker { get; private set; }

    public override void Compose()
    {
        CreateModel();
        CreateViewModel();
        InitializeView();
    }

    protected override void CreateModel()
    {
        base.CreateModel();

        if (Locker == null)
        {
            Model.Initialize();
            return;
        }

        if (Locker.View.IsInitialized == false)
        {
            if (Locker.View == View)
            {
                throw new Exception("Rekurcion detected. Locker locked by thef locker.");
            }

            Locker.Compose();
        }

        Model.Initialize(Locker.Model);
    }

    protected override void CreateViewModel(GoldApple model = null)
    {
        ViewModel = new();

        if (model != null)
        {
            Model = model;
        }

        Color color = Color.ConvertFromUnity(GameplayColors.Instance.ColorPack.Colors[ColorIndex]);
        ViewModel.Initialize(color, Model);
    }

    protected override void InitializeView(AppleVM viewModel = null)
    {
        if (viewModel != null)
        {
            ViewModel = viewModel;
        }

        View.Initialize(ViewModel);
    }
}