using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

public class AdsInGame : MonoBehaviour
{
    [SerializeField] string gameId = "4393881";
    [SerializeField] bool testMode = true;
    [SerializeField] int roundsDisplayAd = 1;

    private UnityEvent eNormalAd;

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
         
    public void CheckAd()
    {
        if (VariablesManager.iRounds % roundsDisplayAd == 0) 
        {
            eNormalAd.Invoke();
        }
    }
}
