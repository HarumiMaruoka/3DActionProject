using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> プレイヤーのステートを管理するクラス </summary>
public class PlayerStateManager : MonoBehaviour
{
    // <===== このクラスで使用する型 =====> //
    /// <summary> プレイヤーのステートを表す型 </summary>
    public enum PlayerStateEnum
    {
        Idle,
        Run,
        Jump,
        Fire1,
        Fire2,

        PlayerStateEnum_End
    }

    // <===== このクラスで使用する変数 =====> //
    [Header("現在のプレイヤーのステート"), SerializeField] PlayerStateEnum _playerState;
    /// <summary> プレイヤーのステート </summary>
    public PlayerStateEnum PlayerState { get => _playerState; private set => _playerState = value; }
    PlayerMove _playerMoveComponent;
    Rigidbody _rigidbody;

    void Start()
    {
        PlayerState = PlayerStateEnum.Idle;

        _playerMoveComponent = GetComponent<PlayerMove>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Update_State();
    }

    /// <summary> ステートを更新 </summary>
    void Update_State()
    {
        //初期化 : 何も入力がなければidle状態
        PlayerState = PlayerStateEnum.Idle;

        //走り
        if (Mathf.Abs(_rigidbody.velocity.x) > 0.5f || Mathf.Abs(_rigidbody.velocity.z) > 0.5f)
        {
            PlayerState = PlayerStateEnum.Run;
        }

        //ジャンプ
        if (_playerMoveComponent.Get_IsGround() && Input.GetButtonDown("Jump"))
        {
            PlayerState = PlayerStateEnum.Jump;
        }
    }
}
