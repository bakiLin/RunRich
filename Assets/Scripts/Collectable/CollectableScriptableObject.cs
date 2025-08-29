using UnityEngine;

[CreateAssetMenu(fileName = "CollectableScriptableObject", menuName = "ScriptableObject/Collectable")]
public class CollectableScriptableObject : ScriptableObject
{
    public string ItemName;

    public int MoneyValue;
}
