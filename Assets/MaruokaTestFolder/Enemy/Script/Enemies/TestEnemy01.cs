using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 実際のエネミー用コンポーネント。テスト段階。
/// このエネミーは動かない置物エネミー
/// </summary>
public class TestEnemy01 : EnemyBase
{
    //<===== Unityメッセージ =====>//
    void Update()
    {
        if (_status._hitPoint < 0f)
        {
            Debug.Log($"体力がなくなったのでやられました。{gameObject.name}");
            Destroy(gameObject);
        }
    }
}
