using UnityEngine;
using Zenject;

public class PlayerParticle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _goodParticle, _badParticle;

    private PlayerTrigger _playerTrigger;

    private void Awake()
    {
        _playerTrigger = GetComponent<PlayerTrigger>();
    }

    private void OnEnable()
    {
        _playerTrigger.OnCollect += PlayParticle;
    }

    private void OnDisable()
    {
        _playerTrigger.OnCollect -= PlayParticle;
    }

    private void PlayParticle(int moneyValue)
    {
        if (moneyValue > 0) _goodParticle.Play();
        else _badParticle.Play();
    }
}
