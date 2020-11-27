using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 储存一个角色的全部信息，包括：
/// 所属阵营（敌人、友方）；
/// 姓名、性别、等级、骰子数据、立绘；
/// 当前和最大生命；
/// 各个等级下的以上数据
/// </summary>
public class CharacterData: IModel<CharacterData>
{
    //角色模板编号。或许可以用一个Dictionary来管理模板
    public int index;

    public string name;

    //true：男；false：女
    public bool gender;

    public int level, maxLevel;

    public int hp, maxHp;
    //各个等级下的生命值上限
    protected int[] maxHpBank;

    public Sprite portrait;

    //当前拥有的骰子
    public List<DiceData> dices;

    //各个等级下拥有的骰子
    protected List<DiceData>[] dicesBank;

    //阵营
    public enum Faction { Player, Enemy};
    public Faction faction = Faction.Player;



    public void ChangeHP(int delta)
    {
        hp += delta;
        if (hp < 0) hp = 0;
        if (hp > maxHp) hp = maxHp;
    }

    public void Damage(int i)
    {
        ChangeHP(-i);
    }

    public bool IsAlive()
    {
        return hp > 0;
    }

    public CharacterData()
    {
        index = 0;

        name = "";
        gender = true;

        level = 1;
        maxLevel = 1;

        
        hp = 1;
        maxHp = 1;
        maxHpBank = new int[maxLevel];


        portrait = null;

        dices = new List<DiceData>();
        dicesBank = new List<DiceData>[maxLevel];
    }

    public CharacterData(int id, string nm, bool g, int _maxLevel, int[] _hpBank, Sprite _portrait, List<DiceData>[] _dicesBank)
    {

        if(_maxLevel<1 || _hpBank.Length!=_maxLevel || _dicesBank.Length!= _maxLevel)
        {
            Debug.Log("Error at creating character data!");
            return;
        }

        index = id;

        name = nm;

        gender = g;

        level = 1;
        maxLevel = _maxLevel;

        maxHpBank = _hpBank;
        maxHp = maxHpBank[0];
        hp = maxHp;


        portrait = _portrait;

        dicesBank = _dicesBank;
        dices = dicesBank[0];



    }

    public void Upgrade()
    {
        if (level < maxLevel)
        {
            SetLevel(level + 1);
        }
    }

    public int UpgradeCost()
    {
        return level * 5;
    }

    public void SetLevel(int lv)
    {
        if (lv < 1 || lv > maxLevel) return;

        level = lv;

        //改变血量
        int delta = maxHpBank[level - 1] - maxHp;
        
        maxHp = maxHpBank[level - 1];
        ChangeHP(delta);

        //改变骰子
        dices = dicesBank[level - 1];


        
    }

    public CharacterData Model()
    {
        CharacterData cd = new CharacterData();

        cd.index = index;
        cd.name = name;
        cd.gender = gender;
        cd.level = level;
        cd.maxLevel = maxLevel;
        cd.hp = hp;
        cd.maxHp = maxHp;
        cd.maxHpBank = maxHpBank;
        cd.portrait = portrait;
        cd.dices = dices;
        cd.dicesBank = dicesBank;
        cd.faction = faction;
        
        return cd;
    }


    //*********************************数据库

    private static CharacterData MainCharacter_1 = new CharacterData(
        1,
        "维托",
        true,
        3,
        new int[] { 10, 15, 20 },
        Resources.Load<Sprite>("Characters/MainCharacters/1"),
        new List<DiceData>[]
        {
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("MainCharacter_1"),
                    DiceData.GetDiceDataModel("Red_A1"),
                    
                

                    //DiceData.GetDiceDataModel("MainCharacter_1"),

                },
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("MainCharacter_1"),
                    //DiceData.GetDiceDataModel("MainCharacter_1"),
                    DiceData.GetDiceDataModel("Red_A2"),
                    
                    //DiceData.GetDiceDataModel("Red_A1"),
                    //DiceData.GetDiceDataModel("Green_A1")


                },
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("MainCharacter_1"),
                    DiceData.GetDiceDataModel("MainCharacter_1"),
                    DiceData.GetDiceDataModel("Red_A2"),
                    //DiceData.GetDiceDataModel("Red_A1"),
                    //DiceData.GetDiceDataModel("Green_A2")


                }
        }
    );

    private static CharacterData MainCharacter_2 = new CharacterData(
        2,
        "加文",
        true,
        3,
        new int[] { 10, 15, 20    },
        Resources.Load<Sprite>("Characters/MainCharacters/2"),
        new List<DiceData>[]
    {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Red_A2"),
                //DiceData.GetDiceDataModel("Red_A1"),
                DiceData.GetDiceDataModel("Blue_A1"),

            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Red_A2"),
                DiceData.GetDiceDataModel("Red_A1"),
                DiceData.GetDiceDataModel("Blue_A1"),
                

            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Red_A2"),
                DiceData.GetDiceDataModel("Red_A1"),
                DiceData.GetDiceDataModel("Blue_A2"),


            }
    }
        
    
    );

    private static CharacterData MainCharacter_3 = new CharacterData(
        3,
        "Chip",
        false,
        3,
        new int[] { 10, 15, 20 },
        Resources.Load<Sprite>("Characters/MainCharacters/3"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Green_A2"),
                DiceData.GetDiceDataModel("Red_A1"),
                //DiceData.GetDiceDataModel("Enemy_Shield1"),


            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Green_A2"),
                DiceData.GetDiceDataModel("Green_A1"),
                DiceData.GetDiceDataModel("Red_A1"),


            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Green_A2"),
                DiceData.GetDiceDataModel("Green_A2"),
                DiceData.GetDiceDataModel("Red_A1"),

                //DiceData.GetDiceDataModel("Green_A1")


            }
        }


        );

    private static CharacterData MainCharacter_4 = new CharacterData(
        4,
        "玛雅",
        false,
        3,
        new int[] { 6, 10, 15 },
        Resources.Load<Sprite>("Characters/MainCharacters/4"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Blue_A1"),
                DiceData.GetDiceDataModel("Green_A1"),
                DiceData.GetDiceDataModel("Red_A1"),


            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Blue_A2"),
                DiceData.GetDiceDataModel("Green_A2"),
                DiceData.GetDiceDataModel("Red_A1"),


            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Green_A2"),
                DiceData.GetDiceDataModel("Blue_A2"),
                DiceData.GetDiceDataModel("Blue_A1"),
                DiceData.GetDiceDataModel("Red_A1"),


            }
        }
        );

    private static CharacterData MainCharacter_5 = new CharacterData(
        5,
        "格林卡",
        true,
        3,
        new int[] { 10, 15, 20 },
        Resources.Load<Sprite>("Characters/MainCharacters/5"),
        new List<DiceData>[]
        {
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Red_A1"),
                    DiceData.GetDiceDataModel("Green_A1"),
                    DiceData.GetDiceDataModel("Enemy_Bomb1")

                },
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Red_A2"),
                    DiceData.GetDiceDataModel("Green_A1"),
                    DiceData.GetDiceDataModel("Enemy_Bomb1")

                },
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Red_A2"),
                    DiceData.GetDiceDataModel("Green_A2"),
                    DiceData.GetDiceDataModel("Enemy_Bomb1")
                }
        }
    );


    private static CharacterData MainCharacter_11 = new CharacterData(
        11,
        "小弟",
        true,
        3,
        new int[] { 6, 10, 15 },
        Resources.Load<Sprite>("Characters/Enemies/151"),
        new List<DiceData>[]
        {
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Red_A1"),
                    DiceData.GetDiceDataModel("Green_A1"),

                },
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Red_A2"),
                    //DiceData.GetDiceDataModel("Enemy_Pistol1"),
                    DiceData.GetDiceDataModel("Green_A1"),

                },
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Red_A2"),
                    //DiceData.GetDiceDataModel("Red_A1"),
                    DiceData.GetDiceDataModel("Green_A2"),

                }
        }


    );

    private static CharacterData MainCharacter_12 = new CharacterData(
        12,
        "公司职员",
        true,
        3,
        new int[] { 6, 10, 15 },
        Resources.Load<Sprite>("Characters/Enemies/141"),
        new List<DiceData>[]
        {
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Blue_C2"),
                    DiceData.GetDiceDataModel("Green_A1"),

                },
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Blue_C2"),
                    DiceData.GetDiceDataModel("Blue_A1"),
                    DiceData.GetDiceDataModel("Green_A1"),

                },
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Blue_C2"),
                    DiceData.GetDiceDataModel("Blue_A2"),
                    DiceData.GetDiceDataModel("Green_A1"),

                }
        }


    );

    /*
    private static CharacterData MainCharacter_13 = new CharacterData(
        13,
        "流浪汉",
        true,
        3,
        new int[] { 6, 10, 15 },
        Resources.Load<Sprite>("Characters/Enemies/151"),
        new List<DiceData>[]
        {
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Red_A2"),
                    //DiceData.GetDiceDataModel("Green_A2"),

                },
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Red_A2"),
                    //DiceData.GetDiceDataModel("Green_A2"),
                    DiceData.GetDiceDataModel("Red_A1"),

                },
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Red_A2"),
                    DiceData.GetDiceDataModel("Red_A2"),
                    //DiceData.GetDiceDataModel("Green_A2"),
                    //DiceData.GetDiceDataModel("Green_A1"),

                }
        }


    );*/

    private static CharacterData Enemy_1 = new CharacterData(
        101,
        "小混混",
        true,
        3,
        new int[] { 6, 9, 15 },
        Resources.Load<Sprite>("Characters/Enemies/1"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Punch1")

            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Punch2")


            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Punch3"),
                DiceData.GetDiceDataModel("Enemy_Punch1")


            }
        }


        );

    private static CharacterData Enemy_2 = new CharacterData(
        102,
        "小混混",
        false,
        3,
        new int[] { 6, 9, 15 },
        Resources.Load<Sprite>("Characters/Enemies/2"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Pistol1")

            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Pistol1"),
                DiceData.GetDiceDataModel("Enemy_Pistol1")


            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
                DiceData.GetDiceDataModel("Enemy_Pistol1")


            }
        }


        );


    private static CharacterData Enemy_3 = new CharacterData(
        103,
        "教徒",
        false,
        3,
        new int[] { 9, 12, 18 },
        Resources.Load<Sprite>("Characters/Enemies/3"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
                DiceData.GetDiceDataModel("Enemy_Shotgun1"),
                DiceData.GetDiceDataModel("Enemy_Shield1"),


            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
                DiceData.GetDiceDataModel("Enemy_Shotgun2"),
                DiceData.GetDiceDataModel("Enemy_Shield1"),

            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Rifle2"),
                DiceData.GetDiceDataModel("Enemy_Shotgun2"),
                //DiceData.GetDiceDataModel("Enemy_Shotgun1"),
                DiceData.GetDiceDataModel("Enemy_Shield2"),

            }
        }


    );

    private static CharacterData Enemy_4 = new CharacterData(
        104,
        "神秘男子",
        true,
        1,
        new int[] { 20 },
        Resources.Load<Sprite>("Characters/Enemies/13"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Rifle2"),
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
                DiceData.GetDiceDataModel("Enemy_Shield2"),
                DiceData.GetDiceDataModel("Enemy_Shield2"),
            }
        }


    );

    private static CharacterData Enemy_5 = new CharacterData(
        105,
        "流浪汉",
        true,
        3,
        new int[] { 6, 10,15 },
        Resources.Load<Sprite>("Characters/Enemies/142"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Red_A2"),
            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Green_A1"),
                DiceData.GetDiceDataModel("Red_A2"),
            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Green_A1"),
                DiceData.GetDiceDataModel("Red_A2"),
                DiceData.GetDiceDataModel("Red_A1"),
            }
        }


    );

    private static CharacterData Enemy_6 = new CharacterData(
        106,
        "政府调查员",
        false,
        3,
        new int[] { 9,12,15 },
        Resources.Load<Sprite>("Characters/Enemies/12"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
                DiceData.GetDiceDataModel("Enemy_Shield1"),
            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
                DiceData.GetDiceDataModel("Enemy_Shield3"),
            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
                DiceData.GetDiceDataModel("Enemy_Pistol1"),
                DiceData.GetDiceDataModel("Enemy_Shield4"),
            }
        }


    );

    private static CharacterData Enemy_51 = new CharacterData(
        151,
        "年轻枪手",
        true,
        3,
        new int[] { 6, 9, 15 },
        Resources.Load<Sprite>("Characters/Enemies/153"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Blue_A1"),
                DiceData.GetDiceDataModel("Enemy_Pistol1"),
            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Blue_A1"),
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Blue_A2"),
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
                DiceData.GetDiceDataModel("Enemy_Pistol1"),
            }
        }


        );

    private static CharacterData Enemy_52 = new CharacterData(
        152,
        "重装干员",
        true,
        3,
        new int[] { 15, 20, 25 },
        Resources.Load<Sprite>("Characters/Enemies/152"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Shield2"),
                DiceData.GetDiceDataModel("Enemy_Shield1"),
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Shield3"),
                DiceData.GetDiceDataModel("Enemy_Shield2"),
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Shield4"),
                DiceData.GetDiceDataModel("Enemy_Shield3"),
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
                DiceData.GetDiceDataModel("Enemy_Pistol1"),
            }
        }


        );

    private static CharacterData Enemy_54 = new CharacterData(
        154,
        "疯狂科学家",
        true,
        3,
        new int[] { 9, 12, 15 },
        Resources.Load<Sprite>("Characters/Enemies/154"),
        new List<DiceData>[]
        {
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Enemy_Bomb2"),
                    //DiceData.GetDiceDataModel("Enemy_Bomb1"),
                },
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Enemy_Pistol1"),
                    DiceData.GetDiceDataModel("Enemy_Bomb2"),
                },
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Enemy_Pistol1"),
                    DiceData.GetDiceDataModel("Enemy_Bomb2"),
                }
        }


    );

    private static CharacterData Enemy_55 = new CharacterData(
        155,
        "持棍武警",
        true,
        3,
        new int[] { 9, 15, 20 },
        Resources.Load<Sprite>("Characters/Enemies/155"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
                DiceData.GetDiceDataModel("Enemy_Shield1"),
            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
                DiceData.GetDiceDataModel("Enemy_Pistol1"),
                DiceData.GetDiceDataModel("Enemy_Shield2"),
            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
                DiceData.GetDiceDataModel("Enemy_Pistol1"),
                DiceData.GetDiceDataModel("Enemy_Shield3"),
                DiceData.GetDiceDataModel("Enemy_Shield1"),
            }
        }


        );

    private static CharacterData Enemy_56 = new CharacterData(
        156,
        "持枪武警",
        true,
        3,
        new int[] { 9, 15, 20 },
        Resources.Load<Sprite>("Characters/Enemies/156"),
        new List<DiceData>[]
        {
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Enemy_Rifle2"),
                    DiceData.GetDiceDataModel("Enemy_Rifle1"),
                },
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Enemy_Rifle2"),
                    DiceData.GetDiceDataModel("Enemy_Rifle1"),
                    DiceData.GetDiceDataModel("Enemy_Shield1"),
                },
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Enemy_Rifle2"),
                    DiceData.GetDiceDataModel("Enemy_Rifle2"),
                    DiceData.GetDiceDataModel("Enemy_Shield2"),
                    //DiceData.GetDiceDataModel("Enemy_Shield1"),
                }
        }


    );

    private static CharacterData Enemy_57 = new CharacterData(
        157,
        "少年",
        true,
        3,
        new int[] { 6, 10, 15 },
        Resources.Load<Sprite>("Characters/Enemies/157"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Blue_A1"),
                DiceData.GetDiceDataModel("Enemy_Punch1"),
            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Blue_A2"),
                DiceData.GetDiceDataModel("Enemy_Punch1"),
            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Blue_A2"),
                DiceData.GetDiceDataModel("Red_A1"),
                DiceData.GetDiceDataModel("Enemy_Punch1"),
            }
        }


        );


    private static CharacterData Enemy_58 = new CharacterData(
        158,
        "神秘男子",
        true,
        1,
        new int[] { 20  },
        Resources.Load<Sprite>("Characters/Enemies/13"),
        new List<DiceData>[]
        {
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Enemy_Shotgun2"),
                    DiceData.GetDiceDataModel("Enemy_Shotgun1"),
                    DiceData.GetDiceDataModel("Enemy_Shield4"),
                    DiceData.GetDiceDataModel("Enemy_Shield1"),

                }
        }


    );

    private static CharacterData UAV_1 = new CharacterData(
        161,
        "侦察无人机",
        true,
        1,
        new int[] { 6 },
        Resources.Load<Sprite>("Characters/Enemies/161"),
        new List<DiceData>[]
        {
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Enemy_Pistol1"),
                    DiceData.GetDiceDataModel("Blue_B2"),


                }
        }


    );

    private static CharacterData UAV_2 = new CharacterData(
        162,
        "轰炸无人机",
        true,
        1,
        new int[] { 6 },
        Resources.Load<Sprite>("Characters/Enemies/162"),
        new List<DiceData>[]
        {
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Enemy_Pistol1"),
                    DiceData.GetDiceDataModel("Enemy_Bomb1"),
                    
                }
        }


    );

    private static CharacterData Robot_1 = new CharacterData(
        163,
        "智能炮塔",
        true,
        3,
        new int[] { 9,15,20 },
        Resources.Load<Sprite>("Characters/Enemies/163"),
        new List<DiceData>[]
        {
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Enemy_Shotgun1"),
                    DiceData.GetDiceDataModel("Enemy_Shield2"),


                },
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Enemy_Shotgun2"),
                    DiceData.GetDiceDataModel("Enemy_Shield1"),
                    DiceData.GetDiceDataModel("Enemy_Shield1"),

                },
                new List<DiceData>(){
                    DiceData.GetDiceDataModel("Enemy_Shotgun2"),
                    DiceData.GetDiceDataModel("Enemy_Shotgun1"),
                    DiceData.GetDiceDataModel("Enemy_Shield3"),
                    DiceData.GetDiceDataModel("Enemy_Shield1"),

                }
        }


    );

    private static CharacterData Boss_1 = new CharacterData(
        1001,
        "帮会头目",
        true,
        1,
        new int[] { 18 },
        Resources.Load<Sprite>("Characters/Enemies/1002"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Shotgun1"),
                DiceData.GetDiceDataModel("Enemy_Rifle2"),
                DiceData.GetDiceDataModel("Enemy_Shield1"),
                DiceData.GetDiceDataModel("Enemy_Shield1"),



            }
        }


    );

    private static CharacterData Boss_2 = new CharacterData(
        1002,
        "恶棍警长",
        true,
        1,
        new int[] { 25 },
        Resources.Load<Sprite>("Characters/Enemies/1003"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Shotgun2"),
                DiceData.GetDiceDataModel("Enemy_Rifle2"),
                DiceData.GetDiceDataModel("Enemy_Shield1"),
                DiceData.GetDiceDataModel("Enemy_Shield1"),

            }
        }


    );

    private static Dictionary<int, CharacterData> characterDictionary = new Dictionary<int, CharacterData>() {

        { 1, MainCharacter_1 },
        { 2, MainCharacter_2 },
        { 3, MainCharacter_3 },
        { 4, MainCharacter_4 },
        { 5, MainCharacter_5 },

        { 11, MainCharacter_11},
        { 12, MainCharacter_12},
        //{ 13, MainCharacter_13},

        { 101, Enemy_1},
        { 102, Enemy_2 },{ 103, Enemy_3 },
        { 104, Enemy_4 },
        { 105, Enemy_5 },{ 106, Enemy_6 },


        { 151, Enemy_51},
        { 152, Enemy_52},
        
        { 154, Enemy_54},
        { 155, Enemy_55},
        { 156, Enemy_56},
        { 157, Enemy_57},
        { 158, Enemy_58},

        { 161, UAV_1},
        { 162, UAV_2},
        { 163, Robot_1},

        { 1001, Boss_1},{ 1002, Boss_2}

    };

    public static CharacterData GetCharacterData(int index)
    {
        if (characterDictionary.ContainsKey(index))
        {
            return characterDictionary[index].Model();
        }
        else
        {
            return MainCharacter_1.Model();
        }
    }

    public static CharacterData GetCharacterData(int index, int level)
    {
        CharacterData cd = GetCharacterData(index);
        cd.SetLevel(level);
        return cd;
    }

}
