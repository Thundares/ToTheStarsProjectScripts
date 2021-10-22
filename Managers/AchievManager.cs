
using UnityEngine;

public class AchievManager : MonoBehaviour
{
    void LateUpdate()
    {
        if (!VariablesManager.bTitan && VariablesManager.dHeight >= 50) 
        {
            VariablesManager.bTitan = true;
        }
        if (!VariablesManager.bSpider && VariablesManager.dHeight >= 443)
        {
            VariablesManager.bSpider = true;
        }
        if (!VariablesManager.bSpace && VariablesManager.dHeight >= 100000)
        {
            VariablesManager.bSpace = true;
        }
        if (!VariablesManager.bMoon && VariablesManager.dHeight >= 384000000)
        {
            VariablesManager.bMoon = true;
        }
        if (!VariablesManager.bBees && VariablesManager.iTotalBees >= 100)
        {
            VariablesManager.bBees = true;
        }
        if (!VariablesManager.bWasp && VariablesManager.iTotalWasp >= 10)
        {
            VariablesManager.bWasp = true;
        }
        if (!VariablesManager.b50 && VariablesManager.iTotalRounds >= 50)
        {
            VariablesManager.b50 = true;
        }
        if (!VariablesManager.b100 && VariablesManager.iTotalRounds >= 100)
        {
            VariablesManager.b100 = true;
        }
    }
}
