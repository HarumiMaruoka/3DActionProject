using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �v���C���[�̍U�����Ǘ�����N���X </summary>
public class PlayerAttack : MonoBehaviour
{
    //info : ���̃N���X�ł́A��{�I�ɃL�[�{�[�h���͂��󂯎��A
    //       �U���\�ł���΁A�A�j���[�V�������Đ����A�A�j���[�V�����C�x���g������ۂ̍U���������s���B

    //<===== ���̃N���X�Ŏg�p����ϐ� =====>//
    /// <summary> �U���J�n���� </summary>
    public static event System.Action ActivationFire1;
    /// <summary> �U���I������ </summary>
    public static event System.Action FinishFire1;

    /// <summary> �U���J�n���� </summary>
    public static event System.Action ActivationFire2;
    /// <summary> �U���I������ </summary>
    public static event System.Action FinishFire2;

    /// <summary> ���ݑ������Ă��郁�C���E�F�|����ID </summary>
    [Header("���ݑ������Ă��郁�C���E�F�|����ID : �m�F�p"), SerializeField] int _mainWeaponID = 0;
    /// <summary> ���ݑ������Ă���T�u�E�F�|����ID </summary>
    [Header("���ݑ������Ă���T�u�E�F�|����ID : �m�F�p"), SerializeField] int _subWeaponID = 0;

    /// <summary> ���N���b�N�U�����\���ǂ��� </summary>
    [Header("���N���b�N�U�����\���ǂ��� : �m�F�p"), SerializeField] bool _isFireOne;
    /// <summary> �E�N���b�N�U�����\���ǂ��� </summary>
    [Header("�E�N���b�N�U�����\���ǂ��� : �m�F�p"), SerializeField] bool _isFireTow;
    /// <summary> ���g�ɃA�^�b�`����Ă���A�j���[�^�[ </summary>
    Animator _animator;

    //<===== �C���X�y�N�^����ݒ肷�ׂ��l =====>
    [Header("�A�j���[�^�[�̃p�����[�^�̖��O : ���C���E�G�|���� int Parameter Name"), SerializeField] string _animParameterName_int_MainWeaponID = "MainWeaponID";
    [Header("�A�j���[�^�[�̃p�����[�^�̖��O : �T�u�E�G�|����   int Parameter Name"), SerializeField] string _animParameterName_int_SubWeaponID = "SubWeaponID";
    [Header("�A�j���[�^�[�̃p�����[�^�̖��O : ���C���E�G�|���� bool Parameter Name"), SerializeField] string _animParameterName_bool_MainWeaponName = "Fire1";
    [Header("�A�j���[�^�[�̃p�����[�^�̖��O : �T�u�E�G�|����   bool Parameter Name"), SerializeField] string _animParameterName_bool_SubWeaponName = "Fire2";

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        AttackFireOne();
        AttackFireTow();
    }

    /// <summary> ���N���b�N���̋��� </summary>
    void AttackFireOne()
    {
        //���͂����� �A���A �U���\�ł���΍U������
        if (Input.GetButtonDown("Fire1") && _isFireOne)
        {
            Debug.Log("���s�I");
            //�A�j���[�V�����Ɍ��ݑ������Ă��镐���ID��n���B
            _animator.SetInteger(_animParameterName_int_MainWeaponID, _mainWeaponID);
            //�A�j���[�V�������Đ�
            _animator.SetBool(_animParameterName_bool_MainWeaponName, _isFireOne);
        }
        else if (_isFireOne && Input.GetButtonUp("Fire1"))
        {
            Debug.Log("aaa");
            _animator.SetBool(_animParameterName_bool_MainWeaponName, !_isFireOne);
        }
    }

    /// <summary> �E�N���b�N���̋��� </summary>
    void AttackFireTow()
    {
        //�U������
        if (Input.GetButtonDown("Fire2") && _isFireTow)
        {
            //�A�j���[�V�����Ɍ��ݑ������Ă��镐���ID��n���B
            _animator.SetInteger(_animParameterName_int_SubWeaponID, _subWeaponID);
            //�A�j���[�V�������Đ�
            _animator.SetBool(_animParameterName_bool_SubWeaponName, _isFireTow);
        }
        //��n��
        else if (_isFireTow && Input.GetButtonUp("Fire2"))
        {
            _animator.SetBool(_animParameterName_bool_SubWeaponName, !_isFireTow);
        }
    }

    /// <summary> ���ݑ������Ă��郁�C���E�F�|����ID��ݒ肷��B </summary>
    /// <param name="id"> �ݒ肷��ID </param>
    public void Set_MainWeaponID(int id)
    {
        _mainWeaponID = id;
    }

    /// <summary> ���ݑ������Ă���T�u�E�F�|����ID </summary>
    /// <param name="id"> �ݒ肷��ID </param>
    public void Set_SubWeaponID(int id)
    {
        _subWeaponID = id;
    }

    //<===== �ȉ��̊֐��͑S�āA�A�j���[�V�����C�x���g����Ăяo���֐��B =====>//
    /// <summary> �U���J�n���̏��� </summary>
    void OnAttack(int attackType)
    {
        //�U���s�ɂ���
        if (attackType == 1)
        {
            _isFireOne = false;
        }
        else if (attackType == 2)
        {
            _isFireTow = false;
        }
    }

    /// <summary> �U���\�ɂ���B </summary>
    void OffAttack(int attackType)
    {
        //�U���\�ɂ���
        if (attackType == 1)
        {
            _isFireOne = true;
        }
        else if (attackType == 2)
        {
            _isFireTow = true;
        }
    }

    /// <summary> �U������ </summary>
    void ActivationAttack_Fire1()
    {
        //�f���Q�[�g�ɓo�^���ꂽ
        //�U���J�n�֐����Ăяo���B
        ActivationFire1();
    }

    /// <summary> �U���I�� </summary>
    void FinishAttack_Fire1()
    {
        //�f���Q�[�g�ɓo�^���ꂽ
        //�U���I���֐����Ăяo���B
        FinishFire1();
    }

    /// <summary> �U������ </summary>
    void ActivationAttack_Fire2()
    {
        //�f���Q�[�g�ɓo�^���ꂽ
        //�U���J�n�֐����Ăяo���B
        ActivationFire2();
    }

    /// <summary> �U���I�� </summary>
    void FinishAttack_Fire2()
    {
        //�f���Q�[�g�ɓo�^���ꂽ
        //�U���I���֐����Ăяo���B
        FinishFire2();
    }
}