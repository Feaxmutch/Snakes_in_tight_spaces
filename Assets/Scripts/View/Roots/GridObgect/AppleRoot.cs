using Model;
using ViewModel;
using System;
using UnityEngine;
using Color = Other.Color;

public class AppleRoot : ColoredObjectRoot<Apple, AppleVM, AppleV>
{
    [field : SerializeField] public  AppleRoot Locker { get; private set; }

    protected override void InitModel()
    {
        base.InitModel();

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

    protected override void InitViewModel()
    {
        base.InitViewModel();
        ViewModel.Initialize(Model);
    }
}