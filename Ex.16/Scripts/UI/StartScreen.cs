using UnityEngine;
using UnityEngine.Events;

public class StartScreen : Screen
{
    [SerializeField] private CanvasGroup _shop;
    [SerializeField] private GameObject _hint;

    public event UnityAction PlayButtonClick;

    public override void Close()
    {
        _shop.alpha = 0;
        CanvasGroup.alpha = 0;
        Button.interactable = false;
        _hint.SetActive(false);
    }

    public override void Open()
    {
        _shop.alpha = 1;
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    protected override void OnButtonClick()
    {
        PlayButtonClick?.Invoke();
    }
}
