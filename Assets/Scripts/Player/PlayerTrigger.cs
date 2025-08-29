using System;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public Action<int> OnCollect;

    private void OnTriggerEnter(Collider other)
    {
        var collectable = other.GetComponent<Collectable>();

        if (collectable != null)
        {
            OnCollect?.Invoke(collectable.GetMoneyValue());
            other.gameObject.SetActive(false);
        }
    }
}
