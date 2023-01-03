using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MovingLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Button _button;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _mover;

    private bool _isHold;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        _isHold = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        _isHold = false;
    }    
    
    private void Update()
    {
        if (_isHold)
            _mover.MoveLeft();
    }
}
