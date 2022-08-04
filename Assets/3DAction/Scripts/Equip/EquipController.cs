using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EquipController : MonoBehaviour
{
    [SerializeField] EquipView _equipView;  // ������(view)�Ɋւ��邱�Ƃ𑀍�
    EquipModel _equipModel;                 // �f�[�^(model)�Ɋւ��邱�Ƃ𑀍�

    //****************************
    // ������
    public void Initialize(EquipInfo info)
    {
        _equipModel = new EquipModel(info);
        _equipView.Draw(_equipModel);
    }

    //****************************
    // �������(�ǂݎ��p)
    public EquipModel EquipModel { get => _equipModel; }
}
