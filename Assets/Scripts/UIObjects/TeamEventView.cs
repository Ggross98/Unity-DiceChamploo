using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 事件、战斗界面显示玩家或敌人队伍成员
/// 包括下方展示立绘以及上方展示具体信息
/// </summary>
public class TeamEventView : MonoBehaviour
{

    [SerializeField]
    CharacterInfo info; //上方信息栏
    
    
    //下方队伍成员的预制体和列表
    private GameObject characterEventViewPrefab;

    private List<CharacterEventView> characterEventViewList = new List<CharacterEventView>();


    [SerializeField]
    Transform characterEventViewField; //显示玩家角色的区域，使用水平网格布局


    bool enemy = false;

    public void SetEnemy(bool e)
    {
        enemy = e;
        if (e)
        {
            foreach(CharacterEventView cev in characterEventViewList)
            {
                cev.SetEnemy(true);
            }
        }
    }

    /// <summary>
    /// 创建下方显示的角色立绘对象
    /// </summary>
    public void CreateCharacterObjects(/*传入队伍信息*/)
    {

        for (int i = 0; i < 4; i++)
        {
            GameObject obj = Instantiate(characterEventViewPrefab, characterEventViewField);

            obj.name = "角色" + (i + 1);

            CharacterEventView view = obj.GetComponent<CharacterEventView>();
            characterEventViewList.Add(view);

            //view.SetEnemy(false);

            view.GetButton().onClick.AddListener(delegate
            {
                ShowCharacterInfo();
            });

        }

        
    }

    public void ShowCharacterInfo(/*传入选中的角色数据*/)
    {
        info.SetActive(true);

        info.SetName("姓名");
        info.SetHealth(1,1);
        info.SetGender(true);
        info.SetLevel(1);

        //展示角色拥有的全部骰子
        info.ShowDices();
    }

    public void HideCharacterInfo()
    {
        info.SetActive(false);
    }

    private void Update()
    {
        if (!GameController.Instance.pause)
        {
            if (Input.GetMouseButtonUp(1))
            {
                HideCharacterInfo();
            }
        }
    }

    private void Awake()
    {
        characterEventViewPrefab = Resources.Load<GameObject>("Prefabs/CharacterEventViewPrefab");
    }

}
