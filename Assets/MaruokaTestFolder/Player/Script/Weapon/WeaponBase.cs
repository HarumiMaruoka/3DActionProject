using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �S�Ă̕���̊��N���X </summary>
public abstract class WeaponBase : MonoBehaviour
{
    [Header("�U����"), SerializeField] protected float _offensivePower = 1f;

    /// <summary>
    /// ���̕���̎��s���@ : 
    /// true�̏ꍇ�A�������Ɏ��s����B
    /// false�̏ꍇ�A�����������Ǝ��s����B
    /// </summary>
    protected bool _isPressType;
    /// <summary> �����^�C�v��\���B : �������̂� </summary>
    protected const bool PRESS_TYPE_MOMENT = true;
    /// <summary> �����^�C�v��\���B : ������������ </summary>
    protected const bool PRESS_TYPE_CONSECUTIVELY = false;

    /// <summary>
    /// ���̕��킪���C���E�G�|�����ǂ����\���ϐ��B
    /// true �ł���΂��̕���̓��C���E�G�|���ł���B
    /// </summary>
    protected bool _isMainWeapon;
    /// <summary> �����^�C�v��\���B : �������̂� </summary>
    protected const bool MAIN_WEAPON = true;
    /// <summary> �����^�C�v��\���B : ������������ </summary>
    protected const bool SUB_WEAPON = false;

    /// <summary> �������������ǂ�����\���ϐ��B </summary>
    protected bool _isInitialized = false;

    /// <summary> �����������B : �I�[�o�[���C�h�� </summary>
    /// <param name="pressType">
    /// ���̕���̎��s���@ : 
    /// true�̏ꍇ�A�������Ɏ��s����B
    /// false�̏ꍇ�A�����������Ǝ��s����B
    /// </param>
    /// <param name="isMainWeapon">
    /// ���C���E�G�|�����ǂ���
    /// </param>
    /// <returns></returns>
    protected virtual bool InitWeapon(bool pressType, bool isMainWeapon)
    {
        _isPressType = pressType;
        _isMainWeapon = isMainWeapon;
        return true;
    }
    protected virtual bool InitWeapon(bool pressType, bool isMainWeapon, ShootingBase.ShootingType shootingType) { return true; }

    /// <summary> 
    /// ����ύX�����B
    /// ���̕�������s����ɂ���B
    /// : �I�[�o�[���C�h�� 
    /// </summary>
    protected virtual void ChangeWeapon()
    {
        // ���s���@�ƕ���^�C�v����Ƀf���Q�[�g�ϐ��ɏ�����������B
        // ���s�^�C�v��Fire�{�^���������̂� ���� �A
        if (_isPressType)
        {
            //���C���E�G�|���̏ꍇ�B
            if (_isMainWeapon)
            {
                PlayerAttack.On_Fire1ButtonDown = OnFire_ThisWeapon;
                PlayerAttack.On_Fire1Button = null;
            }
            //�T�u�E�G�|���̏ꍇ�B
            else
            {
                PlayerAttack.On_Fire2ButtonDown = OnFire_ThisWeapon;
                PlayerAttack.On_Fire2Button = null;
            }
        }
        // ���s�^�C�v��Fire�{�^�������������� ���� �A
        else
        {
            //���C���E�G�|���̏ꍇ�B
            if (_isMainWeapon)
            {
                PlayerAttack.On_Fire1ButtonDown = null;
                PlayerAttack.On_Fire1Button = OnFire_ThisWeapon;
            }
            //�T�u�E�G�|���̏ꍇ�B
            else
            {
                PlayerAttack.On_Fire2ButtonDown = null;
                PlayerAttack.On_Fire2Button = OnFire_ThisWeapon;
            }
        }
    }


    /// <summary> FireButton�������Ɏ��s���ׂ��֐��B : �I�[�o�[���C�h��Œ�`���Ă��������B </summary>
    protected virtual void OnFire_ThisWeapon() { }

    /// <summary> �U���͈͂�`�悷��֐��B : �I�[�o�[���C�h��Œ�`���ė��p���Ă��������B </summary>
    protected virtual void Debug_OnDraw_AttackArea() { }
}

public enum WeaponID
{
    WeaponID_00,

    END_WEAPON_ID
}