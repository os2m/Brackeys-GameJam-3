using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    private AudioSource audioSrc;

    public float musicVolume = 1f;
    public bool found;

    // Use this for initialization
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject slider_gameobject = GameObject.FindWithTag("Slider");

        if (slider_gameobject)
        {
            Slider slider = slider_gameobject.GetComponent<Slider>();

            if (slider)
            {
                if (!found)
                {
                    slider.value = musicVolume;
                    found = true;
                }

                else
                {
                    musicVolume = slider.value;
                }
                audioSrc.volume = musicVolume;
            }
        }
        else
        {
            found = false;
        }
    }
}