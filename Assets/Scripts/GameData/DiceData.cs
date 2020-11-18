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
            faces[i] = DiceFaceData.GetDiceFaceModel("Blank");
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

    private static Dictionary<string, DiceData> diceDictionary = new Dictionary<string, DiceData>()
    {
        {
            "Red_A1",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Attack"),
                    DiceFaceData.GetDiceFaceModel("Attack"),
                    DiceFaceData.GetDiceFaceModel("Move"),
                    DiceFaceData.GetDiceFaceModel("Move"),


                }


            )

        },

        {
            "Red_A2",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Attack"),
                    DiceFaceData.GetDiceFaceModel("Attack"),
                    DiceFaceData.GetDiceFaceModel("Attack"),
                    DiceFaceData.GetDiceFaceModel("Move"),
                    DiceFaceData.GetDiceFaceModel("Move"),
                    DiceFaceData.GetDiceFaceModel("Move"),


                }


            )

        },

        {
            "Green_A1",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Defense"),
                    DiceFaceData.GetDiceFaceModel("Defense"),
                    DiceFaceData.GetDiceFaceModel("Defense"),
                    DiceFaceData.GetDiceFaceModel("Handle"),


                }


            )

        },

        {
            "Green_A2",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Defense"),
                    DiceFaceData.GetDiceFaceModel("Defense"),
                    DiceFaceData.GetDiceFaceModel("Defense"),
                    DiceFaceData.GetDiceFaceModel("Defense"),
                    DiceFaceData.GetDiceFaceModel("Handle"),
                    DiceFaceData.GetDiceFaceModel("Handle"),


                }


            )

        },

        {
            "Blue_A1",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Observation"),
                    DiceFaceData.GetDiceFaceModel("Observation"),
                    DiceFaceData.GetDiceFaceModel("Think"),
                    DiceFaceData.GetDiceFaceModel("Think"),


                }


            )

        },

        {
            "Blue_A2",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Observation"),
                    DiceFaceData.GetDiceFaceModel("Observation"),
                    DiceFaceData.GetDiceFaceModel("Observation"),
                    DiceFaceData.GetDiceFaceModel("Think"),
                    DiceFaceData.GetDiceFaceModel("Think"),
                    DiceFaceData.GetDiceFaceModel("Think"),


                }


            )

        },

        {
            "Enemy_Punch1",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Punch"),
                    DiceFaceData.GetDiceFaceModel("Punch"),
                    DiceFaceData.GetDiceFaceModel("Punch"),
                    DiceFaceData.GetDiceFaceModel("Punch"),


                }


            )

        },

        {
            "Enemy_Pistol1",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Pistol"),
                    DiceFaceData.GetDiceFaceModel("Pistol"),


                }


            )

        },

        {
            "Enemy_Pistol2",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Pistol"),
                    DiceFaceData.GetDiceFaceModel("Pistol"),
                    DiceFaceData.GetDiceFaceModel("Pistol"),
                    DiceFaceData.GetDiceFaceModel("Pistol"),

                }


            )

        },

    };
    

    public static DiceData GetDiceDataModel(string str)
    {
        if (diceDictionary.ContainsKey(str))
        {
            return diceDictionary[str];
        }
        else
        {
            return new DiceData();
        }
    }

    #endregion
}
