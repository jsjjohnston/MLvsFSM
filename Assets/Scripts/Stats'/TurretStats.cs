using UnityEngine;

/// <summary>
/// Configuration Stats For Turret
/// </summary>
[CreateAssetMenu (menuName = "StateMachine/Stats/Turret Stats")]
public class TurretStats : ScriptableObject {

    /// <summary>
    /// Look Range of Turret
    /// </summary>
    public float lookRange = 40f;

    /// <summary>
    /// Look Sphere Cast Radius
    /// </summary>
    public float lookSphereCastRadius = 1f;

    /// <summary>
    /// Range Of The Attack
    /// </summary>
    public float attackRange = 1f;

    /// <summary>
    /// Rate Of The Attack
    /// </summary>
    public float attackRate = 1f;

    /// <summary>
    /// Damage Of The Attack
    /// </summary>
    public int attackDamage = 50;

    /// <summary>
    /// Duration Turret Will Serach For Target
    /// </summary>
    public float serachDuration = 4f;

    /// <summary>
    /// Turn Speed When Searching For Target
    /// </summary>
    public float serachingTurnSpeed = 120f;
}
