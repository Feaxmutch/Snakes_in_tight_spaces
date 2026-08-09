using Model;
using UnityEngine;

public abstract class BaseGridObjectRoot : MonoBehaviour
{
    public abstract GridObject BaseModel { get; }
    public abstract GridObjectV BaseView { get; }
    public abstract void Compose(byte styleId);
}
