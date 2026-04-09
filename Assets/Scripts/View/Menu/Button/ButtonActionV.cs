using UnityEngine;
using ViewModel;

public abstract class ButtonActionV : MonoBehaviour, IButtonAction
{
    public abstract void Perform();
}