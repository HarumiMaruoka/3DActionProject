using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//******************************
// ゲーム管理者
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public struct S_EQUIP_INFO {
        public int id;
        public Sprite icon;
        public string name;
    };
    private S_EQUIP_INFO[] _equipList = new S_EQUIP_INFO[Constants.MAX_EQUIP_SLOT];  // 装備リスト

    //******************************
    // 装備情報関連
    public void SetEquipInfo(int cmdID, S_EQUIP_INFO info)
    {
        _equipList[cmdID].id = info.id;
        _equipList[cmdID].icon = info.icon;
        _equipList[cmdID].name = info.name;
    }
    public S_EQUIP_INFO GetEquipInfo(int cmdID)
    {
        return _equipList[cmdID];
    }
}