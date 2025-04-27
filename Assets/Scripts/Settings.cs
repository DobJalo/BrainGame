using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    private const string VolumeKey = "Volume"; //save slot

    void Start()
    {
        if (PlayerPrefs.HasKey(VolumeKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(VolumeKey);
            audioSource.volume = savedVolume;
            volumeSlider.value = savedVolume;
        }
        else
        {
            volumeSlider.value = audioSource.volume;
        }

        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    void ChangeVolume(float value)
    {
        audioSource.volume = value;
        Debug.Log(audioSource.volume);
        PlayerPrefs.SetFloat(VolumeKey, value); 
        PlayerPrefs.Save();
    }



    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
