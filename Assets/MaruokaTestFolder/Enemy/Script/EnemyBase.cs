using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EnemyBaseクラス。
/// 全エネミーに共通して必要そうな要素を記述してある。
/// 足りないものや不要なものがあれば報告してください。
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class EnemyBase : MonoBehaviour
{
    //<===== メンバー変数 =====>//
    [Header("このキャラのステータス"), SerializeField] protected EnemyStatus _status;
    public EnemyStatus Status { get => _status; set => _status = value; }
    protected bool _isMove;
    protected Rigidbody _rigidbody;

    //<===== protectedメンバー関数 =====>//
    /// <summary> 共通初期化処理 : オーバーライド不可 </summary>
    protected void CommonInitialized() { _rigidbody = GetComponent<Rigidbody>(); }
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
    /// <param name="damage"> ダメージ量 </param>
    public virtual void HitAttack(int damage)
    {
        //体力を減らす
        _status._hitPoint -= damage;
    }
    /// <summary> 攻撃のヒット関数。プレイヤーのOnCollision()やOnTrigger()から呼び出す。 : オーバーライド可 </summary>
    /// <param name="damage"> ダメージ量 </param>
    /// <param name="stiffeningTime"> 硬直時間 </param>
    public virtual void HitAttack(int damage, float stiffeningTime)
    {
        //体力を減らし、指定された時間硬直する。
        _status._hitPoint -= damage;
        StartCoroutine(WaitForStiffness(stiffeningTime));
    }
    /// <summary> 攻撃のヒット関数。プレイヤーのOnCollision()やOnTrigger()から呼び出す。 : オーバーライド可 </summary>
    /// <param name="damage"> ダメージ量 </param>
    /// <param name="knockbackDirection"> ノックバック方向 </param>
    /// <param name="knockbackPower"> ノックバックパワー </param>
    public virtual void HitAttack(int damage, Vector3 knockbackDirection, float knockbackPower)
    {
        //体力を減らし、ノックバックする。
        _status._hitPoint -= damage;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(knockbackDirection * knockbackPower, ForceMode.Impulse);
    }
    /// <summary> 攻撃のヒット関数。プレイヤーのOnCollision()やOnTrigger()から呼び出す。 : オーバーライド可 </summary>
    /// <param name="damage"> ダメージ量 </param>
    /// <param name="knockbackDirection"> ノックバック方向 </param>
    /// <param name="knockbackPower"> ノックバックパワー </param>
    /// <param name="stiffeningTime"> 硬直時間 </param>
    public virtual void HitAttack(int damage, Vector3 knockbackDirection, float knockbackPower, float stiffeningTime)
    {

        //体力を減らし、ノックバックし、指定された時間硬直する。
        _status._hitPoint -= damage;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(knockbackDirection * knockbackPower, ForceMode.Impulse);
        StartCoroutine(WaitForStiffness(stiffeningTime));
    }

    //<===== コルーチン =====>//
    /// <summary> 硬直時間を待つ。硬直時間中は動けないようにする。 </summary>
    /// <param name="stiffeningTime"> 硬直する時間 </param>
    IEnumerator WaitForStiffness(float stiffeningTime)
    {
        _isMove = false;
        yield return new WaitForSeconds(stiffeningTime);
        _isMove = true;
    }
}

/// <summary> Enemyのステータスを表す型 </summary>
[System.Serializable]
public struct EnemyStatus
{
    /// <summary> EnemyStatusのコンストラクタ </summary>
    /// <param name="hitPoint"> 体力 </param>
    /// <param name="offensivePower"> 攻撃力 </param>
    /// <param name="moveSpeed"> 移動速度 </param>
    public EnemyStatus(float hitPoint = 5f, float offensivePower = 5f, float moveSpeed = 10f)
    {
        _hitPoint = hitPoint;
        _offensivePower = offensivePower;
        _moveSpeed = moveSpeed;
    }

    /// <summary> 体力 </summary>
    public float _hitPoint;
    /// <summary> 攻撃力 </summary>
    public float _offensivePower;
    /// <summary> 移動速度 </summary>
    public float _moveSpeed;
}