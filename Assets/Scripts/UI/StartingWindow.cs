using DG.Tweening;
using UnityEngine;
using UnityEngine.Splines;

public class StartingWindow : MonoBehaviour
{
    [SerializeField]
    private SplineAnimate _playerSplineAnimate;

    [SerializeField]
    private float _elapsedTime;

    [SerializeField]
    private RectTransform _handTransform;

    [SerializeField]
    private float _handPositionX, _duration;

    private Sequence _sequence;

    private void Start()
    {
        _playerSplineAnimate.ElapsedTime = _elapsedTime;

        _sequence = DOTween.Sequence()
            .Append(_handTransform.DOAnchorPosX(_handPositionX, _duration))
            .Append(_handTransform.DOAnchorPosX(_handTransform.anchoredPosition.x, _duration))
            .SetLoops(-1);
    }

    public void StartGame()
    {
        _sequence.Kill();
        _handTransform.parent.gameObject.SetActive(false);
        _playerSplineAnimate.Play();
    }
}
