using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

public class MoneyPopUp : MonoBehaviour
{
    [Inject]
    private PlayerTrigger _playerTrigger;

    [SerializeField]
    private RectTransform _incTextTransform, _decTextTransform;

    [SerializeField]
    private float _height, _duration;

    private TextMeshProUGUI _incText, _decText;

    private Vector2 _incStartPosition, _decStartPosition;

    private Tween _incTween, _decTween;

    private int _incCurrent, _decCurrent;

    private void Awake()
    {
        _incText = _incTextTransform.GetComponent<TextMeshProUGUI>();
        _decText = _decTextTransform.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _incStartPosition = _incTextTransform.anchoredPosition;
        _decStartPosition = _decTextTransform.anchoredPosition;
    }

    private void OnEnable()
    {
        _playerTrigger.OnCollect += Trigger;
    }

    private void OnDisable()
    {
        _playerTrigger.OnCollect -= Trigger;
    }

    private void Trigger(int value)
    {
        if (value > 0)
            PopUp(value, ref _incTween, ref _incCurrent, ref _incTextTransform, _incStartPosition, ref _incText);
        else
            PopUp(value, ref _decTween, ref _decCurrent, ref _decTextTransform, _decStartPosition, ref _decText);
    }

    private void PopUp(int moneyValue, ref Tween tween, ref int currentValue, 
        ref RectTransform popUp, Vector2 startPos, ref TextMeshProUGUI textMesh)
    {
        tween.Kill();
        currentValue += moneyValue;
        popUp.gameObject.SetActive(true);
        popUp.anchoredPosition = startPos;

        if (moneyValue > 0)
        {
            textMesh.text = $"+ {currentValue} $";
            _incTween = _incTextTransform.DOAnchorPosY(_incStartPosition.y + _height, _duration)
                .OnComplete(() => {
                    _incTextTransform.gameObject.SetActive(false);
                    _incCurrent = 0;
                });
        }
        else
        {
            textMesh.text = $"{currentValue} $";
            _decTween = _decTextTransform.DOAnchorPosY(_decStartPosition.y + _height, _duration)
                .OnComplete(() => {
                    _decTextTransform.gameObject.SetActive(false);
                    _decCurrent = 0;
                });
        }
    }
}
