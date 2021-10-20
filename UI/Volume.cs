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
            am.SetFloat("volume", volume);
        }
        else if (music)
        {
            am.SetFloat("musicVolume", volume);
        }
        else if (SE) 
        {
            am.SetFloat("seVolume", volume);
        }
    }
}
