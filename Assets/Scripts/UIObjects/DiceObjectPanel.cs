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

            float x = Random.Range(fieldWidth*0.1f, fieldWidth*0.9f);
            float y = Random.Range(fieldHeight * 0.1f, fieldHeight * 0.9f);
            //obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(x-fieldWidth/2, y-fieldHeight/2);

            float angle = Random.Range(-180, 180);

            DiceFaceData dfd = obj.RollTo(new Vector2(x - fieldWidth / 2, y - fieldHeight / 2), angle);
            list.Add(dfd);
        }

        return list;
    }

    public bool IsEmpty()
    {
        return diceObjects.Count < 1;
    }

    private void Awake()
    {
        diceObjectPrefab = (GameObject)Resources.Load("Prefabs/DiceObjectPrefab");

        fieldWidth = diceField.GetComponent<RectTransform>().sizeDelta.x;
        fieldHeight = diceField.GetComponent<RectTransform>().sizeDelta.y;
    }

    public void CreateDiceObjects()
    {
        int count = 10;
        float deltaAngle = 360f / count * Mathf.PI / 180;

        for (int i = 0; i < 10; i++)
        {
            GameObject dice = Instantiate(diceObjectPrefab, diceField);
            DiceObject obj = dice.GetComponent<DiceObject>();

            //摆出一个圆形
            float r = Mathf.Min(fieldWidth, fieldHeight) / 3;

            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(r * Mathf.Cos(deltaAngle * i), r * Mathf.Sin(deltaAngle * i));

            diceObjects.Add(obj);
        }
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
                GameObject dice = Instantiate(diceObjectPrefab, diceField);
                DiceObject obj = dice.GetComponent<DiceObject>();

                obj.Init(d);

                diceObjects.Add(obj);

                count++;
            }
        }

        //摆成一个圆形
        float deltaAngle = 360f / count * Mathf.PI / 180;
        float r = Mathf.Min(fieldWidth, fieldHeight) / 3;

        for(int i = 0; i < diceObjects.Count; i++)
        {
            diceObjects[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(r * Mathf.Cos(deltaAngle * i), r * Mathf.Sin(deltaAngle * i));

        }

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
