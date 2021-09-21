using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class AdsBannerController : MonoBehaviour
{
    [SerializeField]
    SwitchController controller;

    private BannerView bannerView;
    RewardedAd rewardedAd;

    public void Start()
    {
        RequestBanner();
    }

    private void RequestBanner()
    {

#if UNITY_ANDROID
        string bannerId = "ca-app-pub-7164181614025005/4328031436";
        string supportId = "ca-app-pub-7164181614025005/6131588760";
#endif

        bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);
        rewardedAd = new RewardedAd(supportId);



        #region reward request
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;


        AdRequest rewardDequest = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        rewardedAd.LoadAd(rewardDequest);
        #endregion

        #region banner request
        // Called when an ad request has successfully loaded.
        bannerView.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        bannerView.OnAdOpening += HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        bannerView.OnAdClosed += HandleOnAdClosed;

        // Create an empty ad request.
        AdRequest bannerRequest = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(bannerRequest);
        #endregion
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {

    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {

    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {

    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        AdRequest rewardDequest = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        rewardedAd.LoadAd(rewardDequest);
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        AdRequest rewardDequest = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        rewardedAd.LoadAd(rewardDequest);
        controller.addRewardedCount();
    }


    public void _UserChoseToWatchAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }
}
