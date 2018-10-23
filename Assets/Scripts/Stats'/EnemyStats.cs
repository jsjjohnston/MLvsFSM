using UnityEngine;

/// <summary>
/// Stats associated with enemies  
/// </summary>
[CreateAssetMenu(menuName = "StateMachine/Stats/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    /// <summary>
    /// Maximum Amount of health the enemy can have
    /// </summary>
    public float maxHealth = 50;

    /// <summary>
    /// How much health the enemy starts with
    /// </summary>
    public float startHealth = 50;

    /// <summary>
    /// How quicklt enemy goes over the nav mesh
    /// </summary>
    public float speed = 2;
}
