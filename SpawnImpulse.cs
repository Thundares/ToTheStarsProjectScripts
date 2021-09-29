using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnImpulse : MonoBehaviour
{

    [SerializeField] private GameObject impulsePrefab;
    [SerializeField] private GameObject falseImpulsePrefab;
    [SerializeField] private Rigidbody2D rbPlayer;
    [SerializeField] public double dDistance = 5;
    [SerializeField] private float fImpulseIncrementDivisor;

    UnityEvent eSpawn;

    public void Start()
    {
        if (eSpawn == null) 
        {
            eSpawn = new UnityEvent();
        }
        eSpawn.AddListener(Spawn);
    }

    private void Update()
    {
        if (VariablesManager.bEnableSpawn)
        {
            if (rbPlayer.velocity.y < 1)
            {
                eSpawn.Invoke();
                VariablesManager.bEnableSpawn = false;
            }
        }
    }

    void Spawn() 
    {
        //spawn true impulse
        float xPosition = (float)(rbPlayer.position.x + (Random.value - 0.5) * dDistance);
        Debug.Log("Spawn impulse in " + xPosition);
        GameObject newImpulse = Instantiate(impulsePrefab, new Vector3(xPosition, rbPlayer.position.y + 6, 0), Quaternion.identity);
        newImpulse.GetComponent<Rigidbody2D>().velocity = rbPlayer.velocity;
        newImpulse.GetComponent<ClickImpulse>().ForceValue *= (VariablesManager.iHitNumber / fImpulseIncrementDivisor) + 1;

        //spawn false impulse
        int manyFalses = Mathf.FloorToInt(VariablesManager.iHitNumber / 5);
        Debug.Log("Many falses = " + manyFalses);
        Debug.Log("iHitNumber = " + VariablesManager.iHitNumber);
        for (int i = 0; i < manyFalses; i++) 
        {
            SpawnFalseImpulse(xPosition);
        }
    }

    void SpawnFalseImpulse(float xPosition) 
    {
        //variables
        float xFPosition = xPosition;
        int infiniteController = 0;

        //while too close to the true impulse
        while (xFPosition > xPosition - 1 && xFPosition < xPosition + 1 && infiniteController < 4) 
        {
            //generate new position
            xFPosition = (float)(rbPlayer.position.x + (Random.value - 0.5) * dDistance);
            infiniteController++;
            Debug.Log("Calculating False Position...");
        }

        //did not found a spot to spawn in time
        if (infiniteController >= 4) 
        {
            return;
        }

        //instantiate
        GameObject newFalse = Instantiate(falseImpulsePrefab, new Vector3(xFPosition, rbPlayer.position.y + 6, 0), Quaternion.identity);
        Debug.Log("Spawn False in "+ xFPosition);
        newFalse.GetComponent<Rigidbody2D>().velocity = rbPlayer.velocity;
    }
}
