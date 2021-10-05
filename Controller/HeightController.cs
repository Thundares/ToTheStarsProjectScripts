using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightController : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Update is called once per frame
    void FixedUpdate()
    {
        VariablesManager.dHeight = player.position.y / 10;
    }
}
