using UnityEngine;

public class Achiev : MonoBehaviour
{
    [SerializeField] GameObject[] panels = null;
    public void CheckAchiev() 
    {
        if (VariablesManager.bTitan) 
        {
            panels[0].SetActive(false);
        }
        if (VariablesManager.bSpider)
        {
            panels[1].SetActive(false);
        }
        if (VariablesManager.bSpace)
        {
            panels[0].SetActive(false);
        }
        if (VariablesManager.bMoon)
        {
            panels[0].SetActive(false);
        }
        if (VariablesManager.bBees)
        {
            panels[0].SetActive(false);
        }
        if (VariablesManager.bWasp)
        {
            panels[0].SetActive(false);
        }
        if (VariablesManager.b50)
        {
            panels[0].SetActive(false);
        }
        if (VariablesManager.b100)
        {
            panels[0].SetActive(false);
        }
    }

    public void TgglEggs() 
    {
        VariablesManager.bEggsEnabled = !VariablesManager.bEggsEnabled;
    }
}
