using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ߋ�������̊��N���X : 
/// �ߋ�������́A�R���C�_�[���g���Ĕ�����s���B
/// �R���C�_�[�̃I���E�I�t�̓A�j���[�V�����C�x���g����s���B
/// </summary>
public class SlashingBase : WeaponBase
{
    //<===== �����o�[�ϐ� =====>//
    protected Collider _myComponent_Collider;
    protected Animator _myComponent_Animator;

    //<===== ���z�֐� =====>//
    //�Փˎ��̏���
    void OnCollisionEnter(Collision collision)
    {
        //�G�l�~�[�ڐG���̏���
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyBase enemy))
        {
            HitEnemy(enemy);
        }
    }
    /// <summary> �������֐� </summary>
    /// <param name="pressType"> �U�����s�^�C�v </param>
    /// <param name="isMainWeapon"> ���C���E�G�|�����ǂ��� </param>
    /// <returns> �������ɐ��������� true ��Ԃ��B </returns>
    protected override bool InitWeapon(bool pressType, bool isMainWeapon)
    {
        return base.InitWeapon(pressType, isMainWeapon);
    }
    /// <summary> �U�����G�l�~�[�Ƀq�b�g�����Ƃ��̏��� </summary>
    /// <param name="enemy"> �U���Ώ� </param>
    protected virtual void HitEnemy(EnemyBase enemy)
    {
        EnemyStatus status = enemy.Status;
        status._hitPoint -= _offensivePower;
        enemy.Status = status;
    }

    //<===== �����o�[�֐� =====>//
    /// <summary> 
    /// ���̃Q�[���I�u�W�F�N�g�ɃA�^�b�`���ꂽ�R���C�_�[���A�N�e�B�u�ɂ���B
    /// AnimationEvent������s����z��B
    /// </summary>
    protected void ColliderEnableOn()
    {
        _myComponent_Collider.enabled = true;
    }
    /// <summary> 
    /// ���̃Q�[���I�u�W�F�N�g�ɃA�^�b�`���ꂽ�R���C�_�[���A�N�e�B�u�ɂ���B
    /// AnimationEvent������s����z��B
    /// </summary>
    protected void ColliderEnableOff()
    {
        _myComponent_Collider.enabled = false;
    }
}
