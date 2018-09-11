using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public GameObject shopPanel;
    private int currentSelectedItem;
    private int currentItemCost;

    private Player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            if (player)
            {
                UIManager.Instance.OpenShop(player._diamondCount);
            }
            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        currentSelectedItem = item;
        switch (item)
        {
            default:
                UIManager.Instance.UpdateShopSelection(57);
                currentItemCost = 200;
                break;

            case 1:
                UIManager.Instance.UpdateShopSelection(-40);
                currentItemCost = 400;
                break;

            case 2:
                UIManager.Instance.UpdateShopSelection(-135);
                currentItemCost = 100;
                break;
        }
    }

    public void BuyCurrentSelected()
    {
        // Check if PlayerGems >= item cost
        if (player._diamondCount >= currentItemCost)
        {
            // if it is then award item
            switch (currentSelectedItem)
            {
                default:
                    break;

                case 1:
                    break;

                case 2:
                    GameManager.Instance.HasKeyToCastle = true;
                    break;
            }

            player._diamondCount -= currentItemCost;
        }
        else
        {
            Debug.Log("You do NOT have enough Gems! Closing shop");
        }
        shopPanel.SetActive(false);
    }
}
