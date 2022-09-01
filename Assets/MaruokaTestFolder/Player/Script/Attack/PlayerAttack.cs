using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �U��������S������R���|�[�l���g </summary>
/// ���낢��쐬����������ōs�����Ǝv���B
public class PlayerAttack : MonoBehaviour
{
    //<***************** �����o�[�ϐ� *****************>//

    [Header("�m�F�p : ���ݑ������Ă��郁�C��������ID"), SerializeField] int _currentlyEquippedMainWeaponID;
    [Header("�m�F�p : ���ݑ������Ă���T�u������ID"), SerializeField] int _currentlyEquippedSubWeaponID;

    [Header("InputManager < AxesName > : Fire1�{�^���̖��O"), SerializeField] string _fire1ButtonName = "Fire1";
    [Header("InputManager < AxesName > : Fire2�{�^���̖��O"), SerializeField] string _fire2ButtonName = "Fire2";

    [Header("Animator < ParameterName > : ���ݑ������Ă��郁�C���E�G�|����ID int Parameter Name"), SerializeField]
    string _animParameterName_int_MainWeaponID = "MainWeaponID";
    [Header("Animator < ParameterName > : ���ݑ������Ă���T�u�E�G�|����ID   int Parameter Name"), SerializeField]
    string _animParameterName_int_SubWeaponID = "SubWeaponID";
    [Header("Animator < ParameterName > : �U�����邩�ǂ�����\�����C���E�G�|���̐^�U�l bool Parameter Name"), SerializeField]
    string _animParameterName_bool_MainWeaponName = "IsFire1";
    [Header("Animator < ParameterName > : �U�����邩�ǂ�����\���T�u�E�G�|���̂̐^�U�l bool Parameter Name")]
    [SerializeField]
    string _animParameterName_bool_SubWeaponName = "IsFire2";

    /// <summary> Fire1�������Ɏ��s����f���Q�[�g�ϐ��B </summary>
    public static System.Action On_Fire1ButtonDown;
    /// <summary> Fire2�������Ɏ��s����f���Q�[�g�ϐ��B </summary>
    public static System.Action On_Fire2ButtonDown;

    /// <summary> Fire1�����������Ǝ��s����f���Q�[�g�ϐ��B </summary>
    public static System.Action On_Fire1Button;
    /// <summary> Fire2�����������Ǝ��s����f���Q�[�g�ϐ��B </summary>
    public static System.Action On_Fire2Button;

    /// <summary> ���g�ɃA�^�b�`����Ă���AnimatorComponent </summary>
    Animator _animator;

    /// <summary> Fire1���������m����ϐ� : �������̂�true </summary>
    bool _inputFire1ButtonDown;
    /// <summary> Fire2���������m����ϐ� : �������̂�true </summary>
    bool _inputFire2ButtonDown;
    /// <summary> Fire1���������m����ϐ� : ������������true </summary>
    bool _inputFire1Button;
    /// <summary> Fire2���������m����ϐ� : ������������true </summary>
    bool _inputFire2Button;

    //<***************** Unity���b�Z�[�W *****************>//
    void Start()
    {
        Initialized();
    }
    void Update()
    {
        Input_FireButton();
        Update_Attack();
        Update_AttackAnim();
    }

    //<***************** public�����o�[�֐� *****************>//
    /// <summary> ���p���Ă��郁�C������ID��ݒ肷��B </summary>
    /// <param name="value"> �V����ID </param>
    public void Set_CurrentlyEquippedMainWeaponID(int value)
    {
        _currentlyEquippedMainWeaponID = value;
    }
    /// <summary> ���p���Ă���T�u����ID��ݒ肷��B </summary>
    /// <param name="value"> �V����ID </param>
    public void Set_CurrentlyEquippedSubWeaponID(int value)
    {
        _currentlyEquippedSubWeaponID = value;
    }

    //<***************** private�����o�[�֐� *****************>//
    /// <summary> ���������� </summary>
    void Initialized()
    {
        //�R���|�[�l���g���擾
        _animator = GetComponent<Animator>();
    }
    /// <summary> ���͏��� </summary>
    void Input_FireButton()
    {
        _inputFire1ButtonDown = Input.GetButtonDown(_fire1ButtonName);
        _inputFire2ButtonDown = Input.GetButtonDown(_fire2ButtonName);
        _inputFire1Button = Input.GetButton(_fire1ButtonName);
        _inputFire2Button = Input.GetButton(_fire2ButtonName);
    }
    /// <summary> �U���̍X�V���� </summary>
    void Update_Attack()
    {
        if (_inputFire1ButtonDown)//Fire1�������̂ݎ��s
        {
            if (On_Fire1ButtonDown != null) On_Fire1ButtonDown();
        }
        if (_inputFire2ButtonDown)//Fire2�������̂ݎ��s
        {
            if (On_Fire2ButtonDown != null) On_Fire2ButtonDown();
        }

        if (_inputFire1Button)//Fire1�����������Ǝ��s
        {
            if (On_Fire1Button != null) On_Fire1Button();
        }
        if (_inputFire2Button)//Fire2�����������Ǝ��s
        {
            if (On_Fire2Button != null) On_Fire2Button();
        }
    }
    /// <summary> �A�j���[�V�����p�����[�^�ɒl���Z�b�g����B </summary>
    void Update_AttackAnim()
    {
        //����ID��ݒ肷��B
        _animator.SetInteger(_animParameterName_int_MainWeaponID, _currentlyEquippedMainWeaponID);
        _animator.SetInteger(_animParameterName_int_SubWeaponID, _currentlyEquippedSubWeaponID);

        //�U���A�j���[�V�����ɑJ�ڂ��邩�ǂ����̒l��ݒ肷��B

        // ****************************************** ����m�F�̂��߃R�����g�A�E�g �������� ************************************************************************
        //�������̂� Fire1
        //if (On_Fire1ButtonDown != null) _animator.SetBool(_animParameterName_bool_MainWeaponName, _inputFire1ButtonDown);
        ////�������̂� Fire2
        //if (On_Fire2ButtonDown != null) _animator.SetBool(_animParameterName_bool_SubWeaponName, _inputFire2ButtonDown);
        ////������     Fire1
        //if (On_Fire1Button != null) _animator.SetBool(_animParameterName_bool_MainWeaponName, _inputFire1Button);
        ////������     Fire2
        //if (On_Fire2Button != null) _animator.SetBool(_animParameterName_bool_SubWeaponName, _inputFire2Button);
        // ******************************************  ����m�F�̂��߃R�����g�A�E�g �����܂� ********************************************************************************************

        // ****************************************** ����m�F�p���� �������� ***************************************************************************************
        //�������̂� Fire1
        _animator.SetBool(_animParameterName_bool_MainWeaponName, _inputFire1ButtonDown);
        //�������̂� Fire2
        _animator.SetBool(_animParameterName_bool_SubWeaponName, _inputFire2ButtonDown);
        // ****************************************** ����m�F�p���� �����܂� ********************************************************************************************
    }
}
