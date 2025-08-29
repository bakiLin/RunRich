using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;
using TMPro;
using System;

public class MoneyBar : MonoBehaviour
{
    [Inject]
    private PlayerTrigger _playerTrigger;

    [SerializeField]
    private Image _fill;

    [SerializeField]
    private TextMeshProUGUI _moneyText;

    [SerializeField]
    private int _maxValue, _startValue;

    [SerializeField]
    private float _changeTime;

    [SerializeField]
    private Gradient _gradient;

    private int _count;

    private Tween _tween;

    public Action<int, Color> OnChangeMoneyValue;

    private void OnEnable()
    {
        _playerTrigger.OnCollect += UpdateBar;
    }

    private void OnDisable()
    {
        _playerTrigger.OnCollect -= UpdateBar;
    }

    private void Start()
    {
        _fill.fillAmount = (float) _startValue / _maxValue;
        _fill.color = _gradient.Evaluate(_fill.fillAmount);
        _moneyText.text = _startValue.ToString();
        _count = _startValue;
        OnChangeMoneyValue?.Invoke(_count, _fill.color);
    }

    public void UpdateBar(int value)
    {
        _count += value;
        _moneyText.text = _count.ToString();
        _tween.Kill();

        var percent = (float)_count / _maxValue;
        _fill.color = _gradient.Evaluate(percent);
        _tween = _fill.DOFillAmount(percent, _changeTime);
        OnChangeMoneyValue?.Invoke(_count, _fill.color);
    }
}
