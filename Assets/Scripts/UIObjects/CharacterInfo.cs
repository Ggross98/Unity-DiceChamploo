using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 队伍编辑、事件、战斗场景中，查看人物信息面板的管理类
/// 信息包括姓名、生命及生命上限、性别、等级的文本；骰子、立绘的图片
/// </summary>
public class CharacterInfo : MonoBehaviour
{
    public Image portrait;

    public Text nameText;

    public Text healthText;

    public Text genderText, levelText;

    //显示骰子信息
    [SerializeField]
    Transform diceField;

    GameObject diceViewPrefab;

    List<DiceView> diceViewList = new List<DiceView>();

    public void SetName(string s)
    {
        nameText.text = s;
    }

    public void SetHealth(int hp, int max)
    {
        healthText.text = hp + "/" + max;
    }

    public void SetGender(bool g)
    {
        genderText.text = g ? "♂" : "♀";
    }

    public void SetLevel(int i)
    {
        levelText.text = "Level " + i;
    }

    public void SetImage(Sprite s)
    {
        portrait.sprite = s;
    }

    public void SetActive(bool a)
    {
        gameObject.SetActive(a);
    }

    /// <summary>
    /// 根据传入的一个骰子数据生成并显示一个骰子六个面的数据
    /// </summary>
    public void CreateDiceView(/*Data of a dice*/)
    {
        GameObject obj = Instantiate(diceViewPrefab, diceField);

        DiceView dv = obj.GetComponent<DiceView>();

        //根据骰子显示区域的宽度改变图片大小
        dv.SetSize(diceField.GetComponent<RectTransform>().sizeDelta.x);
        

        diceViewList.Add(dv);

        
    }

    /// <summary>
    /// 清空已有的骰子对象，重新生成列表中的全部骰子
    /// </summary>
    public void ShowDices(/*List<Data of dice>*/)
    {
        ClearDiceView();

        for(int i = 0; i < 2; i++)
        {
            CreateDiceView();
        }
    }

    public void ShowCharacter(/*Data of a character*/)
    {
        //SetName("");
        //SetGender(true);
        //SetHealth(1, 1);
        //SetImage();
        //SetLevel(1);

        ShowDices();
    }



    /// <summary>
    /// 删除所有显示的骰子
    /// </summary>
    private void ClearDiceView()
    {
        for(int i = 0; i < diceViewList.Count; i++)
        {
            
            Destroy(diceViewList[i].gameObject);
        }

        diceViewList.Clear();
    }

    private void Awake()
    {
        diceViewPrefab = Resources.Load<GameObject>("Prefabs/DiceViewPrefab");
    }
}
