using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{

    public const string SampleInterstitialAd = "testInterstitial";
    public const string SampleRewardedAd = "TestRewarded";
    public const string SammpleBannerAd = "testBanner";

    public string GameID
    {
        get
        {
    #if UNITY_ANDROID
            return "4365755";
    #elif UNITY_IOS
            return "4365754";
    //Fallback
    #else
            return "";
    #endif
        }
    }

    private void Awake()
    {
        Advertisement.Initialize(GameID, true);
    }

    public void ShowInterstitialAd()
    {
        if(Advertisement.IsReady(SampleInterstitialAd))
        {
            Advertisement.Show(SampleInterstitialAd);
        }
        else
        {
            Debug.Log("No Ads");
        }
    }
}
