using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Data/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private float _baseSpeed = default;
    public float BaseSpeed => _baseSpeed;
}
