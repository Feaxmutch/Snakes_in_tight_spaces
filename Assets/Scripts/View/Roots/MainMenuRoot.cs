using UnityEngine;

public class MainMenuRoot : MonoBehaviour
{
    [SerializeField] private MenuRoot _menuRoot;

    private void Start()
    {
        _menuRoot.Compose();
    }
}