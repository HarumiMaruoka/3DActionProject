using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerMove : MonoBehaviour
{
    //<======== ���̃N���X�Ŏg�p����l ========>//
    /// <summary> �M�Y����\�����邩�ǂ��� </summary>
    [Header("�f�o�b�O�p�M�Y����\�����邩�ǂ���"), SerializeField] bool _isGizmo;
    Rigidbody _rigidbody;
    Quaternion _targetRotation;

    //<===== �C���X�y�N�^����ݒ肷�ׂ��l =====>//
    [Header("�ړ����x"), SerializeField] float _moveSpeed;
    [Header("�W�����v��"), SerializeField] float _jumpPower;
    //=====�ڒn����֘A=====//
    [Header("�ڒn����̃I�t�Z�b�g"), SerializeField] Vector3 _groundCheckPos_Offset;
    [Header("�ڒn����p�L���[�u�̃T�C�Y"), SerializeField] Vector3 _groundCheck_Size;
    [Header("�ڒn���背�C���[�}�X�N"), SerializeField] LayerMask _groundCheck_LayerMask;
    [Header("��]����"), SerializeField] float _rotationSpeed;

    //<========�f�o�b�O�֘A========>//
    [Header("�f�o�b�O�pGizmo�̐F"), SerializeField] Color _gizmoColor;

    //<========== �v���p�e�B�ꗗ ==========>
    /// <summary> �v���C���[�̈ړ����x </summary>
    public float MoveSpeed { get => _moveSpeed; }

    void Start()
    {
        //�R���|�[�l���g���擾
        _rigidbody = GetComponent<Rigidbody>();
        //���̑��ݒ�
        Gizmos.color = _gizmoColor;
        _targetRotation = transform.rotation;
    }

    void Update()
    {
        Move();
    }

    /// <summary> �ړ����� </summary>
    void Move()
    {
        //<====== �ʏ�ړ����� ======>//
        //���̓x�N�g�����擾
        float inputV = Input.GetAxisRaw("Vertical");
        float inputH = Input.GetAxisRaw("Horizontal");
        float speed = 0f;
        Vector3 newVelocity = new Vector3(inputH, 0, inputV).normalized;

        //���C���J��������ɕ��������߂�B
        newVelocity = Camera.main.transform.TransformDirection(newVelocity);
        // �ړ�����������
        if (newVelocity.magnitude > 0.5f)
        {
            _targetRotation = Quaternion.LookRotation(newVelocity, Vector3.up);
            speed = Input.GetButton("Dash") ? 2 : 1;
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
        //���[�e�[�V������x��z��0�ɋ�������
        Quaternion adjustmenta = transform.rotation;
        adjustmenta.x = 0f;
        adjustmenta.z = 0f;
        transform.rotation = adjustmenta;


        //���x��^����
        newVelocity.y = 0;
        _rigidbody.velocity = newVelocity * _moveSpeed + Vector3.up * _rigidbody.velocity.y;

        //<===== �W�����v���� =====>//
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

    private void OnDrawGizmos()
    {
        if (_isGizmo)
        {
            //�ڒn����͈͂�Scene�r���[�ɕ`�悷��B
            Gizmos.DrawCube(transform.position + _groundCheckPos_Offset, _groundCheck_Size);
        }
    }
}
