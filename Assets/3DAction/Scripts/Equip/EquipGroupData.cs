using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class EquipGroupData
{
    private const string _playerPrefsKey = "EQUIP_DATA";
    private static EquipData _instance;
    private EquipData[] _equipDatas = new EquipData[Constants.MAX_EQUIP_SLOT];

    // �V���O���g��
    public static EquipData Instance
    {
        get
        {
            if(_instance == null) {
                _instance = PlayerPrefs.HasKey(_playerPrefsKey) ? JsonUtility.FromJson<EquipData>(PlayerPrefs.GetString(_playerPrefsKey)) : new EquipData();
            }
            return _instance;
        }
    }
    private EquipGroupData(){}

    public void Add(GameObject equip)
    {
        var conroller = equip.GetComponent<EquipController>();
        var model = conroller.EquipModel;
    }

    // �Ώۂ̑����f�[�^���擾����
    public EquipData GetEquip(int commandID)
    {
        return _equipDatas.FirstOrDefault(x => x.Id == commandID);
    }

    // �����f�[�^�ꗗ���擾
    public EquipData[] EquipDatas { get => _equipDatas.ToArray(); }

    // JSON������PlayerPrefs�ɕۑ�
    public void Save()
    {
        var jsonString = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(_playerPrefsKey, jsonString);
        PlayerPrefs.Save();
    }

    [Serializable]
    public class EquipData
    {
        private int _id;
        private Image _icon;
        private string _name;

        public int Id { get => _id; }
        public Image Icon { get => _icon; }
        public string Name { get => _name; }
    }
}
