using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField] private Text recordTxt = null;
    [SerializeField] private Text roundsTxt = null;
    [SerializeField] private Text beesTxt = null;

    public void SetTexts() 
    {
        recordTxt.text = VariablesManager.dRecord.ToString("N0");
        roundsTxt.text = VariablesManager.iTotalRounds.ToString();
        beesTxt.text = VariablesManager.iTotalBees.ToString();
    }
}
