using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 全ての武器の基底クラス </summary>
public class WeaponBase : MonoBehaviour
{
    public enum WeaponID
    {
        WeaponID_00,

        End_WeaponID
    }

    /// <summary>
    /// この武器の実行方法 : 
    /// trueの場合、押下時に実行する。
    /// falseの場合、押下中ずっと実行する。
    /// </summary>
    protected bool _isPressType;

    protected bool _isMainWeapon;

    /// <summary> 初期化処理。 : オーバーライド可 </summary>
    protected virtual void Init(bool pressType, bool isMainWeapon)
    {
        _isPressType = pressType;
        _isMainWeapon = isMainWeapon;
    }

    /// <summary> 武器変更処理。 : オーバーライド可 </summary>
    protected virtual void ChangeWeapon()
    {
        // 実行方法と武器タイプを基にデリゲート変数に処理を代入する。
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


    /// <summary> FireButton押下時に実行すべき関数。 : オーバーライド可 </summary>
    protected virtual void OnFire_ThisWeapon()
    {

    }
}
