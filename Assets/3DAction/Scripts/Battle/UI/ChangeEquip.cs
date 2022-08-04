using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//************************************
// �퓬��ʂł̃R�}���h�I���{�^������
public class ChangeEquip : MonoBehaviour
{
    [SerializeField] private int _commandID;
    [SerializeField] private Image _icon;

    public int CommandID { get => _commandID; }
    public Image Icon { get => _icon; }

    private void Start()
    {
        var settingEquip = GameManager.Instance.GetEquipInfo(_commandID);
        _icon.sprite = settingEquip.icon;
    }
}
