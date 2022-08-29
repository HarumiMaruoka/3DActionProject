using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 全ての武器の基底クラス </summary>
public abstract class WeaponBase : MonoBehaviour
{
    [Header("攻撃力"), SerializeField] protected float _offensivePower = 1f;

    /// <summary>
    /// この武器の実行方法 : 
    /// trueの場合、押下時に実行する。
    /// falseの場合、押下中ずっと実行する。
    /// </summary>
    protected bool _isPressType;
    /// <summary> 押下タイプを表す。 : 押下時のみ </summary>
    protected const bool PRESS_TYPE_MOMENT = true;
    /// <summary> 押下タイプを表す。 : 押下中ずっと </summary>
    protected const bool PRESS_TYPE_CONSECUTIVELY = false;

    /// <summary>
    /// この武器がメインウエポンかどうか表す変数。
    /// true であればこの武器はメインウエポンである。
    /// </summary>
    protected bool _isMainWeapon;
    /// <summary> 押下タイプを表す。 : 押下時のみ </summary>
    protected const bool MAIN_WEAPON = true;
    /// <summary> 押下タイプを表す。 : 押下中ずっと </summary>
    protected const bool SUB_WEAPON = false;

    /// <summary> 初期化したかどうかを表す変数。 </summary>
    protected bool _isInitialized = false;

    /// <summary> 初期化処理。 : オーバーライド可 </summary>
    /// <param name="pressType">
    /// この武器の実行方法 : 
    /// trueの場合、押下時に実行する。
    /// falseの場合、押下中ずっと実行する。
    /// </param>
    /// <param name="isMainWeapon">
    /// メインウエポンかどうか
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
    /// 武器変更処理。
    /// この武器を実行武器にする。
    /// : オーバーライド可 
    /// </summary>
    protected virtual void ChangeWeapon()
    {
        // 実行方法と武器タイプを基にデリゲート変数に処理を代入する。
        // 実行タイプがFireボタン押下時のみ かつ 、
        if (_isPressType)
        {
            //メインウエポンの場合。
            if (_isMainWeapon)
            {
                PlayerAttack.On_Fire1ButtonDown = OnFire_ThisWeapon;
                PlayerAttack.On_Fire1Button = null;
            }
            //サブウエポンの場合。
            else
            {
                PlayerAttack.On_Fire2ButtonDown = OnFire_ThisWeapon;
                PlayerAttack.On_Fire2Button = null;
            }
        }
        // 実行タイプがFireボタン押下中ずっと かつ 、
        else
        {
            //メインウエポンの場合。
            if (_isMainWeapon)
            {
                PlayerAttack.On_Fire1ButtonDown = null;
                PlayerAttack.On_Fire1Button = OnFire_ThisWeapon;
            }
            //サブウエポンの場合。
            else
            {
                PlayerAttack.On_Fire2ButtonDown = null;
                PlayerAttack.On_Fire2Button = OnFire_ThisWeapon;
            }
        }
    }


    /// <summary> FireButton押下時に実行すべき関数。 : オーバーライド先で定義してください。 </summary>
    protected virtual void OnFire_ThisWeapon() { }

    /// <summary> 攻撃範囲を描画する関数。 : オーバーライド先で定義して利用してください。 </summary>
    protected virtual void Debug_OnDraw_AttackArea() { }
}

public enum WeaponID
{
    WeaponID_00,

    END_WEAPON_ID
}