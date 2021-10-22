using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneScript : MonoBehaviour
{

    [SerializeField] private Slider slider = null;

    private void Start()
    {      
        Debug.Log("Loading next scene");
        VariablesManager.iTotalBees = PlayerPrefs.GetInt("totalBees");
        VariablesManager.iTotalRounds = PlayerPrefs.GetInt("totalRounds");
        VariablesManager.dRecord = PlayerPrefs.GetFloat("record");
        StartCoroutine(LoadAsyncProgress());
    }

    private IEnumerator LoadAsyncProgress() 
    {
        AsyncOperation loadingNext = SceneManager.LoadSceneAsync(1);

        while (!loadingNext.isDone) 
        {
            slider.value = Mathf.Clamp01(loadingNext.progress / 0.9f);
            yield return null;
        }
    }
}
