using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipChangeManager : MonoBehaviour
{
    enum E_EQUIP_GROUP
    {
        Main,
        Sub,
    }
    [Header("�I�����������A�C�R��")]
    [SerializeField] private Image[] _selectedIcon;
    [Header("�I�𒆃O���[�v�A�C�R��")]
    [SerializeField] private Image[] _selectingGroup;
    [Header("�����O���[�v�ؑփ{�^��")]
    [SerializeField] private Button[] _groupChangeButton;
    [Header("�����O���[�v�I�u�W�F�N�g(Main or Sub")]
    [SerializeField] private GameObject[] _equipGroup;
    [Header("�I���\�����ꗗ")]
    [SerializeField] private ChangeEquip[] _selectableEquipButton;

    int[] _prevCommandID = new int[Constants.MAX_EQUIP_KIND];    // �O��̃R�}���hID

    private void Start()
    {
        for (int i = 0; i < Constants.MAX_EQUIP_KIND; ++i) {
            _prevCommandID[i] = -1;
        }
        foreach (var equip in _selectableEquipButton) {
            var button = equip.GetComponent<Button>();
            button.onClick.AddListener(() => SetSelectedEquip(equip.CommandID));
        }

        foreach(var equip in _groupChangeButton) {
            equip.onClick.AddListener(EqupGroupChange);
        }
    }

    //******************************
    // �I�����������ݒ�
    private void SetSelectedEquip(int commandID)
    {
        Debug.Log($"�I�������R�}���hID�F{commandID}");
        var kind = (int)(IsMainGroup ? E_EQUIP_GROUP.Main : E_EQUIP_GROUP.Sub);
        // �I�����������A�C�R����ݒ�
        var equipInfo = GameManager.Instance.GetEquipInfo(commandID);
        _selectedIcon[kind].sprite = equipInfo.icon;

        if (_prevCommandID[kind] == commandID) { return; }

        // �I�𒆂̑����𖾎��I�ɕ�����悤�ɐF��ύX
        SelectingColor(commandID, _prevCommandID[kind]);
        _prevCommandID[kind] = commandID;
    }

    //******************************
    // �I�𒆃J���[
    private void SelectingColor(int currentID, int prevID)
    {
        _selectableEquipButton[currentID].gameObject.GetComponent<Image>().color = Color.cyan;
        if (prevID >= 0) { _selectableEquipButton[prevID].gameObject.GetComponent<Image>().color = Color.white; }
    }

    //******************************
    // �I�𒆂̑����O���[�v
    private void SelectingEquipGroup()
    {
        string colorCode = "#FF00FF";
        Color color = default(Color);
        if (ColorUtility.TryParseHtmlString(colorCode, out color)) {
            var currentKind = (int)(IsMainGroup ? E_EQUIP_GROUP.Main : E_EQUIP_GROUP.Sub);
            var prevKind = (int)(IsMainGroup ? E_EQUIP_GROUP.Sub : E_EQUIP_GROUP.Main);
            _selectingGroup[currentKind].color = color;
            _selectingGroup[prevKind].color = Color.white;
        } else {
            Debug.LogError("�ϊ��Ɏ��s���܂���");
        }
    }

    //******************************
    // �����O���[�v�̐؂�ւ�
    public void EqupGroupChange()
    {
        if (_equipGroup[(int)E_EQUIP_GROUP.Main].gameObject.activeSelf) {
            _equipGroup[(int)E_EQUIP_GROUP.Main].SetActive(false);
            _equipGroup[(int)E_EQUIP_GROUP.Sub].SetActive(true);
        } else {
            _equipGroup[(int)E_EQUIP_GROUP.Main].SetActive(true);
            _equipGroup[(int)E_EQUIP_GROUP.Sub].SetActive(false);
        }

        SelectingEquipGroup();
    }

    //******************************
    // ���C���O���[�v���L����
    private bool IsMainGroup { get => _equipGroup[(int)E_EQUIP_GROUP.Main].gameObject.activeSelf; }
}
