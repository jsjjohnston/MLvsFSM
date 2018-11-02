﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagerML : MonoBehaviour {

    public Transform[] startNodes;
    public Transform endNode;
    public ObjectPooler enemyPool;
    public GameMangerML gm;
    public TurretAgent turretAgent;
    private int waveCount;
    public float spawnFrequency;
    private float tick;
    /// <summary>
    /// The time
    /// </summary>
    private float currentTime;

    // Use this for initialization
    void Start () {
        tick = spawnFrequency + Time.deltaTime;
        currentTime = Time.deltaTime;
    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

        if (tick <= currentTime && waveCount != gm.waveSize)
        {
            spawn();
            waveCount++;
            tick = currentTime + spawnFrequency;
        }
	}

    public void resetWave()
    {
        waveCount = 0;
    }

    private void spawn()
    {
        int randomNodeIndex = Random.Range(0, startNodes.Length);
        Vector3 spawnPosition = startNodes[randomNodeIndex].position;
        GameObject poolable = enemyPool.GetAvailableGameObj();
        if (poolable == null)
        {
            return;
        }

        var enemy = poolable.GetComponent<EnemyStateController>();
        enemy.transform.position = spawnPosition;
        enemy.Initialize();

        enemy.SetNodes(startNodes[randomNodeIndex],endNode);
        enemy.transform.rotation = startNodes[randomNodeIndex].rotation;
        enemy.gameObject.SetActive(true);
        enemy.navMeshAgent.enabled = true;
        enemy.navMeshAgent.destination = endNode.position;

        turretAgent.target = enemy.transform;
    }
}