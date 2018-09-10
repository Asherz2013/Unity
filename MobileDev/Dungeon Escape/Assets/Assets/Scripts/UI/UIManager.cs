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
    #endregion

    public Text playerGemCountText;
    public Image selectionImg;

    private void Awake()
    {
        _instance = this;
    }

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = gemCount + "G";
    }

    public void UpdateShopSelection(int posY)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector3(selectionImg.rectTransform.anchoredPosition.x, posY);
    }
}
