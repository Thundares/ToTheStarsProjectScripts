using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private float fOffset = 1.5f;
    private GameObject Player;
    private float xPosition;
    private float yPosition;
    private bool isMoving;
    
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        //follow the player
        xPosition = Player.transform.position.x;
        this.transform.position = new Vector3(xPosition, Player.transform.position.y + 5, -10);

        /*awfull camera. Need rework
        if (transform.position.y < Player.transform.position.y - fOffset)
        {
            isMoving = true;
        }
        else if (transform.position.y > Player.transform.position.y + fOffset) 
        {
            yPosition = transform.position.y - 20 * Time.deltaTime;
            isMoving = false;
        }
        if (isMoving) 
        {
            yPosition = transform.position.y + 40 * Time.deltaTime;
        }
        this.transform.position = new Vector3(xPosition, yPosition, -10);
        */
    }
}
