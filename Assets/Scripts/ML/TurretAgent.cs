using UnityEngine;
using MLAgents;

public class TurretAgent : Agent {

    /// <summary>
    /// Stats for the turret
    /// </summary>
    public TurretStats turretStats;

	/// <summary>
	/// Instance Of Data Collector
	/// </summary>
	public DataCollector dataCollector;

    /// <summary>
    /// Projectile fire point 
    /// Also where the camera is attached 
    /// </summary>
    public Transform projectilePoint;

	/// <summary>
	/// Target That The Turret Is Shooting
	/// </summary>
    public Transform target;

	/// <summary>
	/// Goal The Turret is trying to get too
	/// </summary>
    public Transform goal;

	/// <summary>
	/// Spawn Points Where The Target Can Spawn From
	/// </summary>
    public Transform[] spawnPoints;

	/// <summary>
	/// Spawn Target at Spawn Point
	/// </summary>
    private void Spawn()
    {
        int index = Mathf.FloorToInt(
                Random.Range(0, spawnPoints.Length)
            );

        target.position = spawnPoints[index].position;

		// Update Display
		if (dataCollector != null)
			dataCollector.IncreaseHit();
	}

	/// <summary>
	/// Dirved From Agent, Used to Setup
	/// </summary>
    public override void InitializeAgent()
    {
        Spawn();
    }

	/// <summary>
	/// Dirved From Agent, Called Target Reaches Goal Or When Turret Hits the Target
	/// </summary>
	public override void AgentReset()
    {
        Spawn();
    }

	/// <summary>
	/// Collected Data from the inviroment
	/// </summary>
    public override void CollectObservations()
    {
		// Observations from the Camera
		// Implmented in Unity Engine
		// See Agent Compant Set on Turret_MachineGun_L01 Agent
	}

	public override void AgentAction(float[] vectorAction, string textAction)
    {
        // Rotate Action
        this.transform.Rotate(0, vectorAction[0] * turretStats.serachingTurnSpeed * Time.deltaTime, 0);

        // Fire Action
        int action = Mathf.FloorToInt(vectorAction[1]);
        if (action == 1)
        {
            RaycastHit hitInfo;
            if (Physics.SphereCast(projectilePoint.position, 2.5f, projectilePoint.forward, out hitInfo, 30) 
                && hitInfo.collider.CompareTag("Player"))
            {
                // Hit Reward
                AddReward(+1.0f);
				Done();
            }
            else if (Physics.SphereCast(projectilePoint.position, 5.0f, projectilePoint.forward, out hitInfo, 30) 
                && hitInfo.collider.CompareTag("Player"))
            {
                // Close Penilty
                AddReward(-0.025f);
				if (dataCollector != null)
					dataCollector.IncreaseMiss();
            }
            else if (Physics.SphereCast(projectilePoint.position, 7.5f, projectilePoint.forward, out hitInfo, 30) 
                && hitInfo.collider.CompareTag("Player"))
            {
                // Near Penilty
                AddReward(-0.050f);
				if (dataCollector != null)
					dataCollector.IncreaseMiss();
			}
            else
            {
                // Miss Penilty
                AddReward(-0.075f);
				if (dataCollector != null)
					dataCollector.IncreaseMiss();
			}
        }

        // Reached target
        float distanceToTarget = Vector3.Distance(target.position,
                                                  goal.position);
        if (distanceToTarget < 1.42f)
        {
            // Reached target
            AddReward(-1.0f);
			if (dataCollector != null)
				dataCollector.IncreaseGoalReached();
            Done();
        }

    }
}
