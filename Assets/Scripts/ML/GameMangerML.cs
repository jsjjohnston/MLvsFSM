using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMangerML : MonoBehaviour {

    public int waveSize;
    public TurretAgent turretAgent;
    public WaveManagerML waveManagerML;

    private int enimiesReachedGoal;

    private int enimiesKilled;

    public void increaseEnemiesReachedGoal()
    {
        turretAgent.AddReward(-1.0f);
        enimiesReachedGoal++;
    }

    public void increaseEnimiesKilled()
    {
        enimiesKilled++;
    }

    private void startNewRound()
    {
        waveManagerML.resetWave();
        enimiesReachedGoal = 0;
        enimiesKilled = 0;
        turretAgent.Done();
    }

    // Use this for initialization
    void Start () {
        enimiesReachedGoal = 0;
        enimiesKilled = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (enimiesReachedGoal + enimiesKilled == waveSize)
        {
            startNewRound();
        }
	}
}
