using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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

    /// <summary>
    /// 使用xml序列号进行深度拷贝
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T DeepCopyByXml<T>(T obj)
    {
        object retval;
        using (MemoryStream ms = new MemoryStream())
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            xml.Serialize(ms, obj);
            ms.Seek(0, SeekOrigin.Begin);
            retval = xml.Deserialize(ms);
            ms.Close();
        }
        return (T)retval;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T DeepCopyByReflect<T>(T obj)
    {
        //如果是字符串或值类型则直接返回
        if (obj is string || obj.GetType().IsValueType) return obj;

        object retval = Activator.CreateInstance(obj.GetType());
        FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        foreach (FieldInfo field in fields)
        {
            try { field.SetValue(retval, DeepCopyByReflect(field.GetValue(obj))); }
            catch { }
        }
        return (T)retval;
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
        }

        return str;
    }
}
