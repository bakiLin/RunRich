using DG.Tweening;
using UnityEngine;

public class FlagTrigger : MonoBehaviour
{
    [SerializeField]
    private Transform[] _flags;

    private void OnTriggerEnter(Collider other)
    {
        foreach (var item in _flags)
        {
            var rotation = item.localRotation.eulerAngles;
            rotation.z = 0f;
            item.DOLocalRotate(rotation, 1f);
        }
    }
}
