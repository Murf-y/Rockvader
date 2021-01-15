using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance;
    private const string PlayStoreID = "3964335";
    private const string InterstitialAd = "video";
    private const bool IsTestAd = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
        InitializeAdvertisment();
    }

    private void InitializeAdvertisment()
    { 
        Advertisement.Initialize(PlayStoreID,IsTestAd);
    }


    public void PlayInterstitialAd()
    {
        
        if(!Advertisement.IsReady(InterstitialAd)){return;}
        Advertisement.Show(InterstitialAd);

        
    }
}
