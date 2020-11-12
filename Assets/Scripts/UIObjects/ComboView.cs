using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 战斗场景中，显示玩家骰子组合的ui组件
/// </summary>
public class ComboView : MonoBehaviour
{
    [SerializeField]
    Transform diceObjectField;

    List<DiceObject> diceObjects= new List<DiceObject>();

    [SerializeField]
    Text description;

    [SerializeField]
    Button button;

    public ComboData FindComboAndShow()
    {
        return FindComboAndShow(diceObjects);
    }

    public ComboData FindComboAndShow(List<DiceObject> list)
    {
        List<DiceFaceData> dfd = new List<DiceFaceData>();
        foreach(DiceObject obj in list)
        {
            dfd.Add(obj.currentFace);
        }

        return FindComboAndShow(dfd);
    }

    public ComboData FindComboAndShow(List<DiceFaceData> dfd)
    {
        Utils.SortDiceFaceDataList(dfd, true);

        ComboData cd = ComboData.MatchCombo(dfd);
        ShowCombo(cd);

        return cd;
    }

    public void ShowCombo(ComboData combo)
    {
        if(combo!=null)
            ShowInfo(true);
        else
        {
            ShowInfo(false);
            return;
        }

        
        string info = combo.name + "：";

        foreach(ComboEffect effect in combo.effects)
        {
            info += Utils.GetComboEffectString(effect);

        }
        //info.Remove(info.LastIndexOf('。'));

        description.text = info;
    }

    public void ShowInfo(bool a)
    {
        description.gameObject.SetActive(a);
        button.gameObject.SetActive(a);
    }

    public void AddDiceObject(DiceObject obj)
    {
        obj.transform.SetParent(diceObjectField);

        diceObjects.Add(obj);
    }

    public void RemoveDiceObject(DiceObject obj)
    {
        if(diceObjects.Contains(obj))
        {
            diceObjects.Remove(obj);
        }
    }

    public bool ContainsDiceObject(DiceObject obj)
    {
        return diceObjects.Contains(obj);
    }

    public void ClearDiceObjects() {

        for(int i = 0; i < diceObjects.Count; i++)
        {
            DiceObject obj = diceObjects[i];

            diceObjects.Remove(obj);

            Destroy(obj.gameObject);
        }


    }

    public Button GetButton()
    {
        return button;
    }
}
