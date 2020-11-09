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

    Sprite[] sprites = new Sprite[6];

    [SerializeField]
    Image image;

    public static float animInterval = 0.05f;
    public static int animCount = 10;

    public void Init(DiceData dice)
    {
        diceData = dice;
        faces = dice.faces;

        for(int i = 0; i < 6; i++)
        {
            sprites[i] = faces[i].icon;
        }

        image.sprite = sprites[0];
    }
    
    public DiceFaceData Roll()
    {
        int i = Random.Range(0, 6);

        //result = contents[i];


        StartCoroutine(ShowRollAnimation(animCount, animInterval, i));

        return faces[i];
    }

    private IEnumerator ShowRollAnimation(int count, float interval, int target)
    {
        for(int i = 0; i < count; i++)
        {
            image.sprite = sprites[Random.Range(0, 6)];
            yield return new WaitForSeconds(interval);
        }
        image.sprite = sprites[target];

        yield return null;
    }

    public DiceFaceData RollTo(Vector2 pos, float angle)
    {

        
        int i = Random.Range(0, 6);

        StartCoroutine(ShowRollAnimation(animCount, animInterval, i));
        MoveTo(pos);
        RotateTo(angle);
        ChangeScale(0.5f);

        
        //image.sprite = sprites[i];

        return faces[i];
    }

    public void MoveTo(Vector2 pos)
    {
        Tween tween = GetComponent<RectTransform>().DOLocalMove(pos, animInterval*animCount, false);
    }

    public void RotateTo(float angle)
    {
        Tween tween = GetComponent<RectTransform>().DOLocalRotateQuaternion(Quaternion.Euler(0,0,angle),animInterval*animCount);
    }

    public void ChangeScale(float minScale)
    {
        Sequence s = DOTween.Sequence();
        s.Append(GetComponent<RectTransform>().DOScale(minScale, animInterval * animCount / 2));
        //Tween tween = GetComponent<RectTransform>().DOScale(minScale, animInterval * animCount / 2);
        s.Append(GetComponent<RectTransform>().DOScale(1, animInterval * animCount / 2));
        //tween.onComplete.Invoke() = GetComponent<RectTransform>().DOScale(1, animInterval * animCount / 2);
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
