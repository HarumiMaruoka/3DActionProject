using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 実際のエネミー用コンポーネント。テスト段階。
/// このエネミーはプレイヤーに向かって移動するエネミー。
/// </summary>
public class TestEnemy02 : EnemyBase
{
    //<===== メンバー変数 =====>//
    Transform _playerPos;

    //<===== Unityメッセージ =====>//
    void Start()
    {
        CommonInitialized();
    }
    void Update()
    {
        OriginalUpdate();
    }

    //<===== protectedメンバー関数 =====>//
    /// <summary> このクラス独自の初期化処理 </summary>
    protected override void OriginalInitialized()
    {
        //プレイヤーのトランスフォームを取得する。
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    protected override void OriginalUpdate()
    {
        Move();
    }
    /// <summary> 移動処理 : プレイヤーに向かって進む </summary>
    protected override void Move()
    {
        if (_isMove)
        {
            float velocityY = _rigidbody.velocity.y;
            _rigidbody.velocity = (transform.position - _playerPos.position).normalized * _status._moveSpeed;
            _rigidbody.velocity += Vector3.up * velocityY;
        }
    }
}
