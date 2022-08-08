using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �U��������S������R���|�[�l���g </summary>
public class AttackPattern3 : MonoBehaviour
{
    /// <summary> Fire1�������Ɏ��s����f���Q�[�g�ϐ��B </summary>
    public static System.Action _fire1ButtonDown;
    /// <summary> Fire2�������Ɏ��s����f���Q�[�g�ϐ��B </summary>
    public static System.Action _fire2ButtonDown;

    /// <summary> Fire1�����������Ǝ��s����f���Q�[�g�ϐ��B </summary>
    public static System.Action _fire1Button;
    /// <summary> Fire2�����������Ǝ��s����f���Q�[�g�ϐ��B </summary>
    public static System.Action _fire2Button;

    [Header("Fire1�{�^���̖��O"), SerializeField] string _fire1ButtonName;
    [Header("Fire2�{�^���̖��O"), SerializeField] string _fire2ButtonName;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown(_fire1ButtonName))
        {
            _fire1ButtonDown();
        }
        if (Input.GetButtonDown(_fire2ButtonName))
        {
            _fire2ButtonDown();
        }
        if (Input.GetButton(_fire1ButtonName))
        {
            _fire1Button();
        }
        if (Input.GetButton(_fire2ButtonName))
        {
            _fire2Button();
        }
    }
}
