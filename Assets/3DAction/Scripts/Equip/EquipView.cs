using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipView : MonoBehaviour
{
    [SerializeField] Image _viewIcon;
    [SerializeField] Text _viewName;
    
    //*******************************
    // ï`âÊèàóù
    public void Draw(EquipModel model)
    {
        _viewIcon.sprite = model.EquipIcon;
        _viewName.text = model.EquipName;
    }
}
