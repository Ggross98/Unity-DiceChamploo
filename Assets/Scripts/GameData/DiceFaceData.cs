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


    #region 数据库

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

    #endregion
}
