using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

public class AdsInGame : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] string gameId = "4393881";
    [SerializeField] bool testMode = true;
    [SerializeField] int roundsDisplayAd = 1;
    [SerializeField] Button adBtn;

    [SerializeField] private const int skipAd = 20;
    [SerializeField] private int skipedAd = VariablesManager.iSkippedAds;
    private bool Watch = false;
    private UnityEvent eNormalAd;

    // initialize ad
    private void Awake()
    {
        try
        {
            Advertisement.Initialize(gameId, testMode);
        }
        catch 
        {
            Debug.LogError("Advertisement failed to load");
        }
        if (eNormalAd == null) 
        {
            eNormalAd = new UnityEvent();
        }
        eNormalAd.AddListener(() => Advertisement.Show("Interstitial_Android"));
    }

    // initialize reward add
    private void Start()
    {
        adBtn.interactable = Advertisement.IsReady("Rewarded_Android");
        Advertisement.AddListener(this);
    }

    public void CheckAd()
    {
        if (VariablesManager.iSkippedAds < skipAd)
        {
            VariablesManager.iSkippedAds++;
        }
        else 
        {
            if (VariablesManager.iRounds % roundsDisplayAd == 0)
            {
                eNormalAd.Invoke();
            }
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == "Rewarded_Android") 
        {
            adBtn.interactable = true;
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError(message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //nothing
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished && placementId == "Rewarded_Android") 
        {
            VariablesManager.iSkippedAds = 0;
        }
    }

    public void OnClickBtn() 
    {
        Advertisement.Show("Rewarded_Android");
    }
}
