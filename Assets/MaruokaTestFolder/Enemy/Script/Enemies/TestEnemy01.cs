using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ۂ̃G�l�~�[�p�R���|�[�l���g�B�e�X�g�i�K�B
/// ���̃G�l�~�[�͓����Ȃ��u���G�l�~�[
/// </summary>
public class TestEnemy01 : EnemyBase
{
    //<===== Unity���b�Z�[�W =====>//
    void Update()
    {
        if (_status._hitPoint < 0f)
        {
            Debug.Log($"�̗͂��Ȃ��Ȃ����̂ł���܂����B{gameObject.name}");
            Destroy(gameObject);
        }
    }
}
