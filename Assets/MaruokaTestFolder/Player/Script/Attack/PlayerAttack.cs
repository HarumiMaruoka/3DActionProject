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
    [Header("�m�F�p : ���C���E�G�|���ōU�����邩��\���^�U�l"), SerializeField] bool _isAttackMainWeaponID;
    [Header("�m�F�p : �T�u�E�G�|���ōU�����邩��\���^�U�l"), SerializeField] bool _isAttackSubWeaponID;

    [Header("InputManager < ButtonName > : Fire1�{�^���̖��O"), SerializeField] string _fire1ButtonName= "Fire1";
    [Header("InputManager < ButtonName > : Fire2�{�^���̖��O"), SerializeField] string _fire2ButtonName= "Fire2";

    [Header("Animator Parameters < ParameterName > : ���ݑ������Ă��郁�C���E�G�|����ID int Parameter Name"), SerializeField] string _animParameterName_int_MainWeaponID = "MainWeaponID";
    [Header("Animator Parameters < ParameterName > : ���ݑ������Ă���T�u�E�G�|����ID   int Parameter Name"), SerializeField] string _animParameterName_int_SubWeaponID = "SubWeaponID";
    [Header("Animator Parameters < ParameterName > : �U�����邩�ǂ�����\�����C���E�G�|���̐^�U�l bool Parameter Name"), SerializeField] string _animParameterName_bool_MainWeaponName = "IsFire1";
    [Header("Animator Parameters < ParameterName > : �U�����邩�ǂ�����\���T�u�E�G�|���̂̐^�U�l bool Parameter Name"), SerializeField] string _animParameterName_bool_SubWeaponName = "IsFire2";

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

    //<***************** �����o�[�֐� *****************>//

    //<***************** Unity���b�Z�[�W *****************>//
    void Start()
    {
        Init();
    }
    void Update()
    {
        Input_FireButton();
        Update_Attack();
        Update_AttackAnim();
    }

    //<***************** public���\�b�h *****************>//

    /// <summary> ���p���Ă��郁�C��������ID��ݒ肷��B </summary>
    /// <param name="value"> �V����ID </param>
    public void Set_CurrentlyEquippedMainWeaponID(int value)
    {
        _currentlyEquippedMainWeaponID = value;
    }
    /// <summary> ���p���Ă���T�u������ID��ݒ肷��B </summary>
    /// <param name="value"> �V����ID </param>
    public void Set_CurrentlyEquippedSubWeaponID(int value)
    {
        _currentlyEquippedSubWeaponID = value;
    }

    //<***************** private���\�b�h *****************>//

    /// <summary> ���������� </summary>
    void Init()
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
            if(On_Fire1ButtonDown!=null) On_Fire1ButtonDown();
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
        _animator.SetBool(_animParameterName_bool_MainWeaponName, _inputFire1ButtonDown);
        _animator.SetBool(_animParameterName_bool_SubWeaponName, _inputFire2ButtonDown);
    }
}
