using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundOff : MonoBehaviour
{
    [SerializeField] private Renderer groundBg;
    [SerializeField] private Transform camTrans;
    [SerializeField] private float fMulti = 1;

    // Update is called once per frame
    void LateUpdate()
    {
        groundBg.material.mainTextureOffset = new Vector2(camTrans.position.x * fMulti / transform.localScale.x, 0);
    }
}
