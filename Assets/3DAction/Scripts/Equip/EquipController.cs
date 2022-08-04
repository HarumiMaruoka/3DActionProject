//*********************************************
// 概　要：装備管理者
// 作成者：ta.kusumoto
// 作成日：2022/08/04

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EquipController : MonoBehaviour
{
    [SerializeField] EquipView _equipView;  // 見かけ(view)に関することを操作
    EquipModel _equipModel;                 // データ(model)に関することを操作

    //****************************
    // 初期化
    public void Initialize(EquipInfo info)
    {
        _equipModel = new EquipModel(info);
        _equipView.Draw(_equipModel);
    }

    //****************************
    // 装備情報(読み取り用)
    public EquipModel EquipModel { get => _equipModel; }
}
