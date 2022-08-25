using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EnemyBaseクラス。
/// 全エネミーに共通して必要そうな要素を記述してある。
/// 足りないものや不要なものがあれば報告してください。
/// </summary>
public class EnemyBase : MonoBehaviour
{
    //<===== メンバー変数 =====>//
    [Header("このキャラのステータス"), SerializeField] EnemyStatus _status;

    //<===== protectedメンバー関数 =====>//
    /// <summary> 共通初期化処理 : オーバーライド不可 </summary>
    protected void CommonInitialized() { }
    /// <summary> 共通更新処理 : オーバーライド不可 </summary>
    protected void CommonUpdate() { }
    /// <summary> 派生先独自の初期化処理 : オーバーライド可 </summary>
    protected virtual void OriginalInitialized() { }
    /// <summary> 派生先独自の更新処理 : オーバーライド可 </summary>
    protected virtual void OriginalUpdate() { }
    /// <summary> 移動処理 : オーバーライド可 </summary>
    protected virtual void Move() { }

    //<===== privateメンバー関数 =====>//


    //<===== publicメンバー関数 =====>//
    /// <summary> 攻撃のヒット関数。プレイヤーのOnCollision()やOnTrigger()から呼び出す。 : オーバーライド可 </summary>
    public virtual void HitAttack()
    {

    }
    /// <summary> 攻撃のヒット関数。プレイヤーのOnCollision()やOnTrigger()から呼び出す。 : オーバーライド可 </summary>
    /// <param name="damage"> ダメージ量 </param>
    public virtual void HitAttack(int damage)
    {

    }
    /// <summary> 攻撃のヒット関数。プレイヤーのOnCollision()やOnTrigger()から呼び出す。 : オーバーライド可 </summary>
    /// <param name="damage"> ダメージ量 </param>
    /// <param name="stiffeningTime"> 硬直時間 </param>
    public virtual void HitAttack(int damage, float stiffeningTime)
    {

    }
    /// <summary> 攻撃のヒット関数。プレイヤーのOnCollision()やOnTrigger()から呼び出す。 : オーバーライド可 </summary>
    /// <param name="damage"> ダメージ量 </param>
    /// <param name="knockbackDirection"> ノックバック方向 </param>
    /// <param name="knockbackPower"> ノックバック威力 </param>
    /// <param name="stiffeningTime"> 硬直時間 </param>
    public virtual void HitAttack(int damage, Vector3 knockbackDirection, float knockbackPower, float stiffeningTime)
    {

    }
}

/// <summary> Enemyのステータスを表す型 </summary>
[System.Serializable]
public struct EnemyStatus
{
    /// <summary> 体力 </summary>
    public float _hitPoint;
    /// <summary> 攻撃力 </summary>
    public float _offensivePower;
    /// <summary> 移動速度 </summary>
    public float _moveSpeed;
}