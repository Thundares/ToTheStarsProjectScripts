using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnImpulse : MonoBehaviour
{

    [SerializeField] private GameObject impulsePrefab;
    [SerializeField] private Rigidbody2D rbPlayer;
    [SerializeField] public double dDistance = 5;
    [SerializeField] private float fImpulseIncrementDivisor = 5;

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
        float xPosition = (float)(rbPlayer.position.x + (Random.value - 0.5) * dDistance);
        Debug.Log(xPosition);
        GameObject newImpulse = Instantiate(impulsePrefab, new Vector3(xPosition, rbPlayer.position.y + 6, 0), Quaternion.identity);
        newImpulse.GetComponent<Rigidbody2D>().velocity = rbPlayer.velocity;
        newImpulse.GetComponent<ClickImpulse>().ForceValue *= (VariablesManager.iHitNumber / fImpulseIncrementDivisor) + 1;

    }
}
