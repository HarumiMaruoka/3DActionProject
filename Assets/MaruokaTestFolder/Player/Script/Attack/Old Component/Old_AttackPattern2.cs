using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old_AttackPattern2 : MonoBehaviour
{
    /// <summary> �ˌ��̃C���^�[�o�� </summary>
    float _fireOneInterval = -1;
    /// <summary> �a���̃C���^�[�o�� </summary>
    float _fireTowInterval = -1;

    /// <summary> ���N���b�N�U�����\���ǂ��� </summary>
    bool _isFireOne = true;
    /// <summary> �E�N���b�N�U�����\���ǂ��� </summary>
    bool _isFireTow = true;

    void Start()
    {

    }

    void Update()
    {
        AttackFireOne();
        AttackFireTow();
    }


    /// <summary> ���N���b�N���̋��� </summary>
    void AttackFireOne()
    {
        if (Input.GetButtonDown("Fire1") && _isFireOne)
        {
            //�C���^�[�o���J�n
            StartCoroutine(FireOneInterval_WaitCoroutine());
            //�����ɍU�����̏����������B

        }
    }

    /// <summary> �E�N���b�N���̋��� </summary>
    void AttackFireTow()
    {
        if (Input.GetButtonDown("Fire2") && _isFireTow)
        {
            //�C���^�[�o���J�n
            StartCoroutine(FireTowInterval_WaitCoroutine());
            //�����ɍU�����̏����������B

        }
    }

    /// <summary> FireOne�U���̃C���^�[�o����ݒ肷��B </summary>
    public void SetFireOneInterval(float interval)
    {
        _fireOneInterval = interval;
    }

    /// <summary> FireTow�U���̃C���^�[�o����ݒ肷��B </summary>
    public void SetFireTowInterval(float interval)
    {
        _fireTowInterval = interval;
    }

    /// <summary> Fire1�U���̃C���^�[�o����҂B </summary>
    IEnumerator FireOneInterval_WaitCoroutine()
    {
        _isFireOne = false;

        yield return new WaitForSeconds(_fireOneInterval);

        _isFireOne = true;
    }

    /// <summary> Fire2�U���̃C���^�[�o����҂B </summary>
    IEnumerator FireTowInterval_WaitCoroutine()
    {
        _isFireTow = false;

        yield return new WaitForSeconds(_fireTowInterval);

        _isFireTow = true;
    }
}
