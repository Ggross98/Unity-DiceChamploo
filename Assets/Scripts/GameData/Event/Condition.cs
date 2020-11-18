using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//判定类
class Condition
{
    public Condition() { }

    public virtual bool CheckCondition(List<DiceFaceData> dices) { return true; }

    public override string ToString()
    {
        return "确定";
    }
}

class GoldCondition : Condition
{
    int value;

    public GoldCondition(int val)
    {
        value = val;
    }

    public override bool CheckCondition(List<DiceFaceData> dices)
    {
        return GameController.Instance.gameData.gold >= value;
    }

    public override string ToString()
    {
        return "花费金钱: " + value.ToString();
    }
}

class DiceColorCondition : Condition
{
    int Red;
    int Blue;
    int Green;
    public DiceColorCondition(int r, int g, int b)
    {
        Red = r;
        Green = g;
        Blue = b;
    }
    public override bool CheckCondition(List<DiceFaceData> dices)
    {
        int countR = 0, countG = 0, countB = 0;
        Debug.Log(dices.Count);
        foreach (var dice in dices)
        {
            if (dice.type == DiceFaceData.Type.Red)
            {
                countR++;
            }
            else if (dice.type == DiceFaceData.Type.Blue)
            {
                countB++;
            }
            else if (dice.type == DiceFaceData.Type.Green)
            {
                countG++;
            }
        }

        //Debug.Log(countR + "," + countG + "," + countB);

        return Red <= countR && Blue <= countB && Green <= countG;
    }

    public override string ToString()
    {
        string result = "投掷: ";
        string prefix = "";

        if (Red > 0)
        {
            result += "红色x" + Red.ToString();
            prefix = ", ";
        }

        if (Green > 0)
        {
            result += prefix + "绿色x" + Green.ToString();
            prefix = ", ";
        }

        if (Blue > 0)
        {
            result += prefix + "蓝色x" + Blue.ToString();
        }

        return result;
    }
}
