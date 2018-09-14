using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class AdsManager : MonoBehaviour
{
    public void ShowRewardedAd()
    {
#if UNITY_ADS
        const string RewardedPlacement = "rewardedVideo";

        if(!Advertisement.IsReady(RewardedPlacement))
        {
            Debug.Log("Advertisement is NOT ready");
            return;
        }

        var Options = new ShowOptions { resultCallback = HandleShowResult };

        Advertisement.Show(RewardedPlacement, Options);
#endif
    }

#if UNITY_ADS
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                GameManager.Instance.Player.AddGems(100);
                UIManager.Instance.OpenShop(GameManager.Instance.Player._diamondCount);
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
#endif
}
