using System.Collections;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField] private AudioSource musicSource = null;
    [SerializeField] private AudioSource seSource = null;
    [Header("BGM")]
    [SerializeField] private AudioClip musicGround1;
    [SerializeField] private AudioClip musicGround2;
    [SerializeField] private AudioClip musicSky1;
    [Header("SE")]
    [SerializeField] private AudioClip splash;
    [Header("Variaveis")]
    [SerializeField] private float fadeOutTime = 0;

    private int random = 0;
    private bool over1000 = false;
    private GameObject[] audioManagers;

    // Start is called before the first frame update
    void Awake()
    {
        audioManagers = GameObject.FindGameObjectsWithTag("Audio");
        // do not restart if already playing
        if (audioManagers.Length == 1) 
        {
            RandomMusic();
            musicSource.Play();
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            musicSource = this.GetComponent<AudioSource>();
            Destroy(audioManagers[1]);
        }
    }

    // Update is called once per frame
    public void CheckMusic()
    {
        if (!over1000)
        {
            if (VariablesManager.dHeight > 1000)
            {
                over1000 = true;
                StartCoroutine(FadeOut());
                StartCoroutine(FadeIn(1));
            }
        }
        else 
        {
            if (VariablesManager.dHeight < 1000) 
            {
                StartCoroutine(FadeOut());
                StartCoroutine(FadeIn(0));
                over1000 = false;
            }
        }
    }

    public void PlayEffect(int index) 
    {
        if (index == 0) 
        {
            seSource.PlayOneShot(splash, 0.2f);
        }
    }

    public IEnumerator FadeOut() 
    {
        float currentTime = 0;
        float initialVolume = musicSource.volume;

        while (currentTime < fadeOutTime) 
        {
            currentTime += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(initialVolume, 0, currentTime / fadeOutTime);
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
            musicSource.clip = musicSky1;
        }
        musicSource.Play();

        while (currentTime < fadeOutTime) 
        {
            currentTime += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(0,1, currentTime / fadeOutTime);
            yield return null;
        }
        yield break;
    }

    private void RandomMusic() 
    {
        random = Random.Range(0, 2);
        if (random == 0)
        {
            musicSource.clip = musicGround1;
        }
        else
        {
            musicSource.clip = musicGround2;
        }
    }
}
