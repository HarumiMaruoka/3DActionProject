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

    private SelectEquip _selectedCommand;       // 選択コマンド

    public void Initialize()
    {
        // TODO：データをロードして設定されてなければ初期値を設定
        for (int i = 0; i < Constants.MAX_EQUIP_SLOT; ++i) {
            SetEquipInfoImpl(i, -1, _initIcon, "");
        }
    }

    //*********************************************
    // コマンド情報を設定
    public void SetCommandInfo(GameObject command)
    {
        _selectedCommand = command.GetComponent<SelectEquip>();
    }

    //*********************************************
    // 装備情報を設定
    public void SetEquipInfo(GameObject equip)
    {
        // 選択したオブジェクトからモデルを取得する
        var conroller = equip.GetComponent<EquipController>();
        var model = conroller.EquipModel;
        _selectedCommand.Icon.sprite = model.EquipIcon;
        _selectedCommand.Name.text = model.EquipName;

        //EquipGroupData.Instance.Add(_selectedCommand);

        // 情報設定(データ共有用)
        SetEquipInfoImpl(_selectedCommand.CommandID, model.EquipID, model.EquipIcon, model.EquipName);
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
