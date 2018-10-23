using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Stats/Bullet Stats")]
public class BulletStats : ScriptableObject {

    public float damage = 100f;
    public float lifetime = 2f;
    
    /// <summary>
    /// Force Of The Attack
    /// </summary>
    public float attackForce = 15f;
}
