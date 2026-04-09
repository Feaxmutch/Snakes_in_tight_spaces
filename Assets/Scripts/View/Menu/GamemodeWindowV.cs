using ViewModel;
using UnityEngine;
using TMPro;

public class GamemodeWindowV : DefaultWindowV
{
    [SerializeField] private TextMeshProUGUI _timerText;

    private GamemodeWindowVM _viewModel;

    public void Initialize(GamemodeWindowVM viewModel)
    {
        base.Initialize(viewModel);
        _viewModel = viewModel;
        _viewModel.TimerText.Changed += UpdateText;
    }

    private void UpdateText(string actualText)
    {
        _timerText.text = actualText;
    }
}