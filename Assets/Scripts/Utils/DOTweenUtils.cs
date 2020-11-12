using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenUtils
{
    /// <summary>
    /// 将一个ui对象移动至某个本地坐标
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="pos"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public static Tween MoveTo(GameObject obj, Vector2 pos, float time)
    {
        Tween tween = obj.GetComponent<RectTransform>().DOLocalMove(pos, time, false);

        return tween;
    }

    /// <summary>
    /// 将一个ui对象旋转固定角度
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="angle"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public static Tween RotateAngle(GameObject obj, float angle, float time)
    {
        Tween tween = obj.GetComponent<RectTransform>().DOLocalRotate(new Vector3(0, 0, angle), time, RotateMode.WorldAxisAdd);

        return tween;
    }

    /// <summary>
    /// 将一个ui对象旋转至某个角度
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="angle"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public static Tween RotateTo(GameObject obj, float angle, float time)
    {
        Tween tween = obj.GetComponent<RectTransform>().DOLookAt(new Vector3(0, 0, angle), time);

        return tween;
    }

    /// <summary>
    /// 将一个ui对象缩小再还原至原大小
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="minScale"></param>
    /// <param name="time1"></param>
    /// <param name="time2"></param>
    /// <returns></returns>
    public static Sequence ChangeScale(GameObject obj, float minScale, float time1, float time2)
    {
        Sequence s = DOTween.Sequence();
        s.Append(obj.GetComponent<RectTransform>().DOScale(minScale, time1));
        s.Append(obj.GetComponent<RectTransform>().DOScale(1, time2));

        return s;
    }
}
