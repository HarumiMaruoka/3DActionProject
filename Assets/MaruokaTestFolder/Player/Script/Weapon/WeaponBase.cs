using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �S�Ă̕���̊��N���X </summary>
public class WeaponBase : MonoBehaviour
{
    protected void InitializeWeapons()
    {

    }

    /// <summary> ���̕���̍U�����֐����APlayerAttack�N���X�̃f���Q�[�g�ɓo�^����B </summary>
    protected virtual void SignUp_OnAttackDelegate_ThisWeapon(int fireOneOrTow)
    {
        if (fireOneOrTow == 1)
        {
            PlayerAttack.ActivationFire1 += Activation_ThisWeapon;
            PlayerAttack.FinishFire1 += Finish_ThisWeapon;
        }
        else if (fireOneOrTow == 2)
        {
            PlayerAttack.ActivationFire2 += Activation_ThisWeapon;
            PlayerAttack.FinishFire2 += Finish_ThisWeapon;
        }
        else
        {
            Debug.LogError("�s���Ȓl�ł��B");
        }
    }

    /// <summary> ���̕���̍U���I�����֐����APlayerAttack�N���X�̃f���Q�[�g����폜���� </summary>
    protected virtual void Delegate_OnAttackDelegate_ThisWeapon(int fireOneOrTow)
    {
        if (fireOneOrTow == 1)
        {
            PlayerAttack.ActivationFire1 += Activation_ThisWeapon;
            PlayerAttack.FinishFire1 += Finish_ThisWeapon;
        }
        else if (fireOneOrTow == 2)
        {
            PlayerAttack.ActivationFire2 += Activation_ThisWeapon;
            PlayerAttack.FinishFire2 += Finish_ThisWeapon;
        }
        else
        {
            Debug.LogError("�s���Ȓl�ł��B");
        }
    }

    protected virtual void Activation_ThisWeapon()
    {

    }

    protected virtual void Finish_ThisWeapon()
    {

    }
}
