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
            faces[i] = DiceFaceData.GetDiceFaceModel("BlankGreen");
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
            "MainCharacter_1",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Attack"),
                    DiceFaceData.GetDiceFaceModel("Attack"),
                    DiceFaceData.GetDiceFaceModel("Observation"),
                    DiceFaceData.GetDiceFaceModel("Observation"),
                    DiceFaceData.GetDiceFaceModel("Defense"),
                    DiceFaceData.GetDiceFaceModel("Defense"),


                }


            )

        }, 

        {
            "Red_A1",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Attack"),
                    DiceFaceData.GetDiceFaceModel("Attack"),
                    DiceFaceData.GetDiceFaceModel("Move"),
                    DiceFaceData.GetDiceFaceModel("Move"),
                    DiceFaceData.GetDiceFaceModel("BlankRed"),
                    DiceFaceData.GetDiceFaceModel("BlankRed"),


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
                    DiceFaceData.GetDiceFaceModel("Handle"),
                    DiceFaceData.GetDiceFaceModel("Handle"),
                    DiceFaceData.GetDiceFaceModel("BlankGreen"),
                    DiceFaceData.GetDiceFaceModel("BlankGreen"),


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
                    DiceFaceData.GetDiceFaceModel("BlankBlue"),
                    DiceFaceData.GetDiceFaceModel("BlankBlue"),


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
            "Blue_B2",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Observation"),
                    DiceFaceData.GetDiceFaceModel("Observation"),
                    DiceFaceData.GetDiceFaceModel("Observation"),
                    DiceFaceData.GetDiceFaceModel("Observation"),
                    DiceFaceData.GetDiceFaceModel("Observation"),
                    DiceFaceData.GetDiceFaceModel("Observation"),


                }


            )

        },

        {
            "Blue_C2",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Think"),
                    DiceFaceData.GetDiceFaceModel("Think"),
                    DiceFaceData.GetDiceFaceModel("Think"),
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
                    DiceFaceData.GetDiceFaceModel("BlankBrown"),
                    DiceFaceData.GetDiceFaceModel("BlankBrown"),


                }


            )

        },

        {
            "Enemy_Punch2",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Punch"),
                    DiceFaceData.GetDiceFaceModel("Punch"),
                    DiceFaceData.GetDiceFaceModel("Punch"),
                    DiceFaceData.GetDiceFaceModel("Punch"),
                    DiceFaceData.GetDiceFaceModel("Punch"),
                    DiceFaceData.GetDiceFaceModel("Punch"),

                }


            )

        },

        {
            "Enemy_Punch3",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("DoublePunch"),
                    DiceFaceData.GetDiceFaceModel("DoublePunch"),
                    DiceFaceData.GetDiceFaceModel("Punch"),
                    DiceFaceData.GetDiceFaceModel("Punch"),
                    DiceFaceData.GetDiceFaceModel("Punch"),
                    DiceFaceData.GetDiceFaceModel("Punch"),

                }


            )

        },

        {
            "Enemy_Punch4",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("DoublePunch"),
                    DiceFaceData.GetDiceFaceModel("DoublePunch"),
                    DiceFaceData.GetDiceFaceModel("DoublePunch"),
                    DiceFaceData.GetDiceFaceModel("DoublePunch"),
                    DiceFaceData.GetDiceFaceModel("Punch"),
                    DiceFaceData.GetDiceFaceModel("Punch"),

                }


            )

        },

        {
            "Enemy_Shield1",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Shield"),
                    DiceFaceData.GetDiceFaceModel("Shield"),
                    DiceFaceData.GetDiceFaceModel("Shield"),
                    DiceFaceData.GetDiceFaceModel("Shield"),
                    DiceFaceData.GetDiceFaceModel("BlankBrown"),
                    DiceFaceData.GetDiceFaceModel("BlankBrown"),


                }


            )

        },

        {
            "Enemy_Shield2",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Shield"),
                    DiceFaceData.GetDiceFaceModel("Shield"),
                    DiceFaceData.GetDiceFaceModel("Shield"),
                    DiceFaceData.GetDiceFaceModel("Shield"),
                    DiceFaceData.GetDiceFaceModel("Shield"),
                    DiceFaceData.GetDiceFaceModel("Shield"),

                }


            )

        },

        {
            "Enemy_Shield3",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("DoubleShield"),
                    DiceFaceData.GetDiceFaceModel("DoubleShield"),
                    DiceFaceData.GetDiceFaceModel("Shield"),
                    DiceFaceData.GetDiceFaceModel("Shield"),
                    DiceFaceData.GetDiceFaceModel("Shield"),
                    DiceFaceData.GetDiceFaceModel("Shield"),

                }


            )

        },

        {
            "Enemy_Shield4",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("DoubleShield"),
                    DiceFaceData.GetDiceFaceModel("DoubleShield"),
                    DiceFaceData.GetDiceFaceModel("DoubleShield"),
                    DiceFaceData.GetDiceFaceModel("DoubleShield"),
                    DiceFaceData.GetDiceFaceModel("Shield"),
                    DiceFaceData.GetDiceFaceModel("Shield"),

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
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),


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
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),

                }


            )

        },

        {
            "Enemy_Rifle1",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Rifle"),
                    DiceFaceData.GetDiceFaceModel("Rifle"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),


                }


            )

        },

        {
            "Enemy_Rifle2",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Rifle"),
                    DiceFaceData.GetDiceFaceModel("Rifle"),
                    DiceFaceData.GetDiceFaceModel("Rifle"),
                    DiceFaceData.GetDiceFaceModel("Rifle"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),

                }


            )

        },

        {
            "Enemy_Shotgun1",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Shotgun"),
                    DiceFaceData.GetDiceFaceModel("Shotgun"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),


                }


            )

        },

        {
            "Enemy_Shotgun2",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Shotgun"),
                    DiceFaceData.GetDiceFaceModel("Shotgun"),
                    DiceFaceData.GetDiceFaceModel("Shotgun"),
                    DiceFaceData.GetDiceFaceModel("Shotgun"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),

                }


            )

        },


        {
            "Enemy_Tesla1",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Tesla"),
                    DiceFaceData.GetDiceFaceModel("Tesla"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),


                }


            )

        },

        {
            "Enemy_Tesla2",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Tesla"),
                    DiceFaceData.GetDiceFaceModel("Tesla"),
                    DiceFaceData.GetDiceFaceModel("Tesla"),
                    DiceFaceData.GetDiceFaceModel("Tesla"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),
                    DiceFaceData.GetDiceFaceModel("BlankTeal"),

                }


            )

        },

        {
            "Enemy_Bomb1",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Bomb"),
                    DiceFaceData.GetDiceFaceModel("Bomb"),
                    DiceFaceData.GetDiceFaceModel("BlankRose"),
                    DiceFaceData.GetDiceFaceModel("BlankRose"),
                    DiceFaceData.GetDiceFaceModel("BlankRose"),
                    DiceFaceData.GetDiceFaceModel("BlankRose"),


                }


            )

        },

        {
            "Enemy_Bomb2",
            new DiceData(

                new DiceFaceData[]
                {
                    DiceFaceData.GetDiceFaceModel("Bomb"),
                    DiceFaceData.GetDiceFaceModel("Bomb"),
                    DiceFaceData.GetDiceFaceModel("Bomb"),
                    DiceFaceData.GetDiceFaceModel("Bomb"),
                    DiceFaceData.GetDiceFaceModel("BlankRose"),
                    DiceFaceData.GetDiceFaceModel("BlankRose"),

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
