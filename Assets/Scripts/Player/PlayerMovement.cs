using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [Inject]
    private DragArea _dragArea;

    [SerializeField]
    private float _moveSpeed;

    private float _movementX;

    private void Update()
    {
        _movementX = _dragArea.InputX * _moveSpeed * Time.deltaTime;
        transform.localPosition += new Vector3(_movementX, 0f);
    }
}
