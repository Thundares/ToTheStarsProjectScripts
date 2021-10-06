using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

public class AdsInGame : MonoBehaviour
{
    [SerializeField] string gameId = "4393881";
    [SerializeField] bool testMode = true;
    [SerializeField] int roundsDisplayAd;

    private UnityEvent eNormalAd;

    private void Awake()
    {
        Advertisement.Initialize(gameId, testMode);
        if (eNormalAd == null) 
        {
            eNormalAd = new UnityEvent();
        }
        eNormalAd.AddListener(Advertisement.Show);
    }

    public void CheckAd()
    {
        if (VariablesManager.iRounds % roundsDisplayAd == 0) 
        {
            eNormalAd.Invoke();
        }
    }
}
