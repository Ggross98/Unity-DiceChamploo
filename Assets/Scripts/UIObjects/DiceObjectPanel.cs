using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 事件、战斗界面，展示、控制骰子对象的面板
/// </summary>
public class DiceObjectPanel : MonoBehaviour
{
    [SerializeField]
    Transform diceField; //投掷骰子的区域

    GameObject diceObjectPrefab;
    List<DiceObject> diceObjects = new List<DiceObject>(); //骰子对象

    private float fieldWidth = 200, fieldHeight = 200; //骰子区域的大小

    public List<DiceObject> GetDiceObjects()
    {
        return diceObjects;
    }

    public List<DiceFaceData> RollAllDices()
    {
        /*
        if(diceObjects.Count == 0)
        {
            CreateDiceObjects();
        }*/

        List<DiceFaceData> list = new List<DiceFaceData>();

        foreach (DiceObject obj in diceObjects)
        {

            
            DiceFaceData dfd = obj.RollTo(GetRandomPosition());
            list.Add(dfd);
        }

        return list;
    }

    private Vector2 GetRandomPosition()
    {
        float x = Random.Range(fieldWidth * 0.1f, fieldWidth * 0.9f);
        float y = Random.Range(fieldHeight * 0.1f, fieldHeight * 0.9f);

        //float x = diceObjects.Count * 100;
        //float y = fieldHeight/2;

        return new Vector2(x - fieldWidth / 2, y - fieldHeight / 2);
    }

    public bool IsEmpty()
    {
        return diceObjects.Count < 1;
    }

    public bool ContainsDiceObject(DiceObject obj)
    {
        return diceObjects.Contains(obj);
    }

    private void Awake()
    {
        diceObjectPrefab = (GameObject)Resources.Load("Prefabs/DiceObjectPrefab");

        fieldWidth = diceField.GetComponent<RectTransform>().sizeDelta.x;
        fieldHeight = diceField.GetComponent<RectTransform>().sizeDelta.y;
    }
    
    /// <summary>
    /// 根据角色生成其拥有的全部骰子
    /// </summary>
    /// <param name="characters"></param>
    public void CreateDiceObjects(List<CharacterData> characters)
    {
        int count = 0;

        foreach(CharacterData c in characters){

            List<DiceData> dices = c.dices;

            foreach(DiceData d in dices)
            {
                /*
                GameObject dice = Instantiate(diceObjectPrefab, diceField);
                DiceObject obj = dice.GetComponent<DiceObject>();

                obj.Init(d);

                diceObjects.Add(obj);*/

                DiceObject obj = CreateDiceObject(d);

                AddDiceObject(obj);

                count++;
            }
        }

        //摆成一个圆形
        float deltaAngle = 360f / count * Mathf.PI / 180;
        float r = Mathf.Min(fieldWidth, fieldHeight) / 3;

        for(int i = 0; i < diceObjects.Count; i++)
        {
            diceObjects[i].SetLocalPosition( new Vector2(r * Mathf.Cos(deltaAngle * i), r * Mathf.Sin(deltaAngle * i)));

        }

    }

    /// <summary>
    /// 根据骰子数据创建一个ui对象
    /// </summary>
    /// <param name="dd"></param>
    /// <returns></returns>
    public DiceObject CreateDiceObject(DiceData dd)
    {

        GameObject dice = Instantiate(diceObjectPrefab);
        DiceObject obj = dice.GetComponent<DiceObject>();

        obj.Init(dd);

        return obj;
    }

    /// <summary>
    /// 将骰子对象加入投掷面板
    /// </summary>
    /// <param name="obj"></param>
    public void AddDiceObject(DiceObject obj)
    {
        obj.transform.SetParent(diceField, false);

        diceObjects.Add(obj);

        obj.SetLocalPosition(GetRandomPosition());

        
    }

    /// <summary>
    /// 将骰子对象移除出投掷面板
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public DiceObject RemoveDiceObject(DiceObject obj)
    {
        if (diceObjects.Contains(obj))
        {
            diceObjects.Remove(obj);

            return obj;
        }
        else return null;
    }

    public void ClearDiceObjects()
    {
        for(int i = 0; i < diceObjects.Count; i++)
        {
            Destroy(diceObjects[i].gameObject);
        }
        diceObjects.Clear();
    }

    
}
