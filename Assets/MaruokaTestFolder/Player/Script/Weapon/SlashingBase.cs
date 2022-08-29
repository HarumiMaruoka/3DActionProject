using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 近距離武器の基底クラス : 
/// 近距離武器は、コライダーを使って判定を行う。
/// コライダーのオン・オフはアニメーションイベントから行う。
/// </summary>
public class SlashingBase : WeaponBase
{
    //<===== メンバー変数 =====>//
    protected Collider _myComponent_Collider;
    protected Animator _myComponent_Animator;

    //<===== 仮想関数 =====>//
    //衝突時の処理
    void OnCollisionEnter(Collision collision)
    {
        //エネミー接触時の処理
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyBase enemy))
        {
            HitEnemy(enemy);
        }
    }
    /// <summary> 初期化関数 </summary>
    /// <param name="pressType"> 攻撃実行タイプ </param>
    /// <param name="isMainWeapon"> メインウエポンかどうか </param>
    /// <returns> 初期化に成功したら true を返す。 </returns>
    protected override bool InitWeapon(bool pressType, bool isMainWeapon)
    {
        return base.InitWeapon(pressType, isMainWeapon);
    }
    /// <summary> 攻撃がエネミーにヒットしたときの処理 </summary>
    /// <param name="enemy"> 攻撃対象 </param>
    protected virtual void HitEnemy(EnemyBase enemy)
    {
        EnemyStatus status = enemy.Status;
        status._hitPoint -= _offensivePower;
        enemy.Status = status;
    }

    //<===== メンバー関数 =====>//
    /// <summary> 
    /// このゲームオブジェクトにアタッチされたコライダーをアクティブにする。
    /// AnimationEventから実行する想定。
    /// </summary>
    protected void ColliderEnableOn()
    {
        _myComponent_Collider.enabled = true;
    }
    /// <summary> 
    /// このゲームオブジェクトにアタッチされたコライダーを非アクティブにする。
    /// AnimationEventから実行する想定。
    /// </summary>
    protected void ColliderEnableOff()
    {
        _myComponent_Collider.enabled = false;
    }
}
