﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickImpulse : MonoBehaviour
{
    [SerializeField] public float ForceValue;

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
        Vector2 direction = new Vector2(
            this.transform.position.x - Player.transform.position.x,
            this.transform.position.y - Player.transform.position.y);

        Debug.Log(direction.ToString());

        Rigidbody2D playerRB = Player.GetComponent<Rigidbody2D>();
        playerRB.AddForce(direction * ForceValue, ForceMode2D.Impulse);
        Destroy(this.gameObject);
    }
}
