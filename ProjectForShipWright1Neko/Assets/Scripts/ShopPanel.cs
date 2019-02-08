﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour

{

    [SerializeField] List<Item> items;
    [SerializeField] List<TextMeshProUGUI> MenuItemNames;
    [SerializeField] List<TextMeshProUGUI> MenuItemCosts;
    [SerializeField] List<GameObject> MenuItemImages;
    [SerializeField] TextMeshProUGUI pageText;

    Item item;
    int page = 1;
    
    public List<Item> Items { get => items; set => items = value; }



    public void Update()
    {
        TogglePageButtons();

        UpdateItemList();

        pageText.text = page.ToString() + " Of " + GetPageCount().ToString() ;
 
    }

    private void UpdateItemList()
    {
        for (int itemNum = 0; itemNum < 4; itemNum++)
        {
            var currentItem = items[itemNum + ((page - 1) * 4)];
            string currentItemName = currentItem.ItemName;
            string currentItemCost = currentItem.ItemCost.ToString();
            var currentItemSprite = currentItem.GetComponent<SpriteRenderer>().sprite;
            MenuItemNames[itemNum].text = currentItemName;
            MenuItemCosts[itemNum].text = currentItemCost;
            MenuItemImages[itemNum].GetComponent<Image>().sprite = currentItemSprite;
        }
    }

    public int itemsListLength()
    {
        return items.Count;
    }


    public void NextPage()
    {
        Debug.Log("Next Page!");
        page++;
    }


    public void PreviousPage()
    {
        Debug.Log("Previus Page!");
        page--;
    }


    public int GetPageCount()
    {
        ShopPanel shopPanel = GetComponent<ShopPanel>();
        int records = shopPanel.itemsListLength();
        int pageCount = (records + 3) / 4;
        return pageCount;
    }

    private void TogglePageButtons()
    {
        if (page == 1)
        {
            GameObject.Find("Previous Page").GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Previous Page").GetComponent<Button>().enabled = false;
        }
        else
        {
            GameObject.Find("Previous Page").GetComponent<TextMeshProUGUI>().enabled = true;
            GameObject.Find("Previous Page").GetComponent<Button>().enabled = true;
        }

        if (page == GetPageCount())
        {
            GameObject.Find("Next Page").GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Next Page").GetComponent<Button>().enabled = false;
        }
        else
        {
            GameObject.Find("Next Page").GetComponent<TextMeshProUGUI>().enabled = true;
            GameObject.Find("Next Page").GetComponent<Button>().enabled = true;
        }
    } 

}
