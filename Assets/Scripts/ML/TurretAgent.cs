using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class TurretAgent : Agent {

    /// <summary>
    /// Stats for the turret
    /// </summary>
    public TurretStats turretStats;

    /// <summary>
    /// Projectile fire point 
    /// Also where the camera is attached 
    /// </summary>
    public Transform projectilePoint;

    public Transform target;
    public Transform goal;
    public Transform[] spawnPoints;


    private void Spawn()
    {
        int index = Mathf.FloorToInt(
                Random.Range(0, spawnPoints.Length)
            );

        target.position = spawnPoints[index].position;
    }

    public override void InitializeAgent()
    {
        Spawn();
    }

    public override void AgentReset()
    {
        Spawn();
    }

    public override void CollectObservations()
    {

    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        // Time Penlty
        //AddReward(-0.001f);

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
            }
            else if (Physics.SphereCast(projectilePoint.position, 7.5f, projectilePoint.forward, out hitInfo, 30) 
                && hitInfo.collider.CompareTag("Player"))
            {
                // Near Penilty
                AddReward(-0.050f);
            }
            else
            {
                // Miss Penilty
                AddReward(-0.075f);
            }
        }
        else
        {
            // Dont Shoot Penilty
            //AddReward(-0.075f);
        }

        // Reached target
        float distanceToTarget = Vector3.Distance(target.position,
                                                  goal.position);
        if (distanceToTarget < 1.42f)
        {
            // Reached target
            AddReward(-1.0f);
            Done();
        }

    }
}
