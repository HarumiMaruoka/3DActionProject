using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> ��{�a������ : �e�X�g�i�K </summary>
public class BasicSlash : SlashingBase
{
    //<===== �����o�[�ϐ� =====>//
    [Header("�A�j���[�V�����N���b�v��"), SerializeField] string _animClip;

    //<===== Unity���b�Z�[�W =====>//
    void Start()
    {
        InitWeapon(PRESS_TYPE_MOMENT,MAIN_WEAPON);
        ChangeWeapon();
    }
    void Update()
    {
        
    }

    //<===== protected�����o�[�֐� =====>//
    /// <summary> �U������ </summary>
    protected override void OnFire_ThisWeapon()
    {
        //�A�j���[�V�������Đ�����B
        _myComponent_Animator.Play(_animClip);
    }
    protected override bool InitWeapon(bool pressType, bool isMainWeapon)
    {
        _myComponent_Collider = transform.GetChild(0).GetComponent<Collider>();
        _myComponent_Animator = GetComponent<Animator>();
        return base.InitWeapon(pressType, isMainWeapon);
    }
}
