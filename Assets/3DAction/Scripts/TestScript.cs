using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    [SerializeField] private Button _equipClose;
    [SerializeField] private GameObject _settingDialog;

    private void Start()
    {
        _equipClose.onClick.AddListener(ToggleEquipSettingDialog);
    }

    // �����ݒ�_�C�A���O���J����
    private void ToggleEquipSettingDialog()
    {
        _settingDialog.SetActive(!_settingDialog.activeSelf);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void BackScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}