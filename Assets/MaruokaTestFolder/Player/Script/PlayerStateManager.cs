using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// �v���C���[�̃X�e�[�g���Ǘ�����N���X�B
/// </summary>
public class PlayerStateManager : MonoBehaviour
{
    // <============ ���̃N���X�Ŏg�p����^ ============> //
    /// <summary> �v���C���[�̃X�e�[�g��\���^ </summary>
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

    // <============ �����o�[�ϐ� � �v���p�e�B ============> //
    [Header("�m�F�p : ���݂̃v���C���[�̃X�e�[�g"), SerializeField] PlayerStateEnum _playerState;
    /// <summary>�v���C���[�̃X�e�[�g </summary>
    public PlayerStateEnum PlayerState { get => _playerState;}
    PlayerMove _playerMoveComponent;
    Rigidbody _rigidbody;

    bool _isInitialized;

    //<============ Unity���b�Z�[�W ============>//
    void Start()
    {
        _isInitialized = Initialized();
    }
    void Update()
    {
        //�������ɐ���������ʏ폈�����s���B�������Ɏ��s���Ă�����G���[���b�Z�[�W��\������B
        if (_isInitialized) Update_State();
        else Debug.LogError($"�������Ɏ��s���܂����B\n�Q�[���I�u�W�F�N�g�� : {gameObject.name}");
    }

    //<=============== private�����o�[�֐� ===============>//
    /// <summary> ���̃R���|�[�l���g�̏������֐� </summary>
    /// <returns> �������ɐ��������� true ��Ԃ��B </returns>
    bool Initialized()
    {
        //�ϐ���������
        _playerState = PlayerStateEnum.Idle;
        //�R���|�[�l���g���擾
        if (!(_playerMoveComponent = GetComponent<PlayerMove>())) { Debug.LogError($"PlayerMove�R���|�[�l���g���A�^�b�`����Ă��܂���B : {gameObject.name}"); return false; }
        if (!(_rigidbody = GetComponent<Rigidbody>())) { Debug.LogError($"Rigidbody�R���|�[�l���g���A�^�b�`����Ă��܂���B : {gameObject.name}"); return false; }

        return true;
    }
    /// <summary> �X�e�[�g���X�V </summary>
    void Update_State()
    {
        //������ : �������͂��Ȃ����idle���
        _playerState = PlayerStateEnum.Idle;

        //������
        if (Mathf.Abs(_rigidbody.velocity.x) > 0.5f || Mathf.Abs(_rigidbody.velocity.z) > 0.5f)
        {
            _playerState = PlayerStateEnum.Run;
        }
        //�W�����v���
        if (_playerMoveComponent.Get_IsGround() && Input.GetButtonDown("Jump"))
        {
            _playerState = PlayerStateEnum.Jump;
        }
        //��ڒn��� : ������㏸���̏ꍇ
        else if (!_playerMoveComponent.Get_IsGround())
        {
            _playerState = PlayerStateEnum.Fall;
        }
    }
}
