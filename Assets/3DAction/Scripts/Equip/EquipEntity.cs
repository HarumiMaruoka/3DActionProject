/// <summary>
/// 概　要：装備エンティティ
/// 作成者：ta.kusumoto
/// 作成日：2022/08/04
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EquipEntity", menuName ="ScriptableObject/EquipInfoList")]
public class EquipEntity : ScriptableObject
{
    // 装備情報リスト
    public List<EquipInfo> _equipList = new List<EquipInfo> ();
}

//****************************
// 装備情報
[System.Serializable]
public class EquipInfo
{
    public int _id;
    public string _name;
    public Sprite _icon;
}