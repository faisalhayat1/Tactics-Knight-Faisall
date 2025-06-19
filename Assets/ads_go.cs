using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ads_go : MonoBehaviour {
	
	private GameObject Rew;


//	private WWW www1;
//	private bool adsCheckOn;

	public string loadLevel;
	public bool showBanner;

	

	private float gameTimer;
	private string paramReward;

	private int loads;

	void Start ()
	{

		DontDestroyOnLoad(this.gameObject);

		Screen.sleepTimeout = SleepTimeout.NeverSleep;

	}


	void Update(){
		gameTimer += Time.deltaTime;

			/*
			if (gameTimer > 10 && adsCheckOn == false){
							adsCheckOn = true;
							string s;
							s = www1.text;
							if ( s == "1") {
								PlayerPrefs.SetInt("adsEnabled", 1);
							}
			}*/
	}

	public void ShowInterstitial()
	{


					if (PlayerPrefs.GetInt("noads") != 1 && gameTimer > 30)
					{

									Dictionary<string, object> parameters = new Dictionary<string, object>();
									parameters.Add("ad_type", "interstitial");
									parameters.Add("placement", "nextLevel");


            if (Gley.MobileAds.API.IsInterstitialAvailable())
            {
                parameters.Add("result", "success");

                gameTimer = 0;

                Dictionary<string, object> parameters2 = new Dictionary<string, object>();
                parameters2.Add("ad_type", "interstitial");
                parameters2.Add("placement", "nextLevel");
                parameters2.Add("result", "start");
                //AppMetrica.Instance.ReportEvent("video_ads_started", parameters2);

				Gley.MobileAds.Internal.MobileAdsExample.Instance.ShowInterstitial();


                Dictionary<string, object> parameters3 = new Dictionary<string, object>();
                parameters3.Add("ad_type", "interstitial");
                parameters3.Add("placement", "nextLevel");
                parameters3.Add("result", "watched");
                //AppMetrica.Instance.ReportEvent("video_ads_watch", parameters3);

                

            }
            else
            {
                parameters.Add("result", "not_availabe");
                /*	if(AppLovin.HasPreloadedInterstitial()){
                        AppLovin.ShowInterstitial();
                            AppLovin.PreloadInterstitial();
                    }*/
            }


            //AppMetrica.Instance.ReportEvent ("video_ads_available", parameters);
					}


	}

	public void ShowRewarded(string param)
	{
		// 1 - GetIt extra time
		// 2 - receive x2 coins
		// 3 - menu chest
		//
		paramReward = param;
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add("ad_type", "rewarded");
			parameters.Add("placement", paramReward);



        if (Gley.MobileAds.API.IsRewardedVideoAvailable())
        {
            parameters.Add("result", "success");

            Dictionary<string, object> parameters2 = new Dictionary<string, object>();
            parameters2.Add("ad_type", "rewarded");
            parameters2.Add("placement", paramReward);
            parameters2.Add("result", "start");
            //AppMetrica.Instance.ReportEvent("video_ads_started", parameters2);
			Gley.MobileAds.Internal.MobileAdsExample.Instance.ShowRewardedVideo();


		}
        else
        {

            parameters.Add("result", "not_available");
        }


        //AppMetrica.Instance.ReportEvent ("video_ads_available", parameters);
	}

	void ShowBanner()
	{
		if (PlayerPrefs.GetInt("noads") != 1)
		{
			Gley.MobileAds.Internal.MobileAdsExample.Instance.ShowBanner();
		}
	}

	void HideBanner()
	{
		if (PlayerPrefs.GetInt("noads") != 1){
			Gley.MobileAds.Internal.MobileAdsExample.Instance.HideBanner();
		}
	}

	
	
	

	


	//public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	//{

	//	// 1 - GetIt extra time
	//	// 2 - receive x2 coins
	//	// 3 - menu chest
	//	Dictionary<string, object> parameters = new Dictionary<string, object>();
	//	parameters.Add("levelNum", PlayerPrefs.GetInt("level"));
	//	AppMetrica.Instance.ReportEvent ("SkipLevel", parameters);

	//					PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level")+1);
	//					Application.LoadLevel(PlayerPrefs.GetInt("level")+"");



	//}


		

}
