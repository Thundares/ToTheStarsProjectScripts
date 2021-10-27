using System.Collections.Generic;
using UnityEngine;

// based on Code Monkey video for Parallax
public class BackgroundManager : MonoBehaviour
{
    [Header("Offset")]
    [Range(0,1)]
    [SerializeField ]private float fOffsetX = 1;
    [Range(0, 1)]
    [SerializeField] private float fOffsetY = 1;
    [Header("Camera")]
    [SerializeField] private Transform camPosition = null;

    private Renderer backgroundTexture;
    private Vector2 offset;

    //near ground objects
    [Header("Ground Objects")]
    [SerializeField] private List<bgObject> gObjects = new List<bgObject>();
    //sky objects
    [Header("Sky Objects")]
    [SerializeField] private List<bgObject> sObjects = new List<bgObject>();
    //space objects
    [Header("Universe Objects")]
    [SerializeField] private List<Renderer> uObjects = new List<Renderer>();
    //cats
    [Header("Cats Objects")]
    [SerializeField] private List<Renderer> cObjects = new List<Renderer>();

    private bool _cloudActive = true;

    // Start is called before the first frame update
    void Start()
    {
        _cloudActive = true;
        backgroundTexture = GetComponent<Renderer>();
    }

    public void BGUpdate()
    {
        if (_cloudActive)
        {
            foreach (bgObject bg in sObjects)
            {
                bg.rend.material.mainTextureOffset = new Vector2(camPosition.position.x * bg.fParallax / transform.localScale.x,
                    camPosition.position.y * bg.fParallax / transform.localScale.y);
            }

            foreach (bgObject bgGround in gObjects)
            {
                bgGround.rend.material.mainTextureOffset = new Vector2(camPosition.position.x * bgGround.fParallax / transform.localScale.x,
                    bgGround.rend.material.mainTextureOffset.y);
            }

            if (VariablesManager.dHeight >= 100000)
            {
                _cloudActive = false;
                foreach (bgObject bg in sObjects)
                {
                    bg.rend.enabled = false;
                }
            }
        }
        else
        {
            backgroundTexture.material.mainTextureOffset = new Vector2(camPosition.position.x * fOffsetX, camPosition.position.y * fOffsetY);
        }

    }
}
