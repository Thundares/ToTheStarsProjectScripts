using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneManagerObject : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] AdsInGame adMan = null;

    // Called after click on GameOver state
    public void OnPointerDown(PointerEventData eventData)
    {
        if (VariablesManager.bGameOver) 
        {
            adMan.CheckAd();
            Debug.Log("Trying to reload");
            VariablesManager.iHitNumber = 0;
            VariablesManager.iRounds++;
            VariablesManager.iTotalRounds++;
            VariablesManager.Save();
            VariablesManager.bGameOver = false;

            SceneManager.LoadScene(1);
        }
    }
}
