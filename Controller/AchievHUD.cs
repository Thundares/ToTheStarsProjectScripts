using System.Collections;
using UnityEngine;

public class AchievHUD : MonoBehaviour
{
    [SerializeField] private GameObject Achiev = null;

    public void NewAchiev()
    {
        if (VariablesManager.bNewAch)
        {
            StartCoroutine(FlashHUD());
            VariablesManager.bNewAch = false;
        }
    }

    public IEnumerator FlashHUD()
    {
        for (int i = 0; i < 3; i++)
        {
            Achiev.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.8f);
            Achiev.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.8f);
            //Debug.Log("Why only one?");
        }
        yield return null;
    }
}
