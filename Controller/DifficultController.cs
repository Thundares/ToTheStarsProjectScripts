using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultController : MonoBehaviour
{
    private Rigidbody2D rbPlayer;

    public DifficultController() 
    {
        rbPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public void IncrementDif() 
    {
        if (rbPlayer.gravityScale < 6)
        {
            rbPlayer.gravityScale += (float)0.5;
            VariablesManager.iDifficult++;
        }
    }
}
