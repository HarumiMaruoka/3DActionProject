using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EnemyBase�N���X�B
/// �S�G�l�~�[�ɋ��ʂ��ĕK�v�����ȗv�f���L�q���Ă���B
/// ����Ȃ����̂�s�v�Ȃ��̂�����Ε񍐂��Ă��������B
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class EnemyBase : MonoBehaviour
{
    //<===== �����o�[�ϐ� =====>//
    [Header("���̃L�����̃X�e�[�^�X"), SerializeField] protected EnemyStatus _status;
    public EnemyStatus Status { get => _status; set => _status = value; }
    protected bool _isMove;
    protected Rigidbody _rigidbody;

    //<===== protected�����o�[�֐� =====>//
    /// <summary> ���ʏ��������� : �I�[�o�[���C�h�s�� </summary>
    protected void CommonInitialized() { _rigidbody = GetComponent<Rigidbody>(); }
    /// <summary> ���ʍX�V���� : �I�[�o�[���C�h�s�� </summary>
    protected void CommonUpdate() { }
    /// <summary> �h����Ǝ��̏��������� : �I�[�o�[���C�h�� </summary>
    protected virtual void OriginalInitialized() { }
    /// <summary> �h����Ǝ��̍X�V���� : �I�[�o�[���C�h�� </summary>
    protected virtual void OriginalUpdate() { }
    /// <summary> �ړ����� : �I�[�o�[���C�h�� </summary>
    protected virtual void Move() { }

    //<===== private�����o�[�֐� =====>//


    //<===== public�����o�[�֐� =====>//
    /// <summary> �U���̃q�b�g�֐��B�v���C���[��OnCollision()��OnTrigger()����Ăяo���B : �I�[�o�[���C�h�� </summary>
    /// <param name="damage"> �_���[�W�� </param>
    public virtual void HitAttack(int damage)
    {
        //�̗͂����炷
        _status._hitPoint -= damage;
    }
    /// <summary> �U���̃q�b�g�֐��B�v���C���[��OnCollision()��OnTrigger()����Ăяo���B : �I�[�o�[���C�h�� </summary>
    /// <param name="damage"> �_���[�W�� </param>
    /// <param name="stiffeningTime"> �d������ </param>
    public virtual void HitAttack(int damage, float stiffeningTime)
    {
        //�̗͂����炵�A�w�肳�ꂽ���ԍd������B
        _status._hitPoint -= damage;
        StartCoroutine(WaitForStiffness(stiffeningTime));
    }
    /// <summary> �U���̃q�b�g�֐��B�v���C���[��OnCollision()��OnTrigger()����Ăяo���B : �I�[�o�[���C�h�� </summary>
    /// <param name="damage"> �_���[�W�� </param>
    /// <param name="knockbackDirection"> �m�b�N�o�b�N���� </param>
    /// <param name="knockbackPower"> �m�b�N�o�b�N�p���[ </param>
    public virtual void HitAttack(int damage, Vector3 knockbackDirection, float knockbackPower)
    {
        //�̗͂����炵�A�m�b�N�o�b�N����B
        _status._hitPoint -= damage;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(knockbackDirection * knockbackPower, ForceMode.Impulse);
    }
    /// <summary> �U���̃q�b�g�֐��B�v���C���[��OnCollision()��OnTrigger()����Ăяo���B : �I�[�o�[���C�h�� </summary>
    /// <param name="damage"> �_���[�W�� </param>
    /// <param name="knockbackDirection"> �m�b�N�o�b�N���� </param>
    /// <param name="knockbackPower"> �m�b�N�o�b�N�p���[ </param>
    /// <param name="stiffeningTime"> �d������ </param>
    public virtual void HitAttack(int damage, Vector3 knockbackDirection, float knockbackPower, float stiffeningTime)
    {

        //�̗͂����炵�A�m�b�N�o�b�N���A�w�肳�ꂽ���ԍd������B
        _status._hitPoint -= damage;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(knockbackDirection * knockbackPower, ForceMode.Impulse);
        StartCoroutine(WaitForStiffness(stiffeningTime));
    }

    //<===== �R���[�`�� =====>//
    /// <summary> �d�����Ԃ�҂B�d�����Ԓ��͓����Ȃ��悤�ɂ���B </summary>
    /// <param name="stiffeningTime"> �d�����鎞�� </param>
    IEnumerator WaitForStiffness(float stiffeningTime)
    {
        _isMove = false;
        yield return new WaitForSeconds(stiffeningTime);
        _isMove = true;
    }
}

/// <summary> Enemy�̃X�e�[�^�X��\���^ </summary>
[System.Serializable]
public struct EnemyStatus
{
    /// <summary> EnemyStatus�̃R���X�g���N�^ </summary>
    /// <param name="hitPoint"> �̗� </param>
    /// <param name="offensivePower"> �U���� </param>
    /// <param name="moveSpeed"> �ړ����x </param>
    public EnemyStatus(float hitPoint = 5f, float offensivePower = 5f, float moveSpeed = 10f)
    {
        _hitPoint = hitPoint;
        _offensivePower = offensivePower;
        _moveSpeed = moveSpeed;
    }

    /// <summary> �̗� </summary>
    public float _hitPoint;
    /// <summary> �U���� </summary>
    public float _offensivePower;
    /// <summary> �ړ����x </summary>
    public float _moveSpeed;
}