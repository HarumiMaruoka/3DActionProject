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
    [Header("選択した装備アイコン")]
    [SerializeField] private Image[] _selectedIcon;
    [Header("選択中グループアイコン")]
    [SerializeField] private Image[] _selectingGroup;
    [Header("装備グループ切替ボタン")]
    [SerializeField] private Button[] _groupChangeButton;
    [Header("装備グループオブジェクト(Main or Sub")]
    [SerializeField] private GameObject[] _equipGroup;
    [Header("選択可能装備一覧")]
    [SerializeField] private ChangeEquip[] _selectableEquipButton;

    int[] _prevCommandID = new int[Constants.MAX_EQUIP_KIND];    // 前回のコマンドID

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
    // 選択した装備設定
    private void SetSelectedEquip(int commandID)
    {
        Debug.Log($"選択したコマンドID：{commandID}");
        var kind = (int)(IsMainGroup ? E_EQUIP_GROUP.Main : E_EQUIP_GROUP.Sub);
        // 選択した装備アイコンを設定
        var equipInfo = GameManager.Instance.GetEquipInfo(commandID);
        _selectedIcon[kind].sprite = equipInfo.icon;

        if (_prevCommandID[kind] == commandID) { return; }

        // 選択中の装備を明示的に分かるように色を変更
        SelectingColor(commandID, _prevCommandID[kind]);
        _prevCommandID[kind] = commandID;
    }

    //******************************
    // 選択中カラー
    private void SelectingColor(int currentID, int prevID)
    {
        _selectableEquipButton[currentID].gameObject.GetComponent<Image>().color = Color.cyan;
        if (prevID >= 0) { _selectableEquipButton[prevID].gameObject.GetComponent<Image>().color = Color.white; }
    }

    //******************************
    // 選択中の装備グループ
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
            Debug.LogError("変換に失敗しました");
        }
    }

    //******************************
    // 装備グループの切り替え
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
    // メイングループが有効化
    private bool IsMainGroup { get => _equipGroup[(int)E_EQUIP_GROUP.Main].gameObject.activeSelf; }
}
