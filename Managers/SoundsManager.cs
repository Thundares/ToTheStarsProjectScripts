using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundsManager : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField] private AudioSource audioSource = null;
    [Header("BGM")]
    [SerializeField] private AudioClip musicGround1;
    [SerializeField] private AudioClip musicGround2;
    [SerializeField] private AudioClip musicSky1;
    [Header("SE")]
    [SerializeField] private AudioClip splash;
    [Header("Variaveis")]
    [SerializeField] private float fadeOutTime = 0;

    private int random = 0;
    private bool over100 = false;
    private GameObject[] audioManagers;

    // Start is called before the first frame update
    void Awake()
    {
        audioManagers = GameObject.FindGameObjectsWithTag("Audio");
        // do not restart if already playing
        if (audioManagers.Length == 1) 
        {
            RandomMusic();
            audioSource.Play();
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(audioManagers[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!over100)
        {
            if (VariablesManager.dHeight > 100)
            {
                over100 = true;
                StartCoroutine(FadeOut());
                StartCoroutine(FadeIn(1));
            }
        }
        else 
        {
            if (VariablesManager.dHeight < 100) 
            {
                StartCoroutine(FadeOut());
                StartCoroutine(FadeIn(0));
                over100 = false;
            }
        }
    }

    public void PlayEffect(int index) 
    {
        if (index == 0) 
        {
            audioSource.PlayOneShot(splash, 0.2f);
        }
    }

    public IEnumerator FadeOut() 
    {
        float currentTime = 0;
        float initialVolume = audioSource.volume;

        while (currentTime < fadeOutTime) 
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(initialVolume, 0, currentTime / fadeOutTime);
            yield return null;
        }
        yield break;
    }

    public IEnumerator FadeIn(int index) 
    {
        float currentTime = 0;

        yield return new WaitForSeconds(fadeOutTime);

        if (index == 0)
        {
            RandomMusic();
        }
        else if (index == 1) 
        {
            audioSource.clip = musicSky1;
        }
        audioSource.Play();

        while (currentTime < fadeOutTime) 
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0,1, currentTime / fadeOutTime);
            yield return null;
        }
        yield break;
    }

    private void RandomMusic() 
    {
        random = Random.Range(0, 2);
        if (random == 0)
        {
            audioSource.clip = musicGround1;
        }
        else
        {
            audioSource.clip = musicGround2;
        }
    }
}
