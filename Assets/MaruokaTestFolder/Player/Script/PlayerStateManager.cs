using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// プレイヤーのステートを管理するクラス。
/// </summary>
public class PlayerStateManager : MonoBehaviour
{
    // <============ このクラスで使用する型 ============> //
    /// <summary> プレイヤーのステートを表す型 </summary>
    public enum PlayerStateEnum
    {
        Idle,
        Run,
        Jump,
        Fall,
        Fire1,
        Fire2,

        PlayerStateEnum_End
    }

    // <============ メンバー変数 ･ プロパティ ============> //
    [Header("確認用 : 現在のプレイヤーのステート"), SerializeField] PlayerStateEnum _playerState;
    /// <summary>プレイヤーのステート </summary>
    public PlayerStateEnum PlayerState { get => _playerState;}
    PlayerMove _playerMoveComponent;
    Rigidbody _rigidbody;

    bool _isInitialized;

    //<============ Unityメッセージ ============>//
    void Start()
    {
        _isInitialized = Initialized();
    }
    void Update()
    {
        //初期化に成功したら通常処理を行う。初期化に失敗していたらエラーメッセージを表示する。
        if (_isInitialized) Update_State();
        else Debug.LogError($"初期化に失敗しました。\nゲームオブジェクト名 : {gameObject.name}");
    }

    //<=============== privateメンバー関数 ===============>//
    /// <summary> このコンポーネントの初期化関数 </summary>
    /// <returns> 初期化に成功したら true を返す。 </returns>
    bool Initialized()
    {
        //変数を初期化
        _playerState = PlayerStateEnum.Idle;
        //コンポーネントを取得
        if (!(_playerMoveComponent = GetComponent<PlayerMove>())) { Debug.LogError($"PlayerMoveコンポーネントがアタッチされていません。 : {gameObject.name}"); return false; }
        if (!(_rigidbody = GetComponent<Rigidbody>())) { Debug.LogError($"Rigidbodyコンポーネントがアタッチされていません。 : {gameObject.name}"); return false; }

        return true;
    }
    /// <summary> ステートを更新 </summary>
    void Update_State()
    {
        //初期化 : 何も入力がなければidle状態
        _playerState = PlayerStateEnum.Idle;

        //走り状態
        if (Mathf.Abs(_rigidbody.velocity.x) > 0.5f || Mathf.Abs(_rigidbody.velocity.z) > 0.5f)
        {
            _playerState = PlayerStateEnum.Run;
        }
        //ジャンプ状態
        if (_playerMoveComponent.Get_IsGround() && Input.GetButtonDown("Jump"))
        {
            _playerState = PlayerStateEnum.Jump;
        }
        //非接地状態 : 落下や上昇中の場合
        else if (!_playerMoveComponent.Get_IsGround())
        {
            _playerState = PlayerStateEnum.Fall;
        }
    }
}
