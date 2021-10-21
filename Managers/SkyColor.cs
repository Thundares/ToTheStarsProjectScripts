﻿using System;
using UnityEngine;

public class SkyColor : MonoBehaviour
{
    [SerializeField] private Renderer renderer = null;
    [SerializeField] private Material blueSky = null;
    [SerializeField] private Material orangeSky = null;
    [SerializeField] private Material darkSky = null;
    [SerializeField] private Material space = null;

    // Start is called before the first frame update
    void Start()
    {
        //dark
        if (System.DateTime.Now.Hour > 19)
        {
            renderer.material = darkSky;
        }
        //sunset
        else if (System.DateTime.Now.Hour > 15)
        {
            renderer.material = orangeSky;
        }
        //blueSky
        else if (System.DateTime.Now.Hour > 6)
        {
            renderer.material = blueSky;
        }
        //dark
        else 
        {
            renderer.material = darkSky;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (VariablesManager.dHeight > 100000) 
        {
            renderer.material = space;
        }
    }
}
