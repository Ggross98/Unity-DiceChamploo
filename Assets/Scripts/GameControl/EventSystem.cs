using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OptionResult { NoJump, FailJump, SuccessJump, Battle, Ending };//关于选项跳转的结果

public class EventSystem: MonoBehaviour
{
    //List<EventData> datas;
    EventData data;

    bool[] isFinish;

    //int currentEvent;
    int currentMovement;
    int nextMovement;
  

    public void LoadEventData(EventData data)
    {
        this.data = data;
    }

    public int OptionCount()
    {
        return data.movements[currentMovement].OptionCount();
    }

    public bool NeedDices(int optionIndex)
    {

        return data.movements[currentMovement].NeedDices(optionIndex);
    }

    /// <summary>
    /// 判断一个选项的结果
    /// </summary>
    /// <param name="optionNumber">选择选项的编号</param>
    /// <param name="dice">投出的骰子列表</param>
    /// <returns></returns>
    public OptionResult CheckOption(int optionNumber, List<DiceFaceData> dice= null)//完成对用户选择的Option的check和结算的工作
    {
        OptionResult result = data.movements[currentMovement].CheckOption(optionNumber, dice);

        if(result == OptionResult.FailJump)
        {
            nextMovement = data.movements[currentMovement].options[optionNumber].nextIndex[1];
        }
        else if(result == OptionResult.SuccessJump)
        {
            nextMovement = data.movements[currentMovement].options[optionNumber].nextIndex[0];
        }

        return result;
    }

    /// <summary>
    /// 事件结算的方法
    /// </summary>
    public void Settlement()
    {
        
        List<EventReward> rewards = data.movements[currentMovement].rewards;

        if (rewards != null && rewards.Count > 0)
        {
            foreach (var r in rewards)
            {
                switch (r.type)
                {
                    case EventReward.Type.Gold:

                        GameController.Instance.GainGold(r.value);
                        break;

                    case EventReward.Type.SkillPoint:
                        GameController.Instance.GainSkillPoint(r.value);
                        break;

                    case EventReward.Type.Teammate:
                        GameController.Instance.RecruitCharacter(CharacterData.GetCharacterData(r.value));
                        break;


                    case EventReward.Type.RandomMainCharacter:
                        GameController.Instance.RecruitRandomMainCharacter();
                        break;

                    case EventReward.Type.Heal:
                        var characters = GameController.Instance.gameData.playerTeamData.characters;

                        if (r.valueType == 1)
                        {
                            foreach (CharacterData cd in characters)
                            {
                                cd.ChangeHP(r.value);
                            }
                        }
                        else if (r.valueType == 0)
                        {
                            CharacterData min = characters[0];
                            for (int i = 1; i < characters.Count; i++)
                            {
                                if (characters[i].hp < min.hp) min = characters[i];
                            }
                            min.ChangeHP(r.value);
                        }
                        break;

                    case EventReward.Type.Damage:
                        var characters1 = GameController.Instance.gameData.playerTeamData.characters;
                        foreach(CharacterData cd in characters1)
                        {
                            cd.Damage(r.value);
                        }
                        break;
                }
            }
        }
        

    }

    public BattleData GetNextBattle()
    {
        return data.movements[currentMovement].GetBattleData();
    }


    /*public bool SwitchCurrentEvent(int index)//切换当前Event,加载新的Event，Event不重复出现
    {
        if (isFinish[index])
        {
            //Unity.Debug.log("跳转错误");
            return false;
        }

        isFinish[index] = true;
        currentEvent = index;
        currentMovement = 0;
        nextMovement = 0;
        return true;
    }*/

    public bool SwitchCurrentMovement()//切换当前的Movement，加载新的Movement
    {
        if (currentMovement == nextMovement)
        {
            //Debug.log("跳转错误");
            return false;
        }

        //Debug.Log("current movement: " + currentMovement + "\tnext : " + nextMovement);

        currentMovement = nextMovement;
        return true;
    }

    //返回当前Event的描述
    public string GetEventDiscription() { return data.description; }

    //返回当前Movement的描述
    public string GetMovementDiscription() {
        string des = data.movements[currentMovement].FullDescription();
        if(des.Contains(" "))
        {
            des = des.Replace(" ", "\u00A0");
        }
        return des;
    }
    
    //返回选项本身的描述
    public string[] GetOptionDiscription() { return data.movements[currentMovement].GetOptionDiscription(); }

    //返回选项判定条件的描述
    public string[] GetConditionDiscription() { return data.movements[currentMovement].GetConditionDiscription(); }
    
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
