﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [SerializeField] ListView m_listView;
    [SerializeField] GameObject m_goodsItemPrefab;
    [SerializeField] Button m_shenbingButton;
    [SerializeField] Button m_daojuButton;
    [SerializeField] Button m_addButton;
    [SerializeField] Button m_deleteButton;
    [SerializeField] Button m_convertButton;
    [SerializeField] Text m_amountText;

    List<GoodsData> m_shenbingDataList;
    List<GoodsData> m_daojuDataList;
    List<GoodsData> currentList => isShowShenbingList ? m_shenbingDataList : m_daojuDataList;

    bool isShowShenbingList;
    int m_amount;
    
    void Start()
    {
        m_shenbingDataList = new List<GoodsData>
        {
            new GoodsData("蔷薇剑", 2000),
            new GoodsData("木叶飞刀", 3000),
            new GoodsData("百晓生", 5000),
            new GoodsData("孔雀翎", 10000),
            new GoodsData("大悲赋", 12000),
        };
        
        m_daojuDataList = new List<GoodsData>
        {
            new GoodsData("道具0", 12000),
            new GoodsData("道具1", 12000),
            new GoodsData("道具2", 12000),
            new GoodsData("道具3", 12000),
            new GoodsData("道具4", 12000),
            new GoodsData("道具5", 12000),
            new GoodsData("道具6", 12000),
            new GoodsData("道具7", 12000),
            new GoodsData("道具8", 12000),
            new GoodsData("道具9", 12000),
            new GoodsData("道具10", 12000),
            new GoodsData("道具11", 12000),
            new GoodsData("道具12", 12000),
            new GoodsData("道具13", 12000),
            new GoodsData("道具14", 12000),
            new GoodsData("道具15", 12000),
            new GoodsData("道具16", 12000),
            new GoodsData("道具17", 12000),
            new GoodsData("道具18", 12000),
            new GoodsData("道具19", 12000),
            new GoodsData("道具20", 12000),
            new GoodsData("道具21", 12000),
            new GoodsData("道具22", 12000),
            new GoodsData("道具23", 12000),
            new GoodsData("道具24", 12000),
            new GoodsData("道具25", 12000),
            new GoodsData("道具26", 12000),
            new GoodsData("道具27", 12000),
            new GoodsData("道具28", 12000),
            new GoodsData("道具29", 12000),
            new GoodsData("道具30", 12000),
            new GoodsData("道具31", 12000),
            new GoodsData("道具32", 12000),
            new GoodsData("道具33", 12000),
            new GoodsData("道具34", 12000),
            new GoodsData("道具35", 12000),
            new GoodsData("道具36", 12000),
            new GoodsData("道具37", 12000),
            new GoodsData("道具38", 12000),
            new GoodsData("道具39", 12000),
        };
        
        m_shenbingButton.onClick.AddListener(OnShenbingClicked);
        m_daojuButton.onClick.AddListener(OnDaojuClicked);
        m_addButton.onClick.AddListener(OnAddClicked);
        m_deleteButton.onClick.AddListener(OnDeleteClicked);
        m_convertButton.onClick.AddListener(OnConvertClicked);

        isShowShenbingList = true;
        m_listView.Init(m_goodsItemPrefab, OnItemRefresh, OnItemValueChange, OnItemClick);
        m_listView.onSelectedItemCleared = OnListViewSelectedItemCleared;
        m_listView.itemCount = m_shenbingDataList.Count;
    }

    void OnShenbingClicked()
    {
        isShowShenbingList = true;
        m_listView.itemCount = m_shenbingDataList.Count;
    }

    void OnDaojuClicked()
    {
        isShowShenbingList = false;
        m_listView.itemCount = m_daojuDataList.Count;
    }

    void OnAddClicked()
    {
        if (m_listView.isVirtual)
        {
            currentList.Add(new GoodsData("新增物品", 555));
            m_listView.itemCount = currentList.Count;
        }
        else
        {
            currentList.Add(new GoodsData("新增物品", 555));
            OnItemRefresh(currentList.Count - 1, m_listView.AddItem());
        }
    }
    
    void OnDeleteClicked()
    {
        if (m_listView.isVirtual)
        {
            currentList.RemoveAt(currentList.Count - 1);
            m_listView.itemCount = currentList.Count;
        }
        else
        {
            m_listView.RemoveItem(m_listView.itemCount - 1);
        }
    }

    void OnConvertClicked()
    {
        m_listView.SetVirtual();
    }
    
    void OnItemRefresh(int index, ListViewItem item)
    {
        // Debug.Log("OnItemRefresh:"+index);
        GoodsItem goodsItem = item as GoodsItem;
        goodsItem.Init(currentList[index]);
    }

    void OnItemClick(ListViewItem item)
    {
        // Debug.Log("OnItemClick");
    }
    
    void OnItemValueChange(int index, bool isSelected)
    {
        Debug.Log($"OnItemValueChange:{index}  {isSelected}");
        GoodsData data = currentList[index];
        m_amount = m_amount + (isSelected ? 1 : -1) * data.price;
        m_amountText.text = $"总额：{m_amount}";
    }

    void OnListViewSelectedItemCleared()
    {
        m_amount = 0;
        m_amountText.text = $"总额：{m_amount}";
    }
}
