using UnityEngine;
using ViewModel;

public abstract class BaseWindowRoot : MonoBehaviour
{
    public abstract IWindowVM BaseViewModel { get; }

    public abstract void Compose();
}