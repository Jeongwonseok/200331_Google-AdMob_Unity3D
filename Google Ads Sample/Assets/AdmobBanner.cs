using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobBanner : MonoBehaviour
{
    // 테스트 광고용으로 일단 통일
    private readonly string unitID = "ca-app-pub-3940256099942544/6300978111";
    private readonly string test_unitID = "ca-app-pub-3940256099942544/6300978111";

    private readonly string test_deviceID = "33BE2250B43518CCDA7DE426D04EE231";

    // 생성된 광고뷰 오브젝트 저장 변수
    private BannerView banner;

    public AdPosition position;

    private void Start()
    {
        MobileAds.Initialize(
            (initStatus) =>
            {
                InitAd();

                var statusMap = initStatus.getAdapterStatusMap();

                foreach(var status in statusMap)
                {
                    Debug.Log($"{status.Key} : {status.Value}");
                }
            }        
        );
    }

    private void InitAd()
    {
        // 디버깅(테스트)용 아이디
        string id = Debug.isDebugBuild ? test_unitID : unitID;

        // 광고 배너 오브젝트 생성
        banner = new BannerView(id, AdSize.SmartBanner, position);

        // 광고 요청
        AdRequest request = new AdRequest.Builder().AddTestDevice(test_deviceID).Build();
        banner.LoadAd(request);
    }

    // 광고 종료 위한 토글 버튼 오브젝트
    public void ToggleAd(bool active)
    {
        if (active)
        {
            banner.Show();
        }
        else
        {
            banner.Hide();
        }
    }

    // 광고 오브젝트 파괴
    public void DestroyAd()
    {
        banner.Destroy();
    }
}
