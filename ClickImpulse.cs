using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickImpulse : MonoBehaviour
{
    [SerializeField] public float ForceValue;
    [SerializeField] public bool TRUEIMPULSE;
    [SerializeField] private float fLifeTime = 3;
    [SerializeField] private bool bFirst = false;

    private void OnMouseDown()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        // if the player is above this object.
        if (Player.transform.position.y >= this.transform.position.y) 
        {
            //do nothing
            Destroy(this.gameObject);
            return;
        }

        //else
        //direction of the Force
        Vector2 direction = new Vector2(
            this.transform.position.x - Player.transform.position.x,
            this.transform.position.y - Player.transform.position.y);

        //apply force
        Rigidbody2D playerRB = Player.GetComponent<Rigidbody2D>();
        if (TRUEIMPULSE)
        {
            playerRB.AddForce(direction * ForceValue, ForceMode2D.Impulse);
            VariablesManager.bEnableSpawn = true;
            VariablesManager.iHitNumber++;
        }
        else 
        {
            playerRB.AddForce(direction * ForceValue * -1, ForceMode2D.Impulse);
        }

        Destroy(this.gameObject);
    }

    // despawn object
    private void FixedUpdate()
    {
        if (fLifeTime < 0)
        {
            if(!bFirst)
                Destroy(this.gameObject);
        }
        else 
        {
            fLifeTime -= 1 * Time.deltaTime;
        }
    }
}
