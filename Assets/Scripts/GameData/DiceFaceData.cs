using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 储存骰子某一面的数据
/// </summary>
public class DiceFaceData
{
    //骰子面数据编号。或许可以用一个Dictionary来管理模板
    public int index = 0;

    public enum Type { Red, Green, Blue, None };

    
    public Type type = Type.None;

    public Sprite icon = null;

    public DiceFaceData() { }

    public DiceFaceData(int id, Type t, Sprite i)
    {
        index = id;
        type = t;
        icon = i;
    }

    public bool Equals(DiceFaceData obj)
    {
        return index == obj.index;
    }


    #region 数据库

    private static Dictionary<string, DiceFaceData> diceFaceDictionary = new Dictionary<string, DiceFaceData>() {

        { "Blank",
            new DiceFaceData(
                0,
                Type.None,
                Resources.Load<Sprite>("Dices/Dice_Blank")
            )
        },

        { "Attack",
           new DiceFaceData(
                10,
                Type.None,
                Resources.Load<Sprite>("Dices/Dice_Attack")
            )
        },

        { "Move",
           new DiceFaceData(
                11,
                Type.None,
                Resources.Load<Sprite>("Dices/Dice_Move")
            )
        },

        { "Observation",
            new DiceFaceData(
                20,
                Type.None,
                Resources.Load<Sprite>("Dices/Dice_Observation")
            )
        },

        { "Think",
            new DiceFaceData(
                21,
                Type.None,
                Resources.Load<Sprite>("Dices/Dice_Think")
            )
        },

        { "Defense",
            new DiceFaceData(
                30,
                Type.None,
                Resources.Load<Sprite>("Dices/Dice_Defense")
            )
        },

        { "Handle",
            new DiceFaceData(
                31,
                Type.None,
                Resources.Load<Sprite>("Dices/Dice_Handle")
            )
        },

        { "Pistol",

            new DiceFaceData(
                100,
                Type.None,
                Resources.Load<Sprite>("Dices/Dice_Blank")
            )

        },

        { "Rifle",

            new DiceFaceData(
                101,
                Type.None,
                Resources.Load<Sprite>("Dices/Dice_Blank")
            )

        },




    };

    public static DiceFaceData GetDiceFaceModel(string name)
    {
        if (diceFaceDictionary.ContainsKey(name))
        {
            return diceFaceDictionary[name];
        }
        else
        {
            return diceFaceDictionary["Blank"];
        }
    }


    /*
    public static DiceFaceData DiceFace_Blank = new DiceFaceData(

        0,
        Type.None,
        Resources.Load<Sprite>("Dices/Dice_Blank")

        
        
        
        );

    public static DiceFaceData DiceFace_TestOne = new DiceFaceData(
        
        -1,
        Type.None,
        Resources.LoadAll<Sprite>("Dices/Dice")[0]
        
        );

    public static DiceFaceData DiceFace_TestTwo = new DiceFaceData(

        -2,
        Type.None,
        Resources.LoadAll<Sprite>("Dices/Dice")[1]

        );

    public static DiceFaceData DiceFace_TestThree = new DiceFaceData(

        -3,
        Type.None,
        Resources.LoadAll<Sprite>("Dices/Dice")[2]

        );

    */
    #endregion
}
