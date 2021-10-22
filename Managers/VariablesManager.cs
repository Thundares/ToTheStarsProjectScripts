using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VariablesManager
{
    public static bool bGameOver = false;
    public static bool bEnableSpawn = false;
    
    public static double dHeight = 0;

    public static int iHitNumber = 0;
    public static int iRounds = 0;
    public static int iDifficult = 0;
    public static int iSkippedAds = 20;

    public static Target eTarget = Target.none;

    //player stats
    public static double dRecord = 0;
    public static int iTotalRounds = 0;
    public static int iTotalBees = 0;
}

public enum Target
{
    right,
    wrong,
    none
}