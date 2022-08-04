using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//*********************************************
// ������ʊǗ���
public class EquipWindowManager : MonoBehaviour
{
    [SerializeField] private EquipSettingDialog _equipSettingDialog;        // �����ݒ�E�B���h�E
    [SerializeField] private EquipListDialog _equipListDialog;              // �����ꗗ�E�B���h�E
    [SerializeField] private List<Button> _buttons = new List<Button>();    // �{�^�����X�g(�R�}���h)

    private Button[] _selectListItem;

    private void Start()
    {
        // �e��_�C�A���O�̏�����
        _equipSettingDialog.Initialize();
        _equipListDialog.Initialize();
        // �{�^���������̏���
        foreach(var button in _buttons) {
            button.onClick.AddListener(ToggleEquipListDialog);
        }
        foreach(var button in _equipListDialog.SelectedListItems) {
            button.onClick.AddListener(SetEquipInfo);
        }
    }

    // �����ꗗ�E�B���h�E�J����
    private void ToggleEquipListDialog()
    {
        Debug.Log("�����ꗗ�E�B���h�E���J���܂�");
        var commandObject = EventSystem.current.currentSelectedGameObject;
        _equipSettingDialog.SetCommandInfo(commandObject);
        _equipListDialog.Toggle();
    }

    // ��������ݒ�
    private void SetEquipInfo()
    {
        Debug.Log("�������I������܂���");
        var selectObject = EventSystem.current.currentSelectedGameObject;
        _equipSettingDialog.SetEquipInfo(selectObject);
        _equipListDialog.Toggle();
    }
}