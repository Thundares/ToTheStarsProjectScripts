using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerObject : MonoBehaviour
{
    [SerializeField] AdsInGame adMan;

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (VariablesManager.bGameOver) 
        {
            Debug.Log("Trying to reload");
            VariablesManager.iHitNumber = 0;
            VariablesManager.iRounds++;

            VariablesManager.bGameOver = false;

            adMan.CheckAd();
            SceneManager.LoadScene(1);
        }
    }
}
