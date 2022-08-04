using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EquipEntity", menuName ="ScriptableObject/EquipInfoList")]
public class EquipEntity : ScriptableObject
{
    // ������񃊃X�g
    public List<EquipInfo> _equipList = new List<EquipInfo> ();
}

//****************************
// �������
[System.Serializable]
public class EquipInfo
{
    public int _id;
    public string _name;
    public Sprite _icon;
}