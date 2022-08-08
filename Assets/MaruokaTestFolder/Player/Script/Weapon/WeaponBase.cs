using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �S�Ă̕���̊��N���X </summary>
public class WeaponBase : MonoBehaviour
{
    public enum WeaponID
    {
        WeaponID_00,

        End_WeaponID
    }

    /// <summary>
    /// ���̕���̎��s���@ : 
    /// true�̏ꍇ�A�������Ɏ��s����B
    /// false�̏ꍇ�A�����������Ǝ��s����B
    /// </summary>
    protected bool _isPressType;

    protected bool _isMainWeapon;

    /// <summary> �����������B : �I�[�o�[���C�h�� </summary>
    protected virtual void Init(bool pressType, bool isMainWeapon)
    {
        _isPressType = pressType;
        _isMainWeapon = isMainWeapon;
    }

    /// <summary> ����ύX�����B : �I�[�o�[���C�h�� </summary>
    protected virtual void ChangeWeapon()
    {
        // ���s���@�ƕ���^�C�v����Ƀf���Q�[�g�ϐ��ɏ�����������B
        if (_isPressType)
        {
            if (_isMainWeapon)
            {
                PlayerAttack.On_Fire1ButtonDown = OnFire_ThisWeapon;
                PlayerAttack.On_Fire1Button = null;
            }
            else
            {
                PlayerAttack.On_Fire2ButtonDown = OnFire_ThisWeapon;
                PlayerAttack.On_Fire2Button = null;
            }
        }
        else
        {
            if (_isMainWeapon)
            {

                PlayerAttack.On_Fire1ButtonDown = null;
                PlayerAttack.On_Fire1Button = OnFire_ThisWeapon;
            }
            else
            {
                PlayerAttack.On_Fire2ButtonDown = null;
                PlayerAttack.On_Fire2Button = OnFire_ThisWeapon;
            }
        }
    }


    /// <summary> FireButton�������Ɏ��s���ׂ��֐��B : �I�[�o�[���C�h�� </summary>
    protected virtual void OnFire_ThisWeapon()
    {

    }
}
