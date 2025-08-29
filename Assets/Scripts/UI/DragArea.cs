using UnityEngine;
using UnityEngine.EventSystems;

public class DragArea : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    private Canvas _canvas;

    private PointerEventData _pointerEventData;

    private Vector2 _input;

    public float InputX { get => _input.x; }

    private void Update()
    {
        if (_pointerEventData != null)
            _input = _pointerEventData.delta / _canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _pointerEventData = eventData;
    }

    public void OnDrag(PointerEventData eventData) { }

    public void OnEndDrag(PointerEventData eventData)
    {
        _pointerEventData = null;
        _input = Vector2.zero;
    }
}
