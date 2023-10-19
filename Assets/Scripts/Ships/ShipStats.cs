using UnityEngine;

namespace Ships
{
    [CreateAssetMenu(fileName = "NewShipStats", menuName = "My Objects/Ship Stats", order = 0)]
    public class ShipStats : ScriptableObject
    {
        [SerializeField] public string shipName;
        [SerializeField] public int health;
        [SerializeField] public int score;
    }
}