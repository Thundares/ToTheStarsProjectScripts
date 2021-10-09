using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GooglePlayServices : MonoBehaviour
{

    private bool isConnectedToGoogle = false;

    // Start is called before the first frame update
    void Awake()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    private void Start()
    {
        // log in
        PlayGamesPlatform.Instance.Authenticate(GooglePlayGames.BasicApi.SignInInteractivity.CanPromptOnce, (result) =>
        {
            if (result == SignInStatus.Success)
            {
                isConnectedToGoogle = true;
            }
            else 
            {
                isConnectedToGoogle = false;
            }
        });

        // set pop-up to the bottom
        Social.localUser.Authenticate((bool success) =>
            {
                if (success) 
                {
                    ((GooglePlayGames.PlayGamesPlatform)Social.Active).SetGravityForPopups(Gravity.BOTTOM);
                }
            });
    }

}
