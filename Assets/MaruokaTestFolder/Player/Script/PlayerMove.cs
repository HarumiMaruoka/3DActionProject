using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̈ړ��𐧌䂷��N���X�B
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    //<======== �����o�[�ϐ� � �v���p�e�B ========>//
    // ***** �g�p���鑼�R���|�[�l���g ***** //
    Rigidbody _rigidbody;
    Quaternion _targetRotation;

    // ***** �ړ��ɒ��ړI�Ɋւ��l ***** //
    [Header("�ړ����x"), SerializeField] float _moveSpeed = 5f;
    /// <summary> �v���C���[�̈ړ����x </summary>
    public float MoveSpeed { get => _moveSpeed; }
    [Header("�W�����v��"), SerializeField] float _jumpPower = 10f;

    // ***** �ڒn����֘A ***** //
    [Header("�ڒn����̃I�t�Z�b�g"), SerializeField] Vector3 _groundCheckPos_Offset;
    [Header("�ڒn����p�L���[�u�̃T�C�Y"), SerializeField] Vector3 _groundCheck_Size;
    [Header("�ڒn���背�C���[�}�X�N"), SerializeField] LayerMask _groundCheck_LayerMask;
    [Header("��]����"), SerializeField] float _rotationSpeed;

    // ***** �f�o�b�O�֘A ***** //
    /// <summary> �M�Y����\�����邩�ǂ��� </summary>
    [Header("�f�o�b�O�p�M�Y����\�����邩�ǂ���"), SerializeField] bool _isGizmo;
    [Header("�f�o�b�O�pGizmo�̐F"), SerializeField] Color _gizmoColor;

    // ***** ���͒l ***** //
    float _inputV = 0f;
    float _inputH = 0f;
    bool _isDash = false;

    //<===== Unity���b�Z�[�W =====>//
    void Start()
    {
        Initialized();
    }
    void Update()
    {
        Input_Move();
        Update_Move();
    }
    void OnDrawGizmos()
    {
        if (_isGizmo)
        {
            //�ڒn����͈͂�Scene�r���[�ɕ`�悷��B
            Gizmos.DrawCube(transform.position + _groundCheckPos_Offset, _groundCheck_Size);
        }
    }

    //<===== private�����o�[�֐� =====>//
    /// <summary> ���������� </summary>
    /// <returns> �������ɐ��������� true ��Ԃ��B </returns>
    bool Initialized()
    {
        //�R���|�[�l���g���擾
        _rigidbody = GetComponent<Rigidbody>();
        //���̑��ݒ�
        Gizmos.color = _gizmoColor;
        _targetRotation = transform.rotation;

        return true;
    }

    /// <summary> ���͏��� </summary>
    void Input_Move()
    {
        //���̓x�N�g�����擾
        _inputV = Input.GetAxisRaw("Vertical");
        _inputH = Input.GetAxisRaw("Horizontal");
        //�_�b�V���L�[�̓��͂��擾
        _isDash = Input.GetButton("Dash");
    }

    /// <summary> �ړ����� </summary>
    void Update_Move()
    {
        float speed = 0f;
        Vector3 newVelocity = new Vector3(_inputH, 0, _inputV).normalized;

        //�@���C���J��������ɕ��������߂�B
        newVelocity = Camera.main.transform.TransformDirection(newVelocity);
        // �ړ�����������
        if (newVelocity.magnitude > 0.5f)
        {
            _targetRotation = Quaternion.LookRotation(newVelocity, Vector3.up);
            speed = _isDash ? 2 : 1;
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);

        //���x��^����
        newVelocity.y = 0;
        _rigidbody.velocity = newVelocity * _moveSpeed + Vector3.up * _rigidbody.velocity.y * speed;

        // �W�����v����
        if (Jump())
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.velocity = Vector3.up * _jumpPower;
        }
    }

    /// <summary> �W�����v���� </summary>
    /// <returns> �W�����v����ꍇtrue��Ԃ��B�����łȂ����false��Ԃ��B </returns>
    bool Jump()
    {
        //�ڒn���W�����v���͂�true��Ԃ��B
        if (Get_IsGround() && Input.GetButtonDown("Jump"))
        {
            return true;
        }
        return false;
    }

    //<===== public�����o�[�֐� =====>//
    /// <summary> �ڒn���� </summary>
    /// <returns> �ڒn���Ă����true��Ԃ��B�����łȂ����false��Ԃ��B </returns>
    public bool Get_IsGround()
    {
        Vector3 overLapBoxCenter = transform.position + _groundCheckPos_Offset;
        Collider[] collision = Physics.OverlapBox(
            overLapBoxCenter,
            _groundCheck_Size,
            Quaternion.identity,
            _groundCheck_LayerMask);
        if (collision.Length != 0)
        {
            return true;
        }
        return false;
    }
}
