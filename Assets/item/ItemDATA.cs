using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Slot Machine/item")]
public class ItemDATA : ScriptableObject
{
    public int id;
    public Sprite sprite;
    public float payout;
}