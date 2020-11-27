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

    private int fieldCell = 5; //骰子区域划分为多少格

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

        AudioManager.Instance.PlaySoundEffect("SE_Dice");

        List<DiceFaceData> list = new List<DiceFaceData>();

        bool[,] field = new bool[fieldCell, fieldCell];
        for(int i = 0; i < field.GetLength(0); i++)
        {
            for(int j = 0; j < field.GetLength(1); j++)
            {
                field[i, j] = false;
            }
        }

        foreach (DiceObject obj in diceObjects)
        {
            int x, y;
            do
            {
                x = Random.Range(0, fieldCell);
                y = Random.Range(0, fieldCell);

            } while (field[x, y] == true);

            field[x, y] = true;

            DiceFaceData dfd = obj.RollTo(GetCellPosition(x,y));
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

    private Vector2 GetCellPosition(int _x, int _y)
    {
        float x = fieldWidth / fieldCell * _x;
        float y = fieldHeight / fieldCell * _y;

        float deltaX = Random.Range(-fieldWidth / fieldCell / 5, fieldWidth / fieldCell / 5);
        float deltaY = Random.Range(-fieldHeight / fieldCell / 5, fieldHeight / fieldCell / 5);

        return new Vector2(x + deltaX - fieldWidth / 2, y + deltaY - fieldHeight / 2);
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
        obj.showFullInfo = true;
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
        obj.showFullInfo = true;

        diceObjects.Add(obj);

        obj.SetLocalPosition(GetRandomPosition());

        
    }

    public void ShowComboHint(List<DiceObject> selectedDices)
    {
        //Debug.Log("show combo hint");
        foreach (DiceObject obj in selectedDices)
        {
            obj.StopShake();
        }
        foreach(DiceObject obj in ComboData.GetShakingObjects(selectedDices, diceObjects))
        {
            obj.Shake();
        }

        /*
        //已经选到上面去的骰子
        var selectedList = new List<DiceFaceData>();
        foreach(DiceObject obj in selectedDices)
        {
            obj.StopShake();

            selectedList.Add(obj.currentFace);
        }

        //下面的骰子
        var rolledList = new List<DiceFaceData>();
        foreach(DiceObject obj in diceObjects)
        {
            rolledList.Add(obj.currentFace);
        }

        //包含选中骰子的组合
        var possible = ComboData.GetPossibleComboList(selectedList);


        foreach(List<DiceFaceData> dfd in possible)
        {
            bool access = true;

            foreach(DiceFaceData face in dfd)
            {
                if (ComboData.ContainsDiceFace(rolledList, face) || ComboData.ContainsDiceFace(selectedList, face))
                {
                    continue;
                }
                else
                {
                    access = false;
                    break;
                }
            }

            if (access)
            {
                foreach (DiceFaceData face in dfd)
                {
                    foreach(DiceObject obj in diceObjects)
                    {
                        if (obj.currentFace.Equals(face))
                        {
                            obj.Shake();
                        }
                    }
                }
            }
            
        }

        */
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
            obj.StopShake();
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
