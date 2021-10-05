using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private float fSmooth;
    [SerializeField] private Vector3 offset;
    private GameObject Player;
    private Vector3 actualPosition;
    private Vector3 targetPosition;
    
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //follow the player
        targetPosition = Player.transform.position + offset;
        actualPosition = Vector3.Lerp(transform.position, targetPosition, fSmooth);
        transform.position = actualPosition;
    }
}
