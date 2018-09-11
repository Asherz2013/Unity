using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager is NULL!");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    #endregion

    public Text playerGemCountText;
    public Image selectionImg;
    public Text GemCountText;

    public Image[] LiveUnits;

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = gemCount + "G";
    }

    public void UpdateShopSelection(int posY)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector3(selectionImg.rectTransform.anchoredPosition.x, posY);
    }

    public void UpdateGemCount(int count)
    {
        GemCountText.text = "" + count;
    }

    public void UpdateLives(int livesRemaining)
    {
        // Loop through "LiveUnits"
        for (int i = 0; i < LiveUnits.Length; i++)
        {
            // If i == livesRemaining
            if(i == livesRemaining)
            {
                // Hide it.
                LiveUnits[i].enabled = false;
            }

        }
    }
}
