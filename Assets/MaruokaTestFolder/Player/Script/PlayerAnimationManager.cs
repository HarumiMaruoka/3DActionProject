using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �v���C���[�̃A�j���[�V�������Ǘ�����N���X </summary>
public class PlayerAnimationManager : MonoBehaviour
{
    // <===== ���̃N���X�Ŏg�p����ϐ� =====>//
    // ===== �A�j���[�V�����֘A ===== //
    /// <summary> �v���C���[�ɕt�^����Ă���A�j���[�^�[�R���|�[�l���g </summary>
    Animator _animator;
    /// <summary> �v���C���[�̃X�e�[�g���Ǘ�����N���X </summary>
    PlayerStateManager _playerStateManager;
    /// <summary> �v���C���[�̓��������m����N���X�B���̃N���X�ł͐ڒn���Ă��邩�ǂ����𔻒f����ׂɎg�p����B </summary>
    PlayerMove _playerMove;
    /// <summary> �ڒn���Ă��邩�ǂ��� </summary>
    bool _isGround = true;
    /// <summary> Run�����ǂ��� </summary>
    bool _isRun = false;
    /// <summary> Jump�������ǂ��� </summary>
    bool _isJumpTrigger = false;
    /// <summary> Fire1�U���������ǂ��� </summary>
    bool _isFire1Trigger = false;
    /// <summary> Fire2�U���������ǂ��� </summary>
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

    /// <summary> �A�j���[�V�����p�ϐ���S��false�ŃZ�b�g����B </summary>
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

    /// <summary> �v���C���[�X�e�[�g���A�j���[�V�����ɔ��f����B </summary>
    void Update_AnimParameters()
    {
        _animator.SetBool("IsRun", _isRun);
        _animator.SetBool("IsGround", _playerMove.Get_IsGround());

        _animator.SetBool("IsJump", _isJumpTrigger);
        //_animator.SetBool("IsFire1", _isFire1Trigger);
        //_animator.SetBool("IsFire2", _isFire2Trigger);
    }
}
