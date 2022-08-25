using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EnemyBase�N���X�B
/// �S�G�l�~�[�ɋ��ʂ��ĕK�v�����ȗv�f���L�q���Ă���B
/// ����Ȃ����̂�s�v�Ȃ��̂�����Ε񍐂��Ă��������B
/// </summary>
public class EnemyBase : MonoBehaviour
{
    //<===== �����o�[�ϐ� =====>//
    [Header("���̃L�����̃X�e�[�^�X"), SerializeField] EnemyStatus _status;

    //<===== protected�����o�[�֐� =====>//
    /// <summary> ���ʏ��������� : �I�[�o�[���C�h�s�� </summary>
    protected void CommonInitialized() { }
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
    public virtual void HitAttack()
    {

    }
    /// <summary> �U���̃q�b�g�֐��B�v���C���[��OnCollision()��OnTrigger()����Ăяo���B : �I�[�o�[���C�h�� </summary>
    /// <param name="damage"> �_���[�W�� </param>
    public virtual void HitAttack(int damage)
    {

    }
    /// <summary> �U���̃q�b�g�֐��B�v���C���[��OnCollision()��OnTrigger()����Ăяo���B : �I�[�o�[���C�h�� </summary>
    /// <param name="damage"> �_���[�W�� </param>
    /// <param name="stiffeningTime"> �d������ </param>
    public virtual void HitAttack(int damage, float stiffeningTime)
    {

    }
    /// <summary> �U���̃q�b�g�֐��B�v���C���[��OnCollision()��OnTrigger()����Ăяo���B : �I�[�o�[���C�h�� </summary>
    /// <param name="damage"> �_���[�W�� </param>
    /// <param name="knockbackDirection"> �m�b�N�o�b�N���� </param>
    /// <param name="knockbackPower"> �m�b�N�o�b�N�З� </param>
    /// <param name="stiffeningTime"> �d������ </param>
    public virtual void HitAttack(int damage, Vector3 knockbackDirection, float knockbackPower, float stiffeningTime)
    {

    }
}

/// <summary> Enemy�̃X�e�[�^�X��\���^ </summary>
[System.Serializable]
public struct EnemyStatus
{
    /// <summary> �̗� </summary>
    public float _hitPoint;
    /// <summary> �U���� </summary>
    public float _offensivePower;
    /// <summary> �ړ����x </summary>
    public float _moveSpeed;
}