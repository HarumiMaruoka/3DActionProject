using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 全ての武器の基底クラス </summary>
public class WeaponBase : MonoBehaviour
{
    protected void InitializeWeapons()
    {

    }

    /// <summary> この武器の攻撃時関数を、PlayerAttackクラスのデリゲートに登録する。 </summary>
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
            Debug.LogError("不正な値です。");
        }
    }

    /// <summary> この武器の攻撃終了時関数を、PlayerAttackクラスのデリゲートから削除する </summary>
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
            Debug.LogError("不正な値です。");
        }
    }

    protected virtual void Activation_ThisWeapon()
    {

    }

    protected virtual void Finish_ThisWeapon()
    {

    }
}
