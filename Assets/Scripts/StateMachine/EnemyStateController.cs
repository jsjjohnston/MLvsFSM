using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// State controller for enemys
/// </summary>
public class EnemyStateController : MonoBehaviour {

    /// <summary>
    /// Stats for the turret
    /// </summary>
    public EnemyStats enemyStat;

    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public float maxHealth;
    [HideInInspector] public float currentHealth;

    private Transform startNode;
    private Transform endNode;

    private void Awake()
    {
        ResetHealth();

        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent != null)
        {
            navMeshAgent.enabled = false;
            navMeshAgent.speed = enemyStat.speed;
        }
    }

    public void Initialize()
    {
        ResetHealth();
    }

    private void ResetHealth()
    {
        if (enemyStat != null)
        {
            maxHealth = enemyStat.maxHealth;
            currentHealth = enemyStat.startHealth;
        }
        else
        {
            Debug.LogWarning("EnemyStat Unassigned");
        }
    }

    public void SetNodes(Transform newStartNode, Transform newEndNode)
    {
        if (endNode != newEndNode)
            endNode = newEndNode;

        if (startNode != newStartNode)
            startNode = newStartNode;
    }
}
