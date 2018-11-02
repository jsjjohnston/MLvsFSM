using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalReachedML : MonoBehaviour {

    public GameMangerML gameMangerML;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameMangerML.increaseEnemiesReachedGoal();
            other.gameObject.SetActive(false);
        }
    }
}
