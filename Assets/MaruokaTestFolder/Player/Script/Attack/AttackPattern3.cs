using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 攻撃処理を担当するコンポーネント </summary>
public class AttackPattern3 : MonoBehaviour
{
    /// <summary> Fire1押下時に実行するデリゲート変数。 </summary>
    public static System.Action _fire1ButtonDown;
    /// <summary> Fire2押下時に実行するデリゲート変数。 </summary>
    public static System.Action _fire2ButtonDown;

    /// <summary> Fire1押下中ずっと実行するデリゲート変数。 </summary>
    public static System.Action _fire1Button;
    /// <summary> Fire2押下中ずっと実行するデリゲート変数。 </summary>
    public static System.Action _fire2Button;

    [Header("Fire1ボタンの名前"), SerializeField] string _fire1ButtonName;
    [Header("Fire2ボタンの名前"), SerializeField] string _fire2ButtonName;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown(_fire1ButtonName))
        {
            _fire1ButtonDown();
        }
        if (Input.GetButtonDown(_fire2ButtonName))
        {
            _fire2ButtonDown();
        }
        if (Input.GetButton(_fire1ButtonName))
        {
            _fire1Button();
        }
        if (Input.GetButton(_fire2ButtonName))
        {
            _fire2Button();
        }
    }
}
