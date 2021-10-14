using System;
using UnityEngine;
using UnityEngine.UI;

public class HeightController : MonoBehaviour
{
    [SerializeField] private Transform player = null;
    [SerializeField] private Text numberText = null;
    [SerializeField] private GameObject panel = null;
    private RectTransform panelRect;
    float panelWidth;
    int mult;

    private void Start() 
    {
        panelRect = panel.GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        VariablesManager.dHeight = player.position.y / 10;
        numberText.text = "H: " + VariablesManager.dHeight.ToString("N0") + " M";
        mult = (int)Math.Floor(Math.Log10(VariablesManager.dHeight));
        mult = mult < 1 ? 1 : mult;
        panelWidth = (float)mult * 55 + 275;
        if (float.IsNaN(panelWidth)) 
        {
            panelWidth = 375;
        }
        panelRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, panelWidth);
    }
}
