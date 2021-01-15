
using UnityEngine;
using UnityEngine.UI;

public class BackgroundTheme : MonoBehaviour
{
    public static BackgroundTheme instance = null;
    private AudioSource backgroundTheme;
    private Slider slider;
    public void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        
        
    }

    public void Start()
    {
        slider = FindObjectOfType<Canvas>()?.transform.GetChild(1)?.GetChild(2)?.GetComponent<Slider>();;
        
        backgroundTheme = GetComponent<AudioSource>();
        slider.value = PlayerPrefs.GetFloat("sliderValue");
        


    }

    public void OnSliderChanged()
    {
        if (slider != null)
        {
            backgroundTheme.volume = slider.value;
            PlayerPrefs.SetFloat("sliderValue", slider.value);
        }
        
    }
}
