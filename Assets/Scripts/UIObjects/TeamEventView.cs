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

    [HideInInspector]
    public CharacterData selectedCharacter;

    
    
    //下方队伍成员的预制体和列表
    private GameObject characterEventViewPrefab;

    private List<CharacterEventView> characterEventViewList = new List<CharacterEventView>();

    private Dictionary<CharacterData, CharacterEventView> characters = new Dictionary<CharacterData, CharacterEventView>();

    [SerializeField]
    Transform characterEventViewField; //显示玩家角色的区域，使用水平网格布局

    private float fieldWidth = 200, fieldHeight = 200; //角色区域的大小


    [SerializeField]
    Text teamCountText;

    public TeamData team;


    public bool enemy = false;

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

    public void CreateCharacterObjects(TeamData td)
    {
        team = td;

        CreateCharacterObjects(team.characters);
    }

    /// <summary>
    /// 创建下方显示的角色立绘对象
    /// </summary>
    public void CreateCharacterObjects(List<CharacterData> chs)
    {
        if (chs == null || chs.Count < 0) return;

        for (int i = 0; i < chs.Count; i++)
        {
            CharacterData c = chs[i];

            GameObject obj = Instantiate(characterEventViewPrefab, characterEventViewField);

            obj.name = "角色" + (i + 1);

            CharacterEventView view = obj.GetComponent<CharacterEventView>();
            characterEventViewList.Add(view);

            view.ShowCharacter(c);
            //设置大小
            view.SetSize(fieldHeight);

            view.GetButton().onClick.AddListener(delegate
            {
                //Debug.Log("click character");
                selectedCharacter = c;

                CancelSelectAll();
                view.ShowAura(true);

                info.gameObject.SetActive(true);
                info.ShowCharacter(selectedCharacter);
            });

            characters.Add(c, view);

        }

        
    }

    /// <summary>
    /// 所有角色是否均死亡
    /// </summary>
    /// <returns></returns>
    public bool IsOver()
    {
        return characters.Count <= 0;
    }

    public void Refresh()
    {
        List<CharacterData> toRemove = new List<CharacterData>();
        List<GameObject> toKill = new List<GameObject>();

        //检查成员是否均存活。删除死亡对象
        foreach(CharacterData cd in characters.Keys)
        {
            if (!cd.IsAlive())
            {
                toRemove.Add(cd);
                
                CharacterEventView view = characters[cd];

                toKill.Add(view.gameObject);
            }
        }

        for(int i = 0; i < toRemove.Count; i++)
        {
            if (selectedCharacter == toRemove[i])
                selectedCharacter = null;
            characters.Remove(toRemove[i]);
        }

        for(int i = 0; i < toKill.Count; i++)
        {
            Destroy(toKill[i]);
        }

        if (info.isActiveAndEnabled)
        {
            info.ShowCharacter(selectedCharacter);
        }
    }

    private void CancelSelectAll()
    {
        foreach(CharacterEventView view in characterEventViewList)
        {
            view.ShowAura(false);
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
