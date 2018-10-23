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
    /// Projectile fire point 
    /// Also where the camera is attached 
    /// </summary>
    public Transform projectilePoint;

    /// <summary>
    /// Target that the turret is focused on and fires at
    /// </summary>
    [HideInInspector] public Transform target;

    /// <summary>
    /// Pool used to generate bullet
    /// </summary>
    public ObjectPooler bulletPool;

    private float tick;
    private float currentTime;
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
    /// 
    /// </summary>
    public void Fire()
    {
        currentTime += Time.deltaTime;
        if (tick <= currentTime)
        {
            GameObject poolable = bulletPool.GetAvailableGameObj();
            if (poolable == null)
            {
                return;
            }

            var bullet = poolable.GetComponent<BulletAI>();
            bullet.transform.position = projectilePoint.position;
            bullet.transform.rotation = projectilePoint.rotation;
            bullet.SetProjectilePoint(projectilePoint);
            bullet.gameObject.SetActive(true);

            tick = turretStats.attackRate + currentTime;
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

    protected override void Update()
    {
        base.Update();
        if (focusOnTarget)
        {
            Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.LookAt(targetPos);
        }
    }
}
