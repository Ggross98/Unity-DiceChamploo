
using UnityEngine;

public abstract class SceneStateBase : MonoBehaviour
{
    public static SceneStateBase Instance;

    public void Awake()
    {
        Instance = this;
    }

    //各个场景共有方法：加载UI对象
    public abstract void LoadUIObjects();

    //各个场景共有方法：刷新UI对象
    public abstract void RefreshUIObjects();

    //各个场景共有方法：加载Prefabs资源
    public abstract void LoadPrefabs();

}
