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
    private EquipSelectButton _selectedButton;  // �I���R�}���h

    //*********************************************
    // ������
    public void Initialize()
    {
        // ��U�S�X���b�g��������
        for (int i = 0; i < Constants.MAX_EQUIP_SLOT; ++i) {
            SetEquipInfoImpl(i, -1, _initIcon, "");
        }
        // ��񂪂���X���b�g�̂ݍX�V
        var datas = EquipGroupData.Instance.EquipDatas;
        var selectButtons = GetComponentsInChildren<EquipSelectButton>();
        foreach (var data in datas) {
            selectButtons[data.CommandID].Icon.sprite = data.EquipIcon;
            selectButtons[data.CommandID].Name.text = data.EquipName;
            SetEquipInfoImpl(data.CommandID, data.EquipID, data.EquipIcon, data.EquipName);
        }
    }

    //*********************************************
    // �R�}���h����ݒ�
    public void SetCommandInfo(GameObject command)
    {
        _selectedButton = command.GetComponent<EquipSelectButton>();
    }

    //*********************************************
    // ��������ݒ�
    public void SetEquipInfo(GameObject equip)
    {
        // �I�������I�u�W�F�N�g���烂�f�����擾����
        var conroller = equip.GetComponent<EquipController>();
        var model = conroller.EquipModel;
        _selectedButton.Icon.sprite = model.EquipIcon;
        _selectedButton.Name.text = model.EquipName;

        MemoryEquipInfo(_selectedButton.CommandID, model);

        // ���ݒ�(�f�[�^���L�p)
        SetEquipInfoImpl(_selectedButton.CommandID, model.EquipID, model.EquipIcon, model.EquipName);
    }

    //*********************************************
    // �������L��
    private void MemoryEquipInfo(int commandID, EquipModel model)
    {
        // �f�[�^��JSON�Ɋo��������
        EquipGroupData.Instance.AddEquip(commandID, model);
        EquipGroupData.Instance.Save();
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
