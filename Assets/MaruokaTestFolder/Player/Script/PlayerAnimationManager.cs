using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> プレイヤーのアニメーションを管理するクラス </summary>
public class PlayerAnimationManager : MonoBehaviour
{
    // <===== このクラスで使用する変数 =====>//
    // ===== アニメーション関連 ===== //
    /// <summary> プレイヤーに付与されているアニメーターコンポーネント </summary>
    Animator _animator;
    /// <summary> プレイヤーのステートを管理するクラス </summary>
    PlayerStateManager _playerStateManager;
    /// <summary> プレイヤーの動きを検知するクラス。このクラスでは接地しているかどうかを判断する為に使用する。 </summary>
    PlayerMove _playerMove;
    /// <summary> 接地しているかどうか </summary>
    bool _isGround = true;
    /// <summary> Run中かどうか </summary>
    bool _isRun = false;
    /// <summary> Jumpしたかどうか </summary>
    bool _isJumpTrigger = false;
    /// <summary> Fire1攻撃したかどうか </summary>
    bool _isFire1Trigger = false;
    /// <summary> Fire2攻撃したかどうか </summary>
    bool _isFire2Trigger = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerStateManager = GetComponent<PlayerStateManager>();
        _playerMove = GetComponent<PlayerMove>();
    }

    void Update()
    {
        Set_AnimValueALL_False();
        Update_AnimValue();
        Update_AnimParameters();
    }

    /// <summary> アニメーション用変数を全てfalseでセットする。 </summary>
    void Set_AnimValueALL_False()
    {
        _isRun = false;
        _isJumpTrigger = false;
        //_isFire1Trigger = false;
        //_isFire2Trigger = false;
        _isGround = false;
    }

    void Update_AnimValue()
    {

        switch (_playerStateManager.PlayerState)
        {
            case PlayerStateManager.PlayerStateEnum.Run: _isRun = true; break;
            case PlayerStateManager.PlayerStateEnum.Jump: _isJumpTrigger = true; break;
            //case PlayerStateManager.PlayerStateEnum.Fire1: _isFire1Trigger = true; break;
            //case PlayerStateManager.PlayerStateEnum.Fire2: _isFire2Trigger = true; break;
        }
    }

    /// <summary> プレイヤーステートをアニメーションに反映する。 </summary>
    void Update_AnimParameters()
    {
        _animator.SetBool("IsRun", _isRun);
        _animator.SetBool("IsGround", _playerMove.Get_IsGround());

        _animator.SetBool("IsJump", _isJumpTrigger);
        //_animator.SetBool("IsFire1", _isFire1Trigger);
        //_animator.SetBool("IsFire2", _isFire2Trigger);
    }
}
