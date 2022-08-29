using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����������̊��N���X : 
/// ����������́A�I�[�o�[���b�v���g���ē����蔻����s���B
/// �R���[�`�����𗘗p���āA�X�N���v�g���琧����s���B
/// </summary>
public class ShootingBase : WeaponBase
{
    /// <summary> �ˌ����@��\���^ </summary>
    [System.Serializable]
    public enum ShootingType
    {
        /// <summary> ���� </summary>
        Straight,
        /// <summary> �͈� </summary>
        Range,
    }

    /// <summary> ���̕���̎ˌ��^�C�v </summary>
    protected ShootingType _shootingType;

    protected override bool InitWeapon(bool pressType, bool isMainWeapon, ShootingType shootingType)
    {
        base.InitWeapon(pressType, isMainWeapon);
        _shootingType = shootingType;
        return true;
    }
}
