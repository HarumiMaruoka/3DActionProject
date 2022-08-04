using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �v���C���[�̃X�e�[�g���Ǘ�����N���X </summary>
public class PlayerStateManager : MonoBehaviour
{
    // <===== ���̃N���X�Ŏg�p����^ =====> //
    /// <summary> �v���C���[�̃X�e�[�g��\���^ </summary>
    public enum PlayerStateEnum
    {
        Idle,
        Run,
        Jump,
        Fire1,
        Fire2,

        PlayerStateEnum_End
    }

    // <===== ���̃N���X�Ŏg�p����ϐ� =====> //
    [Header("���݂̃v���C���[�̃X�e�[�g"), SerializeField] PlayerStateEnum _playerState;
    /// <summary> �v���C���[�̃X�e�[�g </summary>
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

    /// <summary> �X�e�[�g���X�V </summary>
    void Update_State()
    {
        //������ : �������͂��Ȃ����idle���
        PlayerState = PlayerStateEnum.Idle;

        //����
        if (Mathf.Abs(_rigidbody.velocity.x) > 0.5f || Mathf.Abs(_rigidbody.velocity.z) > 0.5f)
        {
            PlayerState = PlayerStateEnum.Run;
        }

        //�W�����v
        if (_playerMoveComponent.Get_IsGround() && Input.GetButtonDown("Jump"))
        {
            PlayerState = PlayerStateEnum.Jump;
        }
    }
}
