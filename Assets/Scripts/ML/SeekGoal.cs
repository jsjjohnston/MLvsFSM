using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekGoal : MonoBehaviour {

    // The target marker.
    public Transform goal;

    // Speed in units per sec.
    public float speed = 5.0f;

    void Update()
    {
        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, goal.position, step);
    }
}
