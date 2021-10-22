using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioMixer am = null;
    [SerializeField] private bool master = false;
    [SerializeField] private bool music = false;
    [SerializeField] private bool SE = false;

    public void VolumeChange(float volume) 
    {
        if (master)
        {
            am.SetFloat("volume", TranslatorValues(volume));
        }
        else if (music)
        {
            am.SetFloat("musicVolume", TranslatorValues(volume));
        }
        else if (SE) 
        {
            am.SetFloat("seVolume", TranslatorValues(volume));
        }
    }

    private float TranslatorValues(float value05) 
    {
        if (value05 < 0.5f) 
        {
            return -80f;
        }
        if (value05 < 1.5f) 
        {
            return -40f;
        }
        if (value05 < 2.5f) 
        {
            return -20f;
        }
        if (value05 < 3.5f) 
        {
            return -10f;
        }
        if (value05 < 4.5f) 
        {
            return -5f;
        }
        // then it is 5
        return 0;
    }
}
