using UnityEngine;
using UnityEngine.Serialization;

namespace Enemies
{
    [CreateAssetMenu(fileName = "NewShipStats", menuName = "ShipStats / New Ship Stats", order = 0)]
    public class ShipStats : ScriptableObject
    {
        [SerializeField] public string shipName;
        [SerializeField] public int health;
        [SerializeField] public int score;
    }
}