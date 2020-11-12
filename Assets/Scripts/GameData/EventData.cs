using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public enum OptionResult { NoJump, FailJump, SuccessJump, Battle, Ending };//关于选项跳转的结果

//公共接口类，生命周期应该贯穿一局游戏
public class EventSystem
{
    List<EventData> eventDatas;
    bool[] isFinish;

    int currentEvent;
    int currentMovement;
    int nextMovement;

    EventSystem(int n = 3)//初始化指定本局非战斗事件的个数
    {
        isFinish = new bool[n];
        for(bool i: isFinish)
        {
            i = false;
        }

        eventDatas = new List<EventData>{ EventData.Event0, EventData.Event1, EventData.Event2};
        currentEvent = currentMovement = nextMovement = 0;
    }

    public OptionResult CheckOption(int optionNumber, List<DiceFaceData> dice= null)//完成对用户选择的Option的check和结算的工作
    {
        OptionResult result = eventDatas[currentEvent].movements[currentMovement].checkOption(optionNumber, dice);

        if(result == OptionResult.FailJump)
        {
            nextMovement = eventDatas[currentEvent].movements[currentMovement].options[optionNumber].nextIndex[1];
        }
        else if(result == OptionResult.SuccessJump)
        {
            nextMovement = eventDatas[currentEvent].movements[currentMovement].options[optionNumber].nextIndex[0];
        }

        return result;
    }
    
    public bool SwitchCurrentEvent(int index)//切换当前Event,加载新的Event，Event不重复出现
    {
        if (isFinish[index])
        {
            Debug.log("跳转错误");
            return false;
        }

        isFinish[index] = true;
        currentEvent = index;
        currentMovement = 0;
        nextMovement = 0;
        return true;
    }

    public bool SwitchCurrentMovement()//切换当前的Movement，加载新的Movement
    {
        if (currentMovement == nextMovement)
        {
            Debug.log("跳转错误");
            return false;
        }

        currentMovement = nextMovement;
        return true;
    }

    //返回当前Event的描述
    public string GetEventDiscription() { return eventDatas[currentEvent].description; }

    //返回当前Movement的描述
    public string GetMovementDiscription() { return eventDatas[currentEvent].movements[currentMovement].description; }
    
    //返回选项本身的描述
    public string[] GetOptionDiscription() { return eventDatas[currentEvent].movements[currentMovement].getOptionDiscription(); }

    //返回选项判定条件的描述
    public string[] GetConditionDiscription() { return eventDatas[currentEvent].movements[currentMovement].getConditionDiscription(); }
    
}

//系统内部实现，对外隐藏
class EventData
{
    internal string description;
    //Sprite icon;

    List<Movement> movements;

    public EventData(string d, List<Movement> m)
    {
        description = d;
        movements = m;
    }
    //public string getEventDiscription() { return description; }

    //返回当前场景描述
    // public string getMovementDiscription() { return movements[currentMovement].description; }

    //返回场景所有选项的描述
    //public string[] getOptionDiscrioption() { return movements[currentMovement].getOptionDiscription(); }
    /*
    public OptionResult CheckOption(int index, )
    {
        if (movements[currentMovement].isEnding)
            return Ending;
    }

    void Jump(int optionIndex, int result)
    {

        currentMovement = currentMovement.options[optionIndex].nextIndex[result];

    }*/
    //***********************数据库**************************
    public static Event0 = new EventData(
        "遭遇劫匪",
        new List<Movement>(){
            Movement.m0_0,
            Movement.m0_1,
            Movement.m0_2
        });

    public static Event1 = new EventData(
        "遭遇黑帮Ⅰ",
        new List<Movement> { 
            Movement.m1_0,
            Movement.m1_1,
            Movement.m1_2,
            Movement.m1_3,
            Movement.m1_4
        });

    public static Event2 = new EventData(
        "遭遇黑帮 Ⅱ",
        new List<Movement>
        {
            Movement.m2_0,
            Movement.m2_1,
            Movement.m2_2
        });
}

class Movement
{
    internal string description;

    internal bool isEnding;
    internal bool isBattle;

    internal List<Option> options;

    Movement(string _description, bool _isBattle = false)//结局场景
    {
        isEnding = true;
        isBattle = _isBattle;
        description = _description;
        options.Add(Option.finalOption);
    }

    Movement(string _description, List<Option> _options)//一般场景
    {
        isEnding = false;
        description = _description;
        options = _options;
    }
    
    //internal IsEnding() { return isEnding; }
    OptionResult CheckOption(int index, List<DiceFaceData> dices)
    {
        if (isEnding)
        {
            if (isBattle)
                return OptionResult.Battle;
            else
                return OptionResult.Ending;
        }

        if (options[index].CheckOption(dices)) 
        {
            return OptionResult.SuccessJump; 
        }

        if (options[index].nextIndex.Length == 2)
            return OptionResult.FailJump;
        
        return OptionResult.NoJump;
    }

    
    internal string[] getOptionDiscription()
    {
        string[] result = new string[options.Count];
        for(int i = 0; i<options.Count; ++i)
        {
            result[i] = options[i].description;
        }
        return result;
    }

    internal string[] getConditionDiscription()
    {
        string[] result = new string[options.Count];
        for (int i = 0; i < options.Count; ++i)
        {
            result[i] = options[i].condition.ToString();
        }
        return result;
    }
    //***********************************数据库**************************
    public static Movement m0_1 = new Movement(@"你经过一条小巷时，一个手持匕首、满脸凶相的男人向你走来。
                “这位小兄弟，老子最近手头有点紧，借点钱花花呗？”他朝你喊道。
                ", new List<Option>
                { Option.option0_0_0,
                Option.option0_0_1,
                Option.option0_0_2}
                );

    public static Movement m0_2 = new Movement("男人数了数钱，满意地离开了。他很快消失在了夜色之中");

    public static Movement m0_3 = new Movement("“这是你自找的！”男人冲向了你。", true);

    public static Movement m1_0 = new Movement(@"几个持刀的混混围住了一位女性。
                你认出，这些混混是“巨齿鲨”帮会的成员！
                “求求你们，我还有孩子啊！”
                女性求饶道，但几个混混不为所动，狞笑着向她走去……		",
                new List<Option>
                {
                    Option.option1_0_0,
                    Option.option1_0_1
                });

    public static Movement m1_1 = new Movement(@"你觉得不要装英雄，悄悄离开了。走出一段距离后，你听到身后传来女性的惨叫声……");

    public static Movement m1_2 = new Movement(@"混混们注意到了你。
                “你是什么人？想活命的话就快滚，别坏了兄弟们的兴致！”
                为首的男人朝你挥了挥手中的匕首。",
                new List<Option>
                {
                    Option.option1_2_0,
                    Option.option1_2_1,
                    Option.option1_2_2
                });

    public static Movement m1_3 = new Movement(@"男人似乎被你坚定的语气，抑或是你手中的武器唬住了。
                他一挥手，混混们不情愿地离开了现场。
                那个女人小声向你们道了谢，匆匆逃离了这条小巷。");

    public static Movement m1_4 = new Movement(@"那群混混纷纷掏出武器，把你团团围住！", true);

    public static Movement m2_0 = new Movement(@"你走在一条小路中，突然一群混混从四个方向把你团团围住。
                你认出，这些混混是“巨齿鲨”帮会的成员！
                他们宣称要替“老大”给你一个教训……",
                new List<Option>
                {
                    Option.option2_0_0,
                    Option.option2_0_1
                });

    public static Movement m2_1 = new Movement("你灵活的闪转腾挪，躲过混混们的棍棒，转眼间逃离了现场。");

    public static Movement m2_2 = new Movement("那群混混大吼一声便冲了过来。", true);
}

//enum Operation { none, Gold, SkillPoint, Battle };
//enum JudgeCondition { no, Dice, Gold };
class Option
{
    internal string description;
    internal int[] nextIndex;

    internal Operation operation;
    internal Condition condition;

    public Option()
    {
        description = "确定";
        operation = new Operation();
        condition = new Condition();
        nextIndex = null;
    }

    public Option(string d, int[] n = null, Condition c = new Condition(), Operation o = new Operation())
    {
        description = d;
        nextIndex = n;
        operation = o;
        condition = c;
    }

    
    public virtual bool CheckOption(List<DiceFaceData> dices)//检查选项是否满足条件，结算并返回是否跳转
    {
        if (condition.CheckCondition(dices))
        {
            operation.ExecuteOperation();
            return true;
        }
        return false;
    }

    //********************************数据库***************   
    public static const Option finalOption = new Option();

    public static const Option option0_0_0 = new Option(
        "乖乖交钱",
        new int[] {1},
        new GoldCondition(50),
        new GoldOperation(50)
    );

    public static const Option option0_0_1 = new Option(
        "说服放行",
        new int[] { 2, 3 },
        new DiceColorCondition(0, 0, 2)
    );

    public static const Option option0_0_2 = new Option(
        "给他一拳",
        new int[] { 2, 3 },
        new DiceColorCondition(1, 0, 0)
    );

    public static const Option option1_0_0 = new Option(
        "装没看见",
        new int[] { 1 }
    );

    public static const Option option1_0_1 = new Option(
        "挺身而出",
        new int[] { 2 }
    );

    public static const Option option1_2_0 = new Option(
        "威胁",
        new int[] { 3, 4 },
        new DiceColorCondition(1,0,2)
    );
    
    public static const Option option1_2_1 = new Option(
        "战斗！",
        new int[] { 4 },
    );

    public static const Option option1_2_2 = new Option(
        "转身离开",
        new int[] { 1 },
    );    

    public static const Option option2_0_0 = new Option(
        "走为上计",
        new int[] { 1, 2},
        new DiceColorCondition(0,1,1)
    );

    public static const Option option2_0_1 = new Option(
        "战斗！",
        new int[] { 2 },
    );

    public 

}

//判定类
class Condition
{
    public Condition() { }

    public virtual bool CheckCondition(List<DiceFaceData> dices) { return true; }

    public override string ToString()
    {
        return "";
    }
}

class GoldCondition:Condition
{
    int value;

    public GoldCondition(int val)
    {
        value = val;
    }

    public override bool CheckCondition(List<DiceFaceData> dices)
    {
        return GameController.Instance.gameData.Gold <= value;
    }

    public override string ToString()
    {
        return "花费金钱: " + value.ToString();
    }
}

class DiceColorCondition:Condition
{
    int Red;
    int Blue;
    int Green;
    DiceColorCondition(int r, int g, int b)
    {
        Red = r;
        Green = g;
        Blue = b;
    }
    public override bool CheckCondition(List<DiceFaceData> dices)
    {
        int countR = 0, countG = 0, countB = 0;
        for(var dice: dices)
        {
            if(dice.type = DiceFaceData.Type.Red)
            {
                countR++;
            }
            else if(dice.type = DiceFaceData.Type.Blue)
            {
                countB++;
            }
            else if(dice.type = DiceFaceData.Type.Green)
            {
                countG++;
            }
        }

        return Red <= countR && Blue <= countB && Green <= countG;
    }

    public override string ToString()
    {
        string result = "投掷: ";
        string prefix = "";

        if (Red)
        {
            result += "红色x" + Red.ToString();
            prefix = ", ";
        }

        if (Green)
        {
            result += prefix + "绿色x" + Green.ToString();
            prefix = ", ";
        }

        if (Blue)
        {
            result += prefix + "蓝色x" + Blue.ToString();
        }

        return result;
    }
}

//操作类
class Operation
{
    public Operation() { }
    public virtual void ExecuteOperation()
    {}
}

//金钱操作，可加可减
class GoldOperation(): Operation
{
    int value;
    public GoldOperation(int val)
    {
        value = val;
    }

    public override void ExecuteOperation()
    {
        GameController.Instance.gameData.Gold -= value ;
    }
}


/*
class NoneOption: Option
{
    public NoneOption():base()
    { }
    public bool CheckOption() { return true; }
}

class GoldOption: Option
{
    int GoldValue;
    public GoldOption(int v) : base()
    {
        if (GameController.Instance.gameData.Gold > GoldValue) 
            return false;

    }
}
*/
