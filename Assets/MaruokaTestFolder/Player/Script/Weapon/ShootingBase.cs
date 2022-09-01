using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 遠距離武器の基底クラス : 
/// 遠距離武器は、オーバーラップを使って当たり判定を行う。
/// コルーチン等を利用して、スクリプトから制御を行う。
/// </summary>
public class ShootingBase : WeaponBase
{
    /// <summary> 射撃方法を表す型 </summary>
    [System.Serializable]
    public enum ShootingType
    {
        /// <summary> 直線 </summary>
        Straight,
        /// <summary> 範囲 </summary>
        Range,
    }

    /// <summary> この武器の射撃タイプ </summary>
    protected ShootingType _shootingType;

    protected override bool InitWeapon(bool pressType, bool isMainWeapon, ShootingType shootingType)
    {
        base.InitWeapon(pressType, isMainWeapon);
        _shootingType = shootingType;
        return true;
    }
}
