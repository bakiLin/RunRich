using TMPro;
using UnityEngine;
using Zenject;

public class StatusManager : MonoBehaviour
{
    [Inject]
    private MoneyBar _moneyBar;

    [SerializeField]
    private TextMeshProUGUI _statusText;

    [SerializeField]
    private GameObject[] _player;

    [SerializeField]
    private string[] _statusTitle;

    private int _statusId, _prevStatusId = -1;

    private void OnEnable()
    {
        _moneyBar.OnChangeMoneyValue += ChangeStatus;
    }

    private void OnDisable()
    {
        _moneyBar.OnChangeMoneyValue -= ChangeStatus;
    }

    private void ChangeStatus(int moneyValue, Color color)
    {
        switch (moneyValue)
        {
            case < 30:
                _statusId = 0; 
                break;
            case < 60:
                _statusId = 1;
                break;
            case < 100:
                _statusId = 2;
                break;
            case < 150:
                _statusId = 3;
                break;
        }

        if (_prevStatusId != _statusId || _prevStatusId < 0)
        {
            _statusText.text = _statusTitle[_statusId];
            _statusText.color = color;

            if (_prevStatusId >= 0)
                _player[_prevStatusId].SetActive(false);
            _player[_statusId].SetActive(true);

            _prevStatusId = _statusId;
        }
    }
}
