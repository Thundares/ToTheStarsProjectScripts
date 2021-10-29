using UnityEngine;

public class Astral : MonoBehaviour
{
    [SerializeField] private GameObject astralPrefab = null;
    [SerializeField] private AudioSource seSource = null;
    [SerializeField] private AudioClip astralSe = null;
    private bool trigged = false;

    public void CheckAstral()
    {
        if (VariablesManager.dHeight >= 100000 && !trigged)
        {
            seSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
            trigged = true;
            seSource.PlayOneShot(astralSe);
            GameObject astral = Instantiate(astralPrefab, GameObject.FindGameObjectWithTag("egg").transform);
            Destroy(astral, 10f);
            this.gameObject.SetActive(false);
        }
    }
}

