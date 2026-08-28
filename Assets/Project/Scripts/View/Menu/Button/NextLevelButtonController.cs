using UnityEngine;

public class NextLevelButtonController : MonoBehaviour
{
    [SerializeField] private ButtonV _button;

    private void OnEnable()
    {
        LevelSelector.Instance.LevelChanged += UpdateButtonState;
        UpdateButtonState();
    }

    private void OnDisable()
    {
        LevelSelector.Instance.LevelChanged -= UpdateButtonState;
    }

    private void UpdateButtonState()
    {
        bool isIteractable = LevelSelector.Instance.IsLastLevel == false;
        _button.SetInteractable(isIteractable);
    }
}