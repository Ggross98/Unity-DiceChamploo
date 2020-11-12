
using UnityEngine;

/// <summary>
/// 场景管理类的模板
/// </summary>
public abstract class SceneStateBase<T> : MonoBehaviour where T: MonoBehaviour
{
    public static T Instance;

    protected void Awake()
    {
        Instance = GetComponent<T>();

        if (Instance == null) Instance = gameObject.AddComponent<T>();

        LoadPrefabs();
    }

    protected void Start()
    {
        LoadUIObjects();
    }

    //各个场景共有方法：加载UI对象
    protected abstract void LoadUIObjects();

    //各个场景共有方法：刷新UI对象
    protected abstract void RefreshUIObjects();

    //各个场景共有方法：加载Prefabs资源
    protected abstract void LoadPrefabs();

}
