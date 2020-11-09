using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 储存一个骰子六面的信息
/// </summary>
public class DiceData
{

    public DiceFaceData[] faces = new DiceFaceData[6];

    public DiceData()
    {
        for(int i = 0; i < 6; i++)
        {
            faces[i] = DiceFaceData.DiceFace_Blank;
        }

    }

    public DiceData(DiceFaceData[] _faces): this()
    {
        int max = Mathf.Min(6, _faces.Length);

        for(int i = 0; i < max; i++)
        {
            faces[i] = _faces[i];
        }

    }

    #region 数据库

    public static DiceData DiceData_TestOne = new DiceData(
        
        new DiceFaceData[]
        {
            DiceFaceData.DiceFace_TestOne,
            DiceFaceData.DiceFace_TestOne,
            DiceFaceData.DiceFace_TestOne,
            DiceFaceData.DiceFace_TestOne,
            DiceFaceData.DiceFace_TestOne,
            DiceFaceData.DiceFace_TestOne,
        }
        
        );

    public static DiceData DiceData_TestTwo = new DiceData(

       new DiceFaceData[]
       {
            DiceFaceData.DiceFace_TestOne,
            DiceFaceData.DiceFace_TestTwo,
            DiceFaceData.DiceFace_TestThree,
       }

       );

    #endregion
}
