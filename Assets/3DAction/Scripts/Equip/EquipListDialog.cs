//*********************************************
// �T�@�v�F�����ꗗ�Ǘ���
// �쐬�ҁFta.kusumoto
// �쐬���F2022/08/04

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EquipListDialog : MonoBehaviour
{
    [SerializeField] private EquipController _equipPrefab;
    [SerializeField] private Transform _content;

    private Button[] _selectedListItems;

    // �����A�C�e�����ꊇ�Ŏ擾
    public Button[] SelectedListItems { get => _selectedListItems; }

    // ������
    public void Initialize()
    {
        // �������X�g���C���X�^���X����
        EquipEntity entity = Resources.Load<EquipEntity>("ScriptableObject/EquipList");
        foreach (var equip in entity._equipList) {
            var controller = Instantiate(_equipPrefab, _content, false);
            controller.Initialize(equip);
        }

        _selectedListItems = GetComponentsInChildren<Button>();
    }

    // �����ꗗ�̕\��/��\����؂�ւ���
    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
