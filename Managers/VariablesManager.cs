using UnityEngine;

public static class VariablesManager
{
    public static bool bGameOver = false;
    public static bool bEnableSpawn = false;
    public static bool bEggsEnabled = true;
    public static bool bNewAch = false;
    
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
    public static int iTotalWasp = 0;
    public static int iSpentBees = 0;

    //Shop Variables
    public static float fGravityMulti = 1;
    public static float fGravityLimit = 0;
    public static float fPowerMult = 1;
    public static float fPowerLimit = 0;

    //player achiev
    public static bool bTitan = false;
    public static bool bSpider = false;
    public static bool bSpace = false;
    public static bool bMoon = false;
    public static bool bBees = false;
    public static bool bWasp = false;
    public static bool b50 = false;
    public static bool b100 = false;

    //skin
    public static bool bAranha = false;

    public static void Save() 
    {
        PlayerPrefs.SetInt("itotalBees", VariablesManager.iTotalBees);
        PlayerPrefs.SetInt("itotalWasp", iTotalWasp);
        PlayerPrefs.SetInt("itotalRounds", VariablesManager.iTotalRounds);
        PlayerPrefs.SetFloat("dRecord", (float)VariablesManager.dRecord);
        PlayerPrefs.SetInt("bTitan", BToI(bTitan));
        PlayerPrefs.SetInt("bSpider", BToI(bSpider));
        PlayerPrefs.SetInt("bSpace", BToI(bSpace));
        PlayerPrefs.SetInt("bMoon", BToI(bMoon));
        PlayerPrefs.SetInt("bBees", BToI(bBees));
        PlayerPrefs.SetInt("bWasp", BToI(bWasp));
        PlayerPrefs.SetInt("b50", BToI(b50));
        PlayerPrefs.SetInt("b100", BToI(b100));
        PlayerPrefs.SetInt("ispentBees", iSpentBees);
        PlayerPrefs.SetFloat("fgravityLimit", fGravityLimit);
        PlayerPrefs.SetFloat("fpowerLimit", fPowerLimit);
    }

    public static void Load() 
    {
        iTotalBees = PlayerPrefs.GetInt("itotalBees");
        iTotalWasp = PlayerPrefs.GetInt("itotalWasp");
        iTotalRounds = PlayerPrefs.GetInt("itotalRounds");
        dRecord = PlayerPrefs.GetFloat("dRecord");
        bTitan = IToB(PlayerPrefs.GetInt("bTitan"));
        bSpider = IToB(PlayerPrefs.GetInt("bSpider"));
        bSpace = IToB(PlayerPrefs.GetInt("bSpace"));
        bMoon = IToB(PlayerPrefs.GetInt("bMoon"));
        bBees = IToB(PlayerPrefs.GetInt("bBees"));
        bWasp = IToB(PlayerPrefs.GetInt("bWasp"));
        b50 = IToB(PlayerPrefs.GetInt("b50"));
        b100 = IToB(PlayerPrefs.GetInt("b100"));
        iSpentBees = PlayerPrefs.GetInt("ispentBees");
        fGravityLimit = PlayerPrefs.GetFloat("fgravityLimit");
        fPowerLimit = PlayerPrefs.GetFloat("fpowerLimit");
    }

    private static bool IToB(int oneOrZero) 
    {
        return oneOrZero == 0 ? false : true;
    }

    private static int BToI(bool tf) 
    {
        return tf ? 1 : 0;
    }
}

public enum Target
{
    right,
    wrong,
    none
}
