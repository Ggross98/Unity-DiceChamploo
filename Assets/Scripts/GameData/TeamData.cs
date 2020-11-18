using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 队伍的数据。可用于敌人和我方
/// </summary>
public class TeamData: IModel<TeamData>
{

    public List<CharacterData> characters;

    public TeamData()
    {
        characters = new List<CharacterData>();
    }

    public TeamData(List<CharacterData> c)
    {
        characters = c;
    }

    public int Count()
    {
        return characters.Count;
    }

    public List<CharacterData> GetAliveCharacters()
    {
        List<CharacterData> list = new List<CharacterData>();

        for(int i = 0; i < characters.Count; i++)
        {
            if (characters[i].IsAlive()) list.Add(characters[i]);
        }

        return list;
    }

    public void Dismiss(CharacterData cd)
    {
        if (characters.Contains(cd))
        {
            characters.Remove(cd);
        }
    }

    public void Recruit(CharacterData cd)
    {
        characters.Add(cd);
    }
    
    public TeamData Model()
    {
        TeamData td = new TeamData();

        td.characters = new List<CharacterData>();
        for(int i = 0; i < this.characters.Count; i++)
        {
            td.characters.Add(this.characters[i].Model());
        }

        return td;
    }


}
