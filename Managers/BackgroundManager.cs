using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// based on Code Monkey video for Parallax
public class BackgroundManager : MonoBehaviour
{
    [Range(0,1)]
    [SerializeField ]private float fOffsetX = 1;
    [Range(0, 1)]
    [SerializeField] private float fOffsetY = 1;
    [SerializeField] private Transform camPosition;

    private Renderer backgroundTexture;
    private Vector2 offset;

    private float x = 0; 

    //near ground objects
    [Header("Ground Objects")]
    [SerializeField] private List<GameObject> gObjects = new List<GameObject>();
    //sky objects
    [Header("Sky Objects")]
    [SerializeField] private List<GameObject> sObjects = new List<GameObject>();
    //space objects
    [Header("Universe Objects")]
    [SerializeField] private List<GameObject> uObjects = new List<GameObject>();
    //cats
    [Header("Cats Objects")]
    [SerializeField] private List<GameObject> cObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        backgroundTexture = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //set offset of the background material
        offset = new Vector2(camPosition.position.x * fOffsetX / transform.localScale.x, 
            camPosition.position.y * fOffsetY / transform.localScale.y);
        backgroundTexture.material.mainTextureOffset = offset;
    }
}
