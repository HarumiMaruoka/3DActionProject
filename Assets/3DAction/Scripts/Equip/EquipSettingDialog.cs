//*********************************************
// �T�@�v�F�����ݒ��ʊǗ���
// �쐬�ҁFta.kusumoto
// �쐬���F2022/08/04

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSettingDialog : MonoBehaviour
{
    [SerializeField] private Sprite _initIcon;  // �����A�C�R��

    private SelectEquip _selectedCommand;       // �I���R�}���h

    public void Initialize()
    {
        // TODO�F�f�[�^�����[�h���Đݒ肳��ĂȂ���Ώ����l��ݒ�
        for (int i = 0; i < Constants.MAX_EQUIP_SLOT; ++i) {
            SetEquipInfoImpl(i, -1, _initIcon, "");
        }
    }

    //*********************************************
    // �R�}���h����ݒ�
    public void SetCommandInfo(GameObject command)
    {
        _selectedCommand = command.GetComponent<SelectEquip>();
    }

    //*********************************************
    // ��������ݒ�
    public void SetEquipInfo(GameObject equip)
    {
        // �I�������I�u�W�F�N�g���烂�f�����擾����
        var conroller = equip.GetComponent<EquipController>();
        var model = conroller.EquipModel;
        _selectedCommand.Icon.sprite = model.EquipIcon;
        _selectedCommand.Name.text = model.EquipName;

        //EquipGroupData.Instance.Add(_selectedCommand);

        // ���ݒ�(�f�[�^���L�p)
        SetEquipInfoImpl(_selectedCommand.CommandID, model.EquipID, model.EquipIcon, model.EquipName);
    }

    //*********************************************
    // �������ݒ�
    private void SetEquipInfoImpl(int cmdID, int equipID, Sprite equipIcon, string equipName) {
        Debug.Log($"�ݒ肳�ꂽ�R�}���hID�F{cmdID}");
        GameManager.S_EQUIP_INFO equipInfo = new GameManager.S_EQUIP_INFO { 
            id = equipID, icon = equipIcon, name = equipName 
        };
        GameManager.Instance.SetEquipInfo(cmdID, equipInfo);
    }
}
