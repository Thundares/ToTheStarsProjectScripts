using System;
using UnityEngine;
using UnityEngine.UI;

public class HeightController : MonoBehaviour
{
    [SerializeField] private Transform player = null;
    [SerializeField] private Text numberText = null;
   // [SerializeField] private GameObject panel = null;
    private double height = 0;

    public void CalculateHeight() 
    {
        height = player.position.y/10;
        if (height > 50)
        {
            height = 50 + (height-50) * height/40;
        }
        if (height > 1000) 
        {
            height = 1000 + (height - 1000) * Math.Pow(height,1.3) / 1000;
        }
        VariablesManager.dHeight = height;
    }

    public void ChangeUIText() 
    {
        if (height < 1000)
        {
            numberText.text = "H: " + height.ToString("N0") + " M";
        }
        else 
        {
            numberText.text = "H: " + (height / 1000).ToString("N1") + " KM";
        }
    }
}
