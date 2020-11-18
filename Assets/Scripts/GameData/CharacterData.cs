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
            level++;
            maxHp = maxHpBank[level-1];
            dices = dicesBank[level - 1];

            //升级时血量回满
            hp = maxHp;

        }
    }

    public int UpgradeCost()
    {
        return level * 5;
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
    new int[] { 20, 25, 30 },
    Resources.Load<Sprite>("Characters/MainCharacters/1"),
    new List<DiceData>[]
    {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Red_A2"),
                DiceData.GetDiceDataModel("Red_A2"),

            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Red_A2"),
                DiceData.GetDiceDataModel("Red_A2"),
                DiceData.GetDiceDataModel("Green_A1")


            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Red_A2"),
                DiceData.GetDiceDataModel("Red_A2"),
                DiceData.GetDiceDataModel("Red_A1"),
                DiceData.GetDiceDataModel("Green_A2")


            }
    }


    );

    private static CharacterData MainCharacter_2 = new CharacterData(
        2,
        "加文",
        true,
        3,
        new int[] {10,15,20},
        Resources.Load<Sprite>("Characters/MainCharacters/2"),
        new List<DiceData>[]
    {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Blue_A2"),

                DiceData.GetDiceDataModel("Blue_A2")


            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Blue_A2"),
                DiceData.GetDiceDataModel("Blue_A2"),

                DiceData.GetDiceDataModel("Blue_A2")


            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Blue_A2"),
                DiceData.GetDiceDataModel("Blue_A2"),
                DiceData.GetDiceDataModel("Blue_A2"),
    
                DiceData.GetDiceDataModel("Blue_A1")


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
                DiceData.GetDiceDataModel("Green_A2"),
                
            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Green_A2"),
                DiceData.GetDiceDataModel("Green_A2"),

                DiceData.GetDiceDataModel("Green_A2")


            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Green_A2"),
                DiceData.GetDiceDataModel("Green_A2"),
                DiceData.GetDiceDataModel("Green_A2"),

                DiceData.GetDiceDataModel("Green_A1")


            }
        }


        );

    private static CharacterData MainCharacter_4 = new CharacterData(
        4,
        "玛雅",
        false,
        3,
        new int[] { 10, 15, 20 },
        Resources.Load<Sprite>("Characters/MainCharacters/4"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Green_A1")

            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Green_A1"),
                DiceData.GetDiceDataModel("Blue_A1"),


            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Green_A1"),
                DiceData.GetDiceDataModel("Blue_A1"),
                DiceData.GetDiceDataModel("Red_A1"),


            }
        }


        );

    private static CharacterData Enemy_1 = new CharacterData(
        101,
        "小混混",
        true,
        3,
        new int[] { 5, 10, 20 },
        Resources.Load<Sprite>("Characters/Enemies/1"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Punch1")

            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Punch1")


            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Punch1"),
                DiceData.GetDiceDataModel("Enemy_Punch1")


            }
        }


        );

    private static CharacterData Enemy_2 = new CharacterData(
        102,
        "小混混",
        false,
        3,
        new int[] { 5, 10, 20 },
        Resources.Load<Sprite>("Characters/Enemies/2"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Pistol1")

            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Pistol2")


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
            new int[] { 25, 30, 30 },
            Resources.Load<Sprite>("Characters/Enemies/3"),
            new List<DiceData>[]
            {
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
                DiceData.GetDiceDataModel("Enemy_Punch1"),


            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Pistol2")


            },
            new List<DiceData>(){
                DiceData.GetDiceDataModel("Enemy_Pistol2"),
                DiceData.GetDiceDataModel("Enemy_Pistol1")


            }
            }


    );

    private static Dictionary<int, CharacterData> characterDictionary = new Dictionary<int, CharacterData>() {

        { 1, MainCharacter_1 },
        { 2, MainCharacter_2 },
        { 3, MainCharacter_3 },

        { 4, MainCharacter_4 },

        { 101, Enemy_1},

        { 102, Enemy_2 },

        { 103, Enemy_3}



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

}
