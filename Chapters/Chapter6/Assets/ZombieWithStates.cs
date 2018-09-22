using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWithStates : MonoBehaviour {
    public enum MovementStates
    {
        Idle,
        Wander
    }
    public MovementStates MovementState;
    float StateTimer = 0;
    float ClosestDistance = Mathf.Infinity;
    float FurthestDistance = 0;
    GameObject ClosestGameObject;
    GameObject FurthestGameObject;
	void Update ()
    {
        switch (MovementState)
        {
            case MovementStates.Idle:
                goto Idle;
            case MovementStates.Wander:
                goto Wander;
        }
        Idle:
        return;
        Wander:
        return;
	}
}
