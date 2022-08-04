//*********************************************
// 概　要：装備設定画面管理者
// 作成者：ta.kusumoto
// 作成日：2022/08/04

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSettingDialog : MonoBehaviour
{
    [SerializeField] private Sprite _initIcon;  // 初期アイコン
    private EquipSelectButton _selectedButton;  // 選択コマンド

    //*********************************************
    // 初期化
    public void Initialize()
    {
        // 一旦全スロットを初期化
        for (int i = 0; i < Constants.MAX_EQUIP_SLOT; ++i) {
            SetEquipInfoImpl(i, -1, _initIcon, "");
        }
        // 情報があるスロットのみ更新
        var datas = EquipGroupData.Instance.EquipDatas;
        var selectButtons = GetComponentsInChildren<EquipSelectButton>();
        foreach (var data in datas) {
            selectButtons[data.CommandID].Icon.sprite = data.EquipIcon;
            selectButtons[data.CommandID].Name.text = data.EquipName;
            SetEquipInfoImpl(data.CommandID, data.EquipID, data.EquipIcon, data.EquipName);
        }
    }

    //*********************************************
    // コマンド情報を設定
    public void SetCommandInfo(GameObject command)
    {
        _selectedButton = command.GetComponent<EquipSelectButton>();
    }

    //*********************************************
    // 装備情報を設定
    public void SetEquipInfo(GameObject equip)
    {
        // 選択したオブジェクトからモデルを取得する
        var conroller = equip.GetComponent<EquipController>();
        var model = conroller.EquipModel;
        _selectedButton.Icon.sprite = model.EquipIcon;
        _selectedButton.Name.text = model.EquipName;

        MemoryEquipInfo(_selectedButton.CommandID, model);

        // 情報設定(データ共有用)
        SetEquipInfoImpl(_selectedButton.CommandID, model.EquipID, model.EquipIcon, model.EquipName);
    }

    //*********************************************
    // 装備情報記憶
    private void MemoryEquipInfo(int commandID, EquipModel model)
    {
        // データをJSONに覚えさせる
        EquipGroupData.Instance.AddEquip(commandID, model);
        EquipGroupData.Instance.Save();
    }

    //*********************************************
    // 装備情報設定
    private void SetEquipInfoImpl(int cmdID, int equipID, Sprite equipIcon, string equipName) {
        Debug.Log($"設定されたコマンドID：{cmdID}");
        GameManager.S_EQUIP_INFO equipInfo = new GameManager.S_EQUIP_INFO { 
            id = equipID, icon = equipIcon, name = equipName 
        };
        GameManager.Instance.SetEquipInfo(cmdID, equipInfo);
    }
}
