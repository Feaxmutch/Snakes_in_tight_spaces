using UnityEngine;

public abstract class BootstrapComponent<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; protected set; }

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }

        DontDestroyOnLoad(this);
    }
}