using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EquipEntity", menuName ="ScriptableObject/EquipInfoList")]
public class EquipEntity : ScriptableObject
{
    // ‘•”õî•ñƒŠƒXƒg
    public List<EquipInfo> _equipList = new List<EquipInfo> ();
}

//****************************
// ‘•”õî•ñ
[System.Serializable]
public class EquipInfo
{
    public int _id;
    public string _name;
    public Sprite _icon;
}