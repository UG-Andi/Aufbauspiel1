using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AudioSourceTest : MonoBehaviour {

    public AudioSource source;

    public Slider volumeSlider;

    void Start()
    {
        source = GameObject.Find("Camera").GetComponent<AudioSource>();
        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
    }

    void Update()
    {
        source.volume = volumeSlider.value;
    }
}
