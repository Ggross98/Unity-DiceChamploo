using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 事件、战斗场景中的骰子对象
/// </summary>
public class DiceObject : MonoBehaviour
{
    //储存骰子某一面的信息
    public DiceData diceData;
    private DiceFaceData[] faces;

    public DiceFaceData currentFace;

    Sprite[] sprites = new Sprite[6];

    [SerializeField]
    Image image;

    [SerializeField]
    Button button;


    //动画相关
    public static float animInterval = 0.05f;
    public static int animCount = 10;
    public static float minScale = 0.5f;
    public static float angleRange = 360f;


    public void Init(DiceData dice)
    {
        diceData = dice;

        faces = dice.faces;

        for(int i = 0; i < 6; i++)
        {
            sprites[i] = faces[i].icon;
        }

        currentFace = faces[0];
        image.sprite = sprites[0];
    }
    
    public DiceFaceData Roll()
    {
        int i = Random.Range(0, 6);

        //result = contents[i];


        //StartCoroutine(ShowRollAnimation(animCount, animInterval, i));

        return faces[i];
    }

    private IEnumerator ShowRollAnimation(int count, float interval, int faceIndex, Vector2 pos, float angle, float mScale)
    {
        float time = count * interval;

        DOTweenUtils.MoveTo(gameObject, pos, time);
        DOTweenUtils.RotateAngle(gameObject, angle, time);
        DOTweenUtils.ChangeScale(gameObject, mScale, time/2, time/2);

        for (int i = 0; i < count; i++)
        {
            image.sprite = sprites[Random.Range(0, 6)];
            yield return new WaitForSeconds(interval);
        }
        image.sprite = sprites[faceIndex];

        yield return null;
    }

    public void SetLocalPosition(Vector2 pos)
    {
        transform.localPosition = pos;
        //GetComponent<RectTransform>().anchoredPosition = pos;
    }

    public DiceFaceData RollTo(Vector2 pos)
    {

        
        int i = Random.Range(0, 6);


        float angle = Random.Range(-angleRange, angleRange);

        StartCoroutine(ShowRollAnimation(animCount, animInterval, i,pos,angle,minScale));



        //image.sprite = sprites[i];


        currentFace = faces[i];

        return currentFace;
    }

    /*
    public void MoveTo(Vector2 pos, float time)
    {
        Tween tween = GetComponent<RectTransform>().DOLocalMove(pos, time, false);
    }

    public void RotateAngle(float angle, float time)
    {
        Tween tween = GetComponent<RectTransform>().DOLocalRotate(new Vector3(0,0,angle),time, RotateMode.WorldAxisAdd);
    }

    public void RotateTo(float angle, float time)
    {
        Tween tween = GetComponent<RectTransform>().DOLookAt(new Vector3(0, 0, angle), time);
    }

    public void ChangeScale(float minScale, float time1, float time2)
    {
        Sequence s = DOTween.Sequence();
        s.Append(GetComponent<RectTransform>().DOScale(minScale, time1));
        //Tween tween = GetComponent<RectTransform>().DOScale(minScale, animInterval * animCount / 2);
        s.Append(GetComponent<RectTransform>().DOScale(1, time2));
        //tween.onComplete.Invoke() = GetComponent<RectTransform>().DOScale(1, animInterval * animCount / 2);
    }*/

    public Button GetButton()
    {
        return button;
    }

    private void Start()
    {
        //image.sprite = sprites[0];
    }

    private void Awake()
    {
        //sprites= Resources.LoadAll<Sprite>("Dice");
    }






}
