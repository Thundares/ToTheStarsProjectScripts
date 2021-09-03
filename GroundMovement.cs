﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{

    // script that always let the ground under the player.

    [SerializeField] private GameObject Player;
    
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Player.transform.position.x, this.transform.position.y) ;
    }
}
