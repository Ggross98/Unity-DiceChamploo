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

    private CharacterData selectedCharacter;
    
    
    //下方队伍成员的预制体和列表
    private GameObject characterEventViewPrefab;

    private List<CharacterEventView> characterEventViewList = new List<CharacterEventView>();


    [SerializeField]
    Transform characterEventViewField; //显示玩家角色的区域，使用水平网格布局

    private float fieldWidth = 200, fieldHeight = 200; //角色区域的大小


    [SerializeField]
    Text teamCountText;


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
    public void CreateCharacterObjects(List<CharacterData> characters)
    {
        if (characters == null || characters.Count < 0) return;

        for (int i = 0; i < characters.Count; i++)
        {
            CharacterData c = characters[i];

            GameObject obj = Instantiate(characterEventViewPrefab, characterEventViewField);

            obj.name = "角色" + (i + 1);

            CharacterEventView view = obj.GetComponent<CharacterEventView>();
            characterEventViewList.Add(view);

            view.ShowCharacter(c);
            //设置大小
            view.SetSize(fieldHeight);

            view.GetButton().onClick.AddListener(delegate
            {
                Debug.Log("click character");
                selectedCharacter = c;

                info.gameObject.SetActive(true);
                info.ShowCharacter(selectedCharacter);
            });

        }

        
    }

    public void ShowCharacterInfo(CharacterData cd)
    {
        //info.SetActive(true);

        info.ShowCharacter(cd);
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

        fieldWidth = characterEventViewField.GetComponent<RectTransform>().sizeDelta.x;
        fieldHeight = characterEventViewField.GetComponent<RectTransform>().sizeDelta.y;
    }

}
