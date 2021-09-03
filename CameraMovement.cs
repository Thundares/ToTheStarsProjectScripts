using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject Player;
    
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");   
    }

    // Update is called once per frame
    void Update()
    {
        //follow the player
        this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 3.5f, -10);
    }
}
