using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobScreenAd : MonoBehaviour
{
    private readonly string unitID = "ca-app-pub-3940256099942544/1033173712";
    private readonly string test_unitID = "ca-app-pub-3940256099942544/1033173712";

    private readonly string test_deviceID = "";

    private InterstitialAd screedAd;

    private void Start()
    {
        InitAd();
        Invoke("Show", 10f);
    }

    private void InitAd()
    {
        string id = Debug.isDebugBuild ? test_unitID : unitID;

        screedAd = new InterstitialAd(id);

        AdRequest request = new AdRequest.Builder().Build();

        screedAd.LoadAd(request);

        screedAd.OnAdClosed += (sender, e) => Debug.Log("광고가 닫힘");
        screedAd.OnAdLoaded += (sender, e) => Debug.Log("광고가 로드됨");
    }

    public void Show()
    {
        StartCoroutine(ShowScreedAd());
    }

    private IEnumerator ShowScreedAd()
    {
        while(!screedAd.IsLoaded())
        {
            yield return null;
        }

        screedAd.Show();
    }
}
