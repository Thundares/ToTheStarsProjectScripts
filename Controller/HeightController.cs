﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class HeightController : MonoBehaviour
{
    [SerializeField] private Transform player = null;
    [SerializeField] private Text numberText = null;
    [SerializeField] private GameObject panel = null;
    private RectTransform panelRect;
    float panelWidth;

    private void Start() 
    {
        panelRect = panel.GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        VariablesManager.dHeight = player.position.y / 10;
        numberText.text = "H: " + VariablesManager.dHeight.ToString("N0") + " M";
        panelWidth = (float)Math.Log10(VariablesManager.dHeight) * 55 + 375;
        if (float.IsNaN(panelWidth)) 
        {
            panelWidth = 375;
        }
        panelRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, panelWidth);
    }
}
