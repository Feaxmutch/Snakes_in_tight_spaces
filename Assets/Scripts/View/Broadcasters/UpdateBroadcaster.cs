using System;
using UnityEngine;
using ViewModel;

public class UpdateBroadcaster : MonoBehaviour, IUnityUpdate
{
    public event Action<float> Updated;

    private void Update()
    {
        Updated?.Invoke(Time.deltaTime);
    }
}