using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] private GameObject spiderPrefab = null;
    [SerializeField] private AudioSource seSource = null;
    [SerializeField] private AudioClip spiderSe = null;
    private bool trigged = false;

    public void CheckSpider()
    {
        if (VariablesManager.dHeight >= 443 && !trigged)
        {
            seSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
            trigged = true;
            seSource.PlayOneShot(spiderSe);
            GameObject spider = Instantiate(spiderPrefab, GameObject.FindGameObjectWithTag("egg").transform);
            Destroy(spider, 10f);
            this.gameObject.SetActive(false);
        }
    }
}

