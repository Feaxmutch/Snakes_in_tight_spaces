using UnityEngine;
using ViewModel;

public class DefaultWindowV : WindowV
{
    private RectTransform _rectTransform;
    private DefaultWindowVM _viewModel;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void Init(DefaultWindowVM viewModel)
    {
        _viewModel = viewModel;
        _viewModel.PositionY.Changed += OnPositionChanged;
        OnPositionChanged(_viewModel.PositionY.Value);
    }

    private void OnPositionChanged(float yPosition)
    {
        float xPosition = _rectTransform.anchoredPosition.x;
        _rectTransform.anchoredPosition = new Vector2(xPosition, yPosition);
    }
}