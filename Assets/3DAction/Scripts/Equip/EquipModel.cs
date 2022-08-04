//*********************************************
// 概　要：装備モデル
// 作成者：ta.kusumoto
// 作成日：2022/08/04

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipModel : MonoBehaviour
{
    int _equipID;
    Sprite _equipIcon;
    string _equipName;

    public EquipModel(EquipInfo info)
    {
        _equipID = info._id;
        _equipIcon = info._icon;
        _equipName = info._name;
    }

    public int EquipID { get => _equipID; }
    public Sprite EquipIcon { get => _equipIcon; }
    public string EquipName { get => _equipName; }
}
