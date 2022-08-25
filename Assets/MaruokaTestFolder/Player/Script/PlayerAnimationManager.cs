using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// �v���C���[�̃A�j���[�V�������Ǘ�����N���X�B
/// ��{�s���A�j���[�V�����͂��̃N���X�ŊǗ����邪�A�U���J�ڂ�Attack�ōs���B
/// </summary>
public class PlayerAnimationManager : MonoBehaviour
{
    // <=========== �����o�[�ϐ���v���p�e�B ===========>//
    // ===== �A�j���[�V�����֘A ===== //
    /// <summary> �v���C���[�ɃA�^�b�`����Ă���A�j���[�^�[�R���|�[�l���g </summary>
    Animator _animator;
    /// <summary> �v���C���[�̃X�e�[�g���Ǘ�����N���X </summary>
    PlayerStateManager _playerStateManager;
    /// <summary> �v���C���[�̓��������m����N���X�B���̃N���X�ł͐ڒn���Ă��邩�ǂ����𔻒f����ׂɎg�p����B </summary>
    PlayerMove _playerMove;
    /// <summary> Run�����ǂ��� </summary>
    bool _isRun = false;
    /// <summary> Jump�������ǂ��� </summary>
    bool _isJumpTrigger = false;

    //<========== Uniyt���b�Z�[�W ==========>//
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

    //<========== private�����o�[�֐� ==========>//
    /// <summary> ���̃R���|�[�l���g�̏������֐� </summary>
    void Initialized()
    {
        // �R���|�[�l���g���擾
        if (!(_animator = GetComponent<Animator>())) Debug.LogError($"Animator�R���|�[�l���g���A�^�b�`����Ă��܂���B : {gameObject.name}");
        if (!(_playerStateManager = GetComponent<PlayerStateManager>())) Debug.LogError($"PlayerStateManager�R���|�[�l���g���A�^�b�`����Ă��܂���B : {gameObject.name}");
        if (!(_playerMove = GetComponent<PlayerMove>())) Debug.LogError($"PlayerMover�R���|�[�l���g���A�^�b�`����Ă��܂���B : {gameObject.name}");
    }
    /// <summary> �A�j���[�V�����p�ϐ���S��false�ɐݒ肷��B </summary>
    void Set_AnimParameterALL_False()
    {
        _isRun = false;
        _isJumpTrigger = false;
    }
    /// <summary> �v���C���[�X�e�[�g����ɁA�A�j���[�V�����p�����[�^���X�V���� </summary>
    void Update_AnimParameter()
    {
        switch (_playerStateManager.PlayerState)
        {
            case PlayerStateManager.PlayerStateEnum.Run: _isRun = true; break;
            case PlayerStateManager.PlayerStateEnum.Jump: _isJumpTrigger = true; break;
        }
    }
    /// <summary> �v���C���[�X�e�[�g���A�j���[�V�����ɔ��f����B </summary>
    void Update_AnimParameterALL()
    {
        _animator.SetBool("IsRun", _isRun);
        _animator.SetBool("IsGround", _playerMove.Get_IsGround());
        _animator.SetBool("IsJump", _isJumpTrigger);
    }
}
