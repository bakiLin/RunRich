using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [Inject]
    private DragArea _dragArea;

    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private float _limitX;

    private Vector3 _movement;

    private void Update()
    {
        _movement = transform.localPosition;
        _movement.x += _dragArea.InputX * _moveSpeed * Time.deltaTime;
        _movement.x = Mathf.Clamp(_movement.x, -_limitX, _limitX);
        transform.localPosition = _movement;
    }
}
