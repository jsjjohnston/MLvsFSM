using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletML : MonoBehaviour {

    public BulletStats bulletStats;
    public Rigidbody rBody;
    public TurretAgent agent;
    public GameMangerML gameManager;

    private Transform projectilePoint;
    private float tick;
    private float currentTime;

	// Use this for initialization
	void Start ()
    {
        setTimer();
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentTime += Time.deltaTime;
        if (tick <= currentTime)
        {
            disableSelf();
            // Miss Target
            agent.AddReward(-1.0f);
        }
    }

    public void SetProjectilePoint(Transform newProjectilePoint)
    {
        projectilePoint = newProjectilePoint;
    }

    private void OnEnable()
    {
        ResetRigidbody();
        setTimer();

        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameMangerML>();
        }

        if (agent == null)
        {
            agent = FindObjectOfType<TurretAgent>();
        }

        if (projectilePoint != null)
        {
            rBody.velocity = bulletStats.attackForce * transform.forward;
        }
    }

    private void setTimer()
    {
        tick = bulletStats.lifetime + currentTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.SetActive(false);
            gameManager.increaseEnimiesKilled();
            // Hit Target
            agent.AddReward(1.0f);
        }
        else
        {
            disableSelf();
        }
    }

    private void disableSelf()
    {
        gameObject.SetActive(false);
    }

    private void ResetRigidbody()
    {
        rBody.velocity = new Vector3(0f, 0f, 0f);
        rBody.angularVelocity = new Vector3(0f, 0f, 0f);
    }
}
