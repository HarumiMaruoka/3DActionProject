using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// プレイヤーのアニメーションを管理するクラス。
/// 基本行動アニメーションはこのクラスで管理するが、攻撃遷移はAttackで行う。
/// </summary>
public class PlayerAnimationManager : MonoBehaviour
{
    // <=========== メンバー変数･プロパティ ===========>//
    // ===== アニメーション関連 ===== //
    /// <summary> プレイヤーにアタッチされているアニメーターコンポーネント </summary>
    Animator _animator;
    /// <summary> プレイヤーのステートを管理するクラス </summary>
    PlayerStateManager _playerStateManager;
    /// <summary> プレイヤーの動きを検知するクラス。このクラスでは接地しているかどうかを判断する為に使用する。 </summary>
    PlayerMove _playerMove;
    /// <summary> Run中かどうか </summary>
    bool _isRun = false;
    /// <summary> Jumpしたかどうか </summary>
    bool _isJumpTrigger = false;

    //<========== Uniytメッセージ ==========>//
    void Start()
    {
        Initialized();
    }
    void Update()
    {
        Set_AnimParameterALL_False();
        Update_AnimParameter();
        Update_AnimParameterALL();
    }

    //<========== privateメンバー関数 ==========>//
    /// <summary> このコンポーネントの初期化関数 </summary>
    void Initialized()
    {
        // コンポーネントを取得
        if (!(_animator = GetComponent<Animator>())) Debug.LogError($"Animatorコンポーネントがアタッチされていません。 : {gameObject.name}");
        if (!(_playerStateManager = GetComponent<PlayerStateManager>())) Debug.LogError($"PlayerStateManagerコンポーネントがアタッチされていません。 : {gameObject.name}");
        if (!(_playerMove = GetComponent<PlayerMove>())) Debug.LogError($"PlayerMoverコンポーネントがアタッチされていません。 : {gameObject.name}");
    }
    /// <summary> アニメーション用変数を全てfalseに設定する。 </summary>
    void Set_AnimParameterALL_False()
    {
        _isRun = false;
        _isJumpTrigger = false;
    }
    /// <summary> プレイヤーステートを基に、アニメーションパラメータを更新する </summary>
    void Update_AnimParameter()
    {
        switch (_playerStateManager.PlayerState)
        {
            case PlayerStateManager.PlayerStateEnum.Run: _isRun = true; break;
            case PlayerStateManager.PlayerStateEnum.Jump: _isJumpTrigger = true; break;
        }
    }
    /// <summary> プレイヤーステートをアニメーションに反映する。 </summary>
    void Update_AnimParameterALL()
    {
        _animator.SetBool("IsRun", _isRun);
        _animator.SetBool("IsGround", _playerMove.Get_IsGround());
        _animator.SetBool("IsJump", _isJumpTrigger);
    }
}
