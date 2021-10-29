
using UnityEngine;

public static class AchievManager
{
    public static void CheckAchiev()
    {
        if (!VariablesManager.bTitan && VariablesManager.dHeight >= 50) 
        {
            VariablesManager.bTitan = true;
            VariablesManager.bNewAch = true;
        }
        if (!VariablesManager.bSpider && VariablesManager.dHeight >= 443)
        {
            VariablesManager.bSpider = true;
            VariablesManager.bNewAch = true;
        }
        if (!VariablesManager.bSpace && VariablesManager.dHeight >= 100000)
        {
            VariablesManager.bSpace = true;
            VariablesManager.bNewAch = true;
        }
        if (!VariablesManager.bMoon && VariablesManager.dHeight >= 384000000)
        {
            VariablesManager.bMoon = true;
            VariablesManager.bNewAch = true;
        }
        if (!VariablesManager.bBees && VariablesManager.iTotalBees >= 100)
        {
            VariablesManager.bBees = true;
            VariablesManager.bNewAch = true;
        }
        if (!VariablesManager.bWasp && VariablesManager.iTotalWasp >= 10)
        {
            VariablesManager.bWasp = true;
            VariablesManager.bNewAch = true;
        }
        if (!VariablesManager.b50 && VariablesManager.iTotalRounds >= 50)
        {
            VariablesManager.b50 = true;
            VariablesManager.bNewAch = true;
        }
        if (!VariablesManager.b100 && VariablesManager.iTotalRounds >= 100)
        {
            VariablesManager.b100 = true;
            VariablesManager.bNewAch = true;
        }
    }
}
