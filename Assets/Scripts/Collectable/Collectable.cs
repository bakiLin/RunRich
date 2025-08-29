using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private CollectableScriptableObject _scriptableObject;

    public int GetMoneyValue()
    {
        return _scriptableObject.MoneyValue;
    }
}
