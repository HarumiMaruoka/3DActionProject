using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> プレイヤーの攻撃を管理するクラス </summary>
public class PlayerAttack : MonoBehaviour
{
    //info : このクラスでは、基本的にキーボード入力を受け取り、
    //       攻撃可能であれば、アニメーションを再生し、アニメーションイベントから実際の攻撃処理を行う。

    //<===== このクラスで使用する変数 =====>//
    /// <summary> 攻撃開始処理 </summary>
    public static event System.Action ActivationFire1;
    /// <summary> 攻撃終了処理 </summary>
    public static event System.Action FinishFire1;

    /// <summary> 攻撃開始処理 </summary>
    public static event System.Action ActivationFire2;
    /// <summary> 攻撃終了処理 </summary>
    public static event System.Action FinishFire2;

    /// <summary> 現在装備しているメインウェポンのID </summary>
    [Header("現在装備しているメインウェポンのID : 確認用"), SerializeField] int _mainWeaponID = 0;
    /// <summary> 現在装備しているサブウェポンのID </summary>
    [Header("現在装備しているサブウェポンのID : 確認用"), SerializeField] int _subWeaponID = 0;

    /// <summary> 左クリック攻撃が可能かどうか </summary>
    [Header("左クリック攻撃が可能かどうか : 確認用"), SerializeField] bool _isFireOne;
    /// <summary> 右クリック攻撃が可能かどうか </summary>
    [Header("右クリック攻撃が可能かどうか : 確認用"), SerializeField] bool _isFireTow;
    /// <summary> 自身にアタッチされているアニメーター </summary>
    Animator _animator;

    //<===== インスペクタから設定すべき値 =====>
    [Header("アニメーターのパラメータの名前 : メインウエポンの int Parameter Name"), SerializeField] string _animParameterName_int_MainWeaponID = "MainWeaponID";
    [Header("アニメーターのパラメータの名前 : サブウエポンの   int Parameter Name"), SerializeField] string _animParameterName_int_SubWeaponID = "SubWeaponID";
    [Header("アニメーターのパラメータの名前 : メインウエポンの bool Parameter Name"), SerializeField] string _animParameterName_bool_MainWeaponName = "Fire1";
    [Header("アニメーターのパラメータの名前 : サブウエポンの   bool Parameter Name"), SerializeField] string _animParameterName_bool_SubWeaponName = "Fire2";

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        AttackFireOne();
        AttackFireTow();
    }

    /// <summary> 左クリック時の挙動 </summary>
    void AttackFireOne()
    {
        //入力があり 、かつ、 攻撃可能であれば攻撃する
        if (Input.GetButtonDown("Fire1") && _isFireOne)
        {
            Debug.Log("実行！");
            //アニメーションに現在装備している武器のIDを渡す。
            _animator.SetInteger(_animParameterName_int_MainWeaponID, _mainWeaponID);
            //アニメーションを再生
            _animator.SetBool(_animParameterName_bool_MainWeaponName, _isFireOne);
        }
        else if (_isFireOne && Input.GetButtonUp("Fire1"))
        {
            Debug.Log("aaa");
            _animator.SetBool(_animParameterName_bool_MainWeaponName, !_isFireOne);
        }
    }

    /// <summary> 右クリック時の挙動 </summary>
    void AttackFireTow()
    {
        //攻撃処理
        if (Input.GetButtonDown("Fire2") && _isFireTow)
        {
            //アニメーションに現在装備している武器のIDを渡す。
            _animator.SetInteger(_animParameterName_int_SubWeaponID, _subWeaponID);
            //アニメーションを再生
            _animator.SetBool(_animParameterName_bool_SubWeaponName, _isFireTow);
        }
        //後始末
        else if (_isFireTow && Input.GetButtonUp("Fire2"))
        {
            _animator.SetBool(_animParameterName_bool_SubWeaponName, !_isFireTow);
        }
    }

    /// <summary> 現在装備しているメインウェポンのIDを設定する。 </summary>
    /// <param name="id"> 設定するID </param>
    public void Set_MainWeaponID(int id)
    {
        _mainWeaponID = id;
    }

    /// <summary> 現在装備しているサブウェポンのID </summary>
    /// <param name="id"> 設定するID </param>
    public void Set_SubWeaponID(int id)
    {
        _subWeaponID = id;
    }

    //<===== 以下の関数は全て、アニメーションイベントから呼び出す関数。 =====>//
    /// <summary> 攻撃開始時の処理 </summary>
    void OnAttack(int attackType)
    {
        //攻撃不可にする
        if (attackType == 1)
        {
            _isFireOne = false;
        }
        else if (attackType == 2)
        {
            _isFireTow = false;
        }
    }

    /// <summary> 攻撃可能にする。 </summary>
    void OffAttack(int attackType)
    {
        //攻撃可能にする
        if (attackType == 1)
        {
            _isFireOne = true;
        }
        else if (attackType == 2)
        {
            _isFireTow = true;
        }
    }

    /// <summary> 攻撃発動 </summary>
    void ActivationAttack_Fire1()
    {
        //デリゲートに登録された
        //攻撃開始関数を呼び出す。
        ActivationFire1();
    }

    /// <summary> 攻撃終了 </summary>
    void FinishAttack_Fire1()
    {
        //デリゲートに登録された
        //攻撃終了関数を呼び出す。
        FinishFire1();
    }

    /// <summary> 攻撃発動 </summary>
    void ActivationAttack_Fire2()
    {
        //デリゲートに登録された
        //攻撃開始関数を呼び出す。
        ActivationFire2();
    }

    /// <summary> 攻撃終了 </summary>
    void FinishAttack_Fire2()
    {
        //デリゲートに登録された
        //攻撃終了関数を呼び出す。
        FinishFire2();
    }
}