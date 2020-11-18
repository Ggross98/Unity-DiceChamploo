using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

public class Utils
{
    public static string FormatTime(float seconds)
    {
        TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(seconds));
        string str = "";

        if (ts.Hours > 0)
        {
            str = ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
        }
        if (ts.Hours == 0 && ts.Minutes > 0)
        {
            str = ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
        }
        if (ts.Hours == 0 && ts.Minutes == 0)
        {
            str = "00:" + ts.Seconds.ToString("00");
        }

        return str;
    }


    public static Object DeepClone(Object obj) //深clone
    {
        MemoryStream stream = new MemoryStream();
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, obj);
        stream.Position = 0;
        return formatter.Deserialize(stream) as Object;
    }

     public static T DeepCopy<T>(T obj)
      {
          object retval;
          using (MemoryStream ms = new MemoryStream())
          {
             BinaryFormatter bf = new BinaryFormatter();
              //序列化成流
              bf.Serialize(ms, obj);
              ms.Seek(0, SeekOrigin.Begin);
             //反序列化成对象
             retval = bf.Deserialize(ms);
             ms.Close();
         }
         return (T) retval;
     }


    public static void SortDiceFaceDataList(List<DiceFaceData> list, bool ascending)
    {
        for (int i = 0; i < list.Count-1; i++)
        {
            for(int j = i; j < list.Count-1; j++)
            {
                if((list[j].index < list[j+1].index && !ascending)|| (list[j].index > list[j + 1].index && ascending))
                {
                    DiceFaceData temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
    }
    
    public static string GetComboEffectString(ComboEffect effect)
    {
        string str = "";

        switch (effect.type)
        {
            case ComboEffect.EffectType.Damage:

                if (!effect.toEnemy) str += "对己方";
                str += "造成" + effect.value + "伤害。";
                if (effect.isAreaEffect) str += "群体攻击。";

                break;

            case ComboEffect.EffectType.Shield:

                str += "获得" + effect.value + "护盾。";
                break;
        }

        return str;
    }
}
