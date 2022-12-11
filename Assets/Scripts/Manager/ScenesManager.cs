using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{
    Menu,
    Main,
    Battle
}
public class ScenesManager : MonoBehaviour
{
    #region Singletone
    private static ScenesManager Instance = null;
    public static ScenesManager GetInstance()
    {
        if (Instance == null)
        {
        GameObject go = new GameObject("@ScenesManager");
        Instance = go.AddComponent<ScenesManager>();

        DontDestroyOnLoad(go);
        }
        return Instance;
    }
    #endregion

    #region SceneControl
    public Scene currentScene;
    public void ChangeScene(Scene scene)
    {
        UIManager.GetInstance().ClearList();

        currentScene = scene;
        SceneManager.LoadScene(scene.ToString()); // 만약 enum의 정보를 string이 아니라 int를 사용해서 순서를 가져온다면, 빌드 셋팅에서 Scene의 순서도 맞춰야 하기때문에 string 형식이 편리하다.
    }

    #endregion
}
