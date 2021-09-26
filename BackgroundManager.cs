using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// based on Code Monkey video for Parallax
public class BackgroundManager : MonoBehaviour
{
    [SerializeField] public Transform camTransform;
    [SerializeField] private float fParallax = .5f;
    private Vector3 cameraPosition;
    private Vector3 deltaMoviment;
    private float fTextureSizeX;
    private float fTextureSizeY;
    private float fOffsetX;
    private float fOffsetY;


    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = camTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        fTextureSizeX = sprite.texture.width / sprite.pixelsPerUnit;
        fTextureSizeY = sprite.texture.height / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        deltaMoviment = camTransform.position - cameraPosition;
        transform.position += deltaMoviment * fParallax;
        cameraPosition = camTransform.position;

        if (Mathf.Abs(camTransform.position.x - transform.position.x) > fTextureSizeX -0.13) 
        {
            fOffsetX = (camTransform.position.x - transform.position.x) % fTextureSizeX;
            transform.position = new Vector3(camTransform.position.x + fOffsetX, transform.position.y, 10);
        }

        if (Mathf.Abs(camTransform.position.y - transform.position.y) > fTextureSizeY - 0.13)
        {
            fOffsetY = (camTransform.position.y - transform.position.y) % fTextureSizeY;
            transform.position = new Vector3(transform.position.x, camTransform.position.y + fOffsetY, 10);
        }
    }
}
