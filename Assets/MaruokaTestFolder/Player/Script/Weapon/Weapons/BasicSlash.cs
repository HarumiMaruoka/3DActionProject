using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 基本斬撃武器 : テスト段階 </summary>
public class BasicSlash : SlashingBase
{
    //<===== メンバー変数 =====>//
    [Header("アニメーションクリップ名"), SerializeField] string _animClip;

    //<===== Unityメッセージ =====>//
    void Start()
    {
        InitWeapon(PRESS_TYPE_MOMENT,MAIN_WEAPON);
        ChangeWeapon();
    }
    void Update()
    {
        
    }

    //<===== protectedメンバー関数 =====>//
    /// <summary> 攻撃処理 </summary>
    protected override void OnFire_ThisWeapon()
    {
        //アニメーションを再生する。
        _myComponent_Animator.Play(_animClip);
    }
    protected override bool InitWeapon(bool pressType, bool isMainWeapon)
    {
        _myComponent_Collider = transform.GetChild(0).GetComponent<Collider>();
        _myComponent_Animator = GetComponent<Animator>();
        return base.InitWeapon(pressType, isMainWeapon);
    }
}
