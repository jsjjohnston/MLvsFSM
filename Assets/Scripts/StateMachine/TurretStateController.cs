using UnityEngine;

/// <summary>
/// State controller used on Turrets
/// </summary>
public class TurretStateController : StateController {

	/// <summary>
	/// Stats for the turret
	/// </summary>
	public TurretStats turretStats;

	/// <summary>
	/// Gaol The Target Is Trying To Reach
	/// </summary>
	public Transform goal;

	/// <summary>
	/// Data Collecter
	/// </summary>
	public DataCollector dataCollector;

	/// <summary>
	/// Projectile fire point 
	/// Also where the camera is attached 
	/// </summary>
	public Transform projectilePoint;

	/// <summary>
	/// Spawn Points For Target
	/// </summary>
	public Transform[] spawnPoints;

	[HideInInspector] public bool targetDead = false;

	/// <summary>
	/// Target that the turret is focused on and fires at
	/// </summary>
	public Transform target;

	/// <summary>
	/// Tell Update Function to focus on target
	/// </summary>
    private bool focusOnTarget;

    /// <summary>
    /// Draw line to show where the turret is aiming
    /// </summary>
    private void OnDrawGizmos()
    {
        if (currentState != null && projectilePoint != null)
        {
            Gizmos.color = currentState.sceneGizmoColour;
            Gizmos.DrawWireSphere(projectilePoint.position, turretStats.lookSphereCastRadius);
        }
    }

    /// <summary>
    /// Fire At The Target
    /// </summary>
    public void Fire()
    {
		RaycastHit hitInfo;
		if (Physics.SphereCast(projectilePoint.position, 2.5f, projectilePoint.forward, out hitInfo, 30)
			&& hitInfo.collider.CompareTag("Player"))
		{
			targetDead = true;
		}
		else
		{
			dataCollector.IncreaseMiss();
		}
	}

    private void Awake()
    {
        DoNotFocus();    
    }

    public void Focus()
    {
        focusOnTarget = true;
    }

    public void DoNotFocus()
    {
        focusOnTarget = false;
    }

	/// <summary>
	/// Spawn Target
	/// </summary>
	private void Spawn()
	{
		int index = Mathf.FloorToInt(
				Random.Range(0, spawnPoints.Length)
			);

		target.position = spawnPoints[index].position;
		targetDead = false;
	}

    protected override void Update()
    {
        base.Update();
        if (focusOnTarget)
        {
            Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.LookAt(targetPos);
        }

		if (targetDead)
		{
			Spawn();
			
			// Update Display
			dataCollector.IncreaseHit();
		}

		// Reached target
		float distanceToTarget = Vector3.Distance(target.position,
												  goal.position);
		if (distanceToTarget < 1.42f)
		{
			dataCollector.IncreaseGoalReached();
		}
	}
}
