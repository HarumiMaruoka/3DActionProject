using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old_AttackPattern2 : MonoBehaviour
{
    /// <summary> 射撃のインターバル </summary>
    float _fireOneInterval = -1;
    /// <summary> 斬撃のインターバル </summary>
    float _fireTowInterval = -1;

    /// <summary> 左クリック攻撃が可能かどうか </summary>
    bool _isFireOne = true;
    /// <summary> 右クリック攻撃が可能かどうか </summary>
    bool _isFireTow = true;

    void Start()
    {

    }

    void Update()
    {
        AttackFireOne();
        AttackFireTow();
    }


    /// <summary> 左クリック時の挙動 </summary>
    void AttackFireOne()
    {
        if (Input.GetButtonDown("Fire1") && _isFireOne)
        {
            //インターバル開始
            StartCoroutine(FireOneInterval_WaitCoroutine());
            //ここに攻撃時の処理を書く。

        }
    }

    /// <summary> 右クリック時の挙動 </summary>
    void AttackFireTow()
    {
        if (Input.GetButtonDown("Fire2") && _isFireTow)
        {
            //インターバル開始
            StartCoroutine(FireTowInterval_WaitCoroutine());
            //ここに攻撃時の処理を書く。

        }
    }

    /// <summary> FireOne攻撃のインターバルを設定する。 </summary>
    public void SetFireOneInterval(float interval)
    {
        _fireOneInterval = interval;
    }

    /// <summary> FireTow攻撃のインターバルを設定する。 </summary>
    public void SetFireTowInterval(float interval)
    {
        _fireTowInterval = interval;
    }

    /// <summary> Fire1攻撃のインターバルを待つ。 </summary>
    IEnumerator FireOneInterval_WaitCoroutine()
    {
        _isFireOne = false;

        yield return new WaitForSeconds(_fireOneInterval);

        _isFireOne = true;
    }

    /// <summary> Fire2攻撃のインターバルを待つ。 </summary>
    IEnumerator FireTowInterval_WaitCoroutine()
    {
        _isFireTow = false;

        yield return new WaitForSeconds(_fireTowInterval);

        _isFireTow = true;
    }
}
