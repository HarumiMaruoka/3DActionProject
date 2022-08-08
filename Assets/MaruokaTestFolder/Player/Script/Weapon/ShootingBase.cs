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
    protected override void Init(bool pressType, bool isMainWeapon)
    {
        base.Init(pressType, isMainWeapon);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
