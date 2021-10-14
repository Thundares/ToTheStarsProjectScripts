using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneManagerObject : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] AdsInGame adMan = null;

    // Update is called once per frame
    public void OnPointerDown(PointerEventData eventData)
    {
        if (VariablesManager.bGameOver) 
        {
            adMan.CheckAd();
            Debug.Log("Trying to reload");
            VariablesManager.iHitNumber = 0;
            VariablesManager.iRounds++;

            VariablesManager.bGameOver = false;

            SceneManager.LoadScene(1);
        }
    }
}
