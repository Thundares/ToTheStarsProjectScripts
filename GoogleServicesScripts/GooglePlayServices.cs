using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GooglePlayServices : MonoBehaviour
{

    private bool isConnectedToGoogle = false;
    public static PlayGamesPlatform platform;
    private bool got50 = false;
    private bool got443 = false;
    private bool gotSpace = false;
    private bool gotMoon = false;

    private void Start()
    {
        // log in
        if (platform == null) 
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            platform = PlayGamesPlatform.Activate();
        }

        Social.Active.localUser.Authenticate( result => {

            if (result)
            {
                Debug.Log("Connection with Google: Ok");
                isConnectedToGoogle = true;
            }
            else 
            {
                Debug.Log("Connection with Google: Failed");
            }

        });
        /*
        PlayGamesPlatform.Instance.Authenticate(GooglePlayGames.BasicApi.SignInInteractivity.CanPromptOnce, (result) =>
        {
            if (result == SignInStatus.Success)
            {
                isConnectedToGoogle = true;
                Debug.Log("Connection with Google: Ok");
            }
            else 
            {
                isConnectedToGoogle = false;
                Debug.Log("Connection with Google: Failed");
            }
        });
        */

        // set pop-up to the bottom
        Social.localUser.Authenticate((bool success) =>
            {
                if (success) 
                {
                    ((GooglePlayGames.PlayGamesPlatform)Social.Active).SetGravityForPopups(Gravity.BOTTOM);
                }
            });

        //set boolean for anchievements
        got50 = false;
        got443 = false;
        gotSpace = false;
        gotMoon = false;
    }

    // update to cheack anchievements
    private void LateUpdate()
    {
        if (!isConnectedToGoogle) 
        {
            return;
        }

        // height anchievements
        if (VariablesManager.dHeight >= 50 && !got50)
        {
            Social.ReportProgress("CgkI5tDmh6scEAIQAA", 100.0f, null);
            Debug.Log("Got 50");
            got50 = true;
        }
        else if (VariablesManager.dHeight >= 443 && !got443)
        {
            Social.ReportProgress("CgkI5tDmh6scEAIQAQ", 100.0f, null);
            got443 = true;
        }
        else if (VariablesManager.dHeight >= 100000 && !gotSpace)
        {
            Social.ReportProgress("CgkI5tDmh6scEAIQAg", 100.0f, null);
            gotSpace = true;
        }
        else if (VariablesManager.dHeight >= 384000000 && !gotMoon) 
        {
            Social.ReportProgress("CgkI5tDmh6scEAIQBg", 100.0f, null);
            gotMoon = true;
        }

        //click anchievements

    }
}
