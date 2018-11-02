using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAI : MonoBehaviour {

    public BulletStats bulletStats;
    public Rigidbody rBody;
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
        disableSelf();
        if (other.tag == "Player")
        {
            other.gameObject.SetActive(false);
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
