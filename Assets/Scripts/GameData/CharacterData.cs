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
public class CharacterData
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

    public CharacterData Model()
    {
        return MemberwiseClone() as CharacterData;

        //return Utils.DeepCopyByReflect(this);
        //深度拷贝代码有问题，先凑合着用
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


    //*********************************数据库

    public static CharacterData MainCharacter_1 = new CharacterData(
    1,
    "主角团1",
    true,
    3,
    new int[] { 40, 50, 60 },
    Resources.Load<Sprite>("Characters/MainCharacters/1"),
    new List<DiceData>[]
    {
            new List<DiceData>(){
                DiceData.DiceData_TestOne

            },
            new List<DiceData>(){
                DiceData.DiceData_TestOne,
                DiceData.DiceData_TestTwo

            },
            new List<DiceData>(){
                DiceData.DiceData_TestOne,
                DiceData.DiceData_TestTwo

            }
    }


    );

    public static CharacterData MainCharacter_2 = new CharacterData(
        2,
        "主角团2",
        true,
        3,
        new int[] {10,20,30},
        Resources.Load<Sprite>("Characters/MainCharacters/2"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.DiceData_TestOne

            },
            new List<DiceData>(){
                DiceData.DiceData_TestOne,
                DiceData.DiceData_TestTwo

            },
            new List<DiceData>(){
                DiceData.DiceData_TestOne,
                DiceData.DiceData_TestTwo

            }
        }
        
        
        );

    public static CharacterData MainCharacter_3 = new CharacterData(
        3,
        "主角团3",
        false,
        3,
        new int[] { 20, 30, 40 },
        Resources.Load<Sprite>("Characters/MainCharacters/3"),
        new List<DiceData>[]
        {
            new List<DiceData>(){
                DiceData.DiceData_TestTwo

            },
            new List<DiceData>(){
                DiceData.DiceData_TestTwo,
                DiceData.DiceData_TestTwo

            },
            new List<DiceData>(){
                DiceData.DiceData_TestTwo,
                DiceData.DiceData_TestTwo,
                DiceData.DiceData_TestTwo

            }
        }


        );

}
