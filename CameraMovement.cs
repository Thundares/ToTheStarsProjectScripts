using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private float fSmooth = 0;
    [SerializeField] private Vector3 offset = Vector3.zero;
    [SerializeField] private GameObject Player;
    private Vector3 actualPosition;
    private Vector3 targetPosition;

    // Update is called once per frame
    void FixedUpdate()
    {
        //follow the player
        targetPosition = Player.transform.position + offset;
        actualPosition = Vector3.Lerp(transform.position, targetPosition, fSmooth);
        transform.position = actualPosition;
    }
}
