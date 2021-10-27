using UnityEngine;

public class DifficultController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbPlayer = null;
    private int lastIncrement = 0;

    public void IncrementDif() 
    {
        if (rbPlayer.gravityScale < 6 && lastIncrement != VariablesManager.iHitNumber)
        {
            rbPlayer.gravityScale = (float)(0.5 + rbPlayer.gravityScale) * VariablesManager.fGravityMulti;
            VariablesManager.iDifficult++;
            lastIncrement = VariablesManager.iHitNumber;
        }
    }

    public void ResetDif() 
    {
        VariablesManager.iDifficult = 0;
        rbPlayer.gravityScale = 1.0f;
        lastIncrement = 0;
    }
}
