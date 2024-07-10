using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] GameObject shopPanel;
    [SerializeField] ItemSelection itemSelection;
    [SerializeField] ItemDisplay itemDisplayGO;

    [Header("Buy panel")]
    [SerializeField] GameObject buyPanel;
    [SerializeField] Transform availableItemsParent;
    [SerializeField] List<Customization_ItemHolder> purchasableItems;

    [Header("Sell panel")]
    [SerializeField] GameObject sellPanel;
    [SerializeField] Transform sellableItemsParent;

    private List<GameObject> instantiatedItems = new List<GameObject>();

    public void ShowBuyPanel()
    {
        sellPanel.SetActive(false);
        shopPanel.SetActive(true);
        buyPanel.SetActive(true);

        UpdateBuyShop();
    }

    public void UpdateBuyShop()
    {
        ClearElements();
        itemSelection.Deselect();

        foreach (Customization_ItemHolder customizationItem in purchasableItems)
        {
            if (!Character_Inventory.customizationItems.Contains(customizationItem))
            {
                ItemDisplay newItem = Instantiate(itemDisplayGO, availableItemsParent);
                newItem.Initialize(customizationItem, OnBuyingItem);
                instantiatedItems.Add(newItem.gameObject);
            }
        }
    }

    public void OnBuyingItem(Item item)
    {
        itemSelection.Select(item);
        itemSelection.BuyItem();
    }

    public void ShowSellPanel()
    {
        shopPanel.SetActive(true);
        sellPanel.SetActive(true);
        buyPanel.SetActive(false);

        UpdateSellShop();
    }

    public void OnSellingItem(Item item)
    {
        itemSelection.Select(item);
        itemSelection.SellItem();
    }

    public void UpdateSellShop()
    {
        ClearElements();
        itemSelection.Deselect();

        foreach (Item item in Character_Inventory.items)
        {
            ItemDisplay newItem = Instantiate(itemDisplayGO, sellableItemsParent);
            newItem.Initialize(item, OnSellingItem);
            instantiatedItems.Add(newItem.gameObject);
        }
    }

    private void ClearElements()
    {
        foreach (GameObject obj in instantiatedItems)
        {
            Destroy(obj);
        }
        instantiatedItems = new List<GameObject>();
    }
    public void Close()
    {
        ClearElements();
        shopPanel.SetActive(false);
    }
}
