using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanel : MonoBehaviour
{
    [SerializeField]
    Transform[] fields;

    public int skillPerPage = 10;

    int pages = 1;

    int currentIndex = 0;

    GameObject skillViewPrefab;

    private void Start()
    {

        Transform field = fields[pages-1];
        int count = 0;

        foreach(List<DiceFaceData> list in ComboData.comboDataDictionary.Keys)
        {
            GameObject obj = Instantiate(skillViewPrefab, field);
            SkillView view = obj.GetComponent<SkillView>();

            view.ShowCombo(list);
            count++;

            if(count >= skillPerPage)
            {
                pages++;
                field = fields[pages-1];
                count = 0;
            }
        }

        currentIndex = 0;
        ShowPage(currentIndex);
    }

    public void SetActive(bool a)
    {
        gameObject.SetActive(a);
    }

    public void NextPage()
    {
        currentIndex++;
        if (currentIndex >= pages) currentIndex = 0;

        ShowPage(currentIndex);
    }

    private void ShowPage(int index)
    {
        for(int i = 0; i < fields.Length; i++)
        {
            if(index == i)
            {
                fields[i].gameObject.SetActive(true);
            }
            else
            {
                fields[i].gameObject.SetActive(false);
            }
        }
    }

    private void Awake()
    {
        skillViewPrefab = Resources.Load<GameObject>("Prefabs/SkillViewPrefab");
    }
}
