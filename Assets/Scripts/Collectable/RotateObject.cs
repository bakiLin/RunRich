using DG.Tweening;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private Tween _tween;

    private void Start()
    {
        var rotation = transform.rotation.eulerAngles;
        rotation.y = 360f;
        _tween = transform
            .DORotate(rotation, 10f, RotateMode.FastBeyond360)
            .SetRelative()
            .SetEase(Ease.Linear)
            .SetLoops(-1);
    }

    private void OnDisable()
    {
        _tween.Kill();
    }
}
