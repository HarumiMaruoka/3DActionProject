using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 攻撃処理を担当するコンポーネント </summary>
/// いろいろ作成したがこれで行こうと思う。
public class PlayerAttack : MonoBehaviour
{
    //<***************** メンバー変数 *****************>//

    [Header("確認用 : 現在装備しているメイン装備のID"), SerializeField] int _currentlyEquippedMainWeaponID;
    [Header("確認用 : 現在装備しているサブ装備のID"), SerializeField] int _currentlyEquippedSubWeaponID;
    [Header("確認用 : メインウエポンで攻撃するかを表す真偽値"), SerializeField] bool _isAttackMainWeaponID;
    [Header("確認用 : サブウエポンで攻撃するかを表す真偽値"), SerializeField] bool _isAttackSubWeaponID;

    [Header("InputManager < ButtonName > : Fire1ボタンの名前"), SerializeField] string _fire1ButtonName= "Fire1";
    [Header("InputManager < ButtonName > : Fire2ボタンの名前"), SerializeField] string _fire2ButtonName= "Fire2";

    [Header("Animator Parameters < ParameterName > : 現在装着しているメインウエポンのID int Parameter Name"), SerializeField] string _animParameterName_int_MainWeaponID = "MainWeaponID";
    [Header("Animator Parameters < ParameterName > : 現在装着しているサブウエポンのID   int Parameter Name"), SerializeField] string _animParameterName_int_SubWeaponID = "SubWeaponID";
    [Header("Animator Parameters < ParameterName > : 攻撃するかどうかを表すメインウエポンの真偽値 bool Parameter Name"), SerializeField] string _animParameterName_bool_MainWeaponName = "IsFire1";
    [Header("Animator Parameters < ParameterName > : 攻撃するかどうかを表すサブウエポンのの真偽値 bool Parameter Name"), SerializeField] string _animParameterName_bool_SubWeaponName = "IsFire2";

    /// <summary> Fire1押下時に実行するデリゲート変数。 </summary>
    public static System.Action On_Fire1ButtonDown;
    /// <summary> Fire2押下時に実行するデリゲート変数。 </summary>
    public static System.Action On_Fire2ButtonDown;

    /// <summary> Fire1押下中ずっと実行するデリゲート変数。 </summary>
    public static System.Action On_Fire1Button;
    /// <summary> Fire2押下中ずっと実行するデリゲート変数。 </summary>
    public static System.Action On_Fire2Button;

    /// <summary> 自身にアタッチされているAnimatorComponent </summary>
    Animator _animator;

    /// <summary> Fire1押下を検知する変数 : 押下時のみtrue </summary>
    bool _inputFire1ButtonDown;
    /// <summary> Fire2押下を検知する変数 : 押下時のみtrue </summary>
    bool _inputFire2ButtonDown;
    /// <summary> Fire1押下を検知する変数 : 押下中ずっとtrue </summary>
    bool _inputFire1Button;
    /// <summary> Fire2押下を検知する変数 : 押下中ずっとtrue </summary>
    bool _inputFire2Button;

    //<***************** メンバー関数 *****************>//

    //<***************** Unityメッセージ *****************>//
    void Start()
    {
        Init();
    }
    void Update()
    {
        Input_FireButton();
        Update_Attack();
        Update_AttackAnim();
    }

    //<***************** publicメソッド *****************>//

    /// <summary> 着用しているメイン装備のIDを設定する。 </summary>
    /// <param name="value"> 新しいID </param>
    public void Set_CurrentlyEquippedMainWeaponID(int value)
    {
        _currentlyEquippedMainWeaponID = value;
    }
    /// <summary> 着用しているサブ装備のIDを設定する。 </summary>
    /// <param name="value"> 新しいID </param>
    public void Set_CurrentlyEquippedSubWeaponID(int value)
    {
        _currentlyEquippedSubWeaponID = value;
    }

    //<***************** privateメソッド *****************>//

    /// <summary> 初期化処理 </summary>
    void Init()
    {
        //コンポーネントを取得
        _animator = GetComponent<Animator>();
    }
    /// <summary> 入力処理 </summary>
    void Input_FireButton()
    {
        _inputFire1ButtonDown = Input.GetButtonDown(_fire1ButtonName);
        _inputFire2ButtonDown = Input.GetButtonDown(_fire2ButtonName);
        _inputFire1Button = Input.GetButton(_fire1ButtonName);
        _inputFire2Button = Input.GetButton(_fire2ButtonName);
    }

    /// <summary> 攻撃の更新処理 </summary>
    void Update_Attack()
    {
        if (_inputFire1ButtonDown)//Fire1押下時のみ実行
        {
            if(On_Fire1ButtonDown!=null) On_Fire1ButtonDown();
        }
        if (_inputFire2ButtonDown)//Fire2押下時のみ実行
        {
            if (On_Fire2ButtonDown != null) On_Fire2ButtonDown();
        }

        if (_inputFire1Button)//Fire1押下中ずっと実行
        {
            if (On_Fire1Button != null) On_Fire1Button();
        }
        if (_inputFire2Button)//Fire2押下中ずっと実行
        {
            if (On_Fire2Button != null) On_Fire2Button();
        }
    }
    /// <summary> アニメーションパラメータに値をセットする。 </summary>
    void Update_AttackAnim()
    {
        //装備IDを設定する。
        _animator.SetInteger(_animParameterName_int_MainWeaponID, _currentlyEquippedMainWeaponID);
        _animator.SetInteger(_animParameterName_int_SubWeaponID, _currentlyEquippedSubWeaponID);
        //攻撃アニメーションに遷移するかどうかの値を設定する。
        _animator.SetBool(_animParameterName_bool_MainWeaponName, _inputFire1ButtonDown);
        _animator.SetBool(_animParameterName_bool_SubWeaponName, _inputFire2ButtonDown);
    }
}
