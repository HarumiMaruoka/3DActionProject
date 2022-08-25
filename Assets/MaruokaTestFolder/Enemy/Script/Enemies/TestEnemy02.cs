using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ۂ̃G�l�~�[�p�R���|�[�l���g�B�e�X�g�i�K�B
/// ���̃G�l�~�[�̓v���C���[�Ɍ������Ĉړ�����G�l�~�[�B
/// </summary>
public class TestEnemy02 : EnemyBase
{
    //<===== �����o�[�ϐ� =====>//
    Transform _playerPos;

    //<===== Unity���b�Z�[�W =====>//
    void Start()
    {
        CommonInitialized();
    }
    void Update()
    {
        OriginalUpdate();
    }

    //<===== protected�����o�[�֐� =====>//
    /// <summary> ���̃N���X�Ǝ��̏��������� </summary>
    protected override void OriginalInitialized()
    {
        //�v���C���[�̃g�����X�t�H�[�����擾����B
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    protected override void OriginalUpdate()
    {
        Move();
    }
    /// <summary> �ړ����� : �v���C���[�Ɍ������Đi�� </summary>
    protected override void Move()
    {
        if (_isMove)
        {
            float velocityY = _rigidbody.velocity.y;
            _rigidbody.velocity = (transform.position - _playerPos.position).normalized * _status._moveSpeed;
            _rigidbody.velocity += Vector3.up * velocityY;
        }
    }
}
