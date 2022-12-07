using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    #region Singletone
    private static UIManager Instance = null;

    public static UIManager GetInstance()
    {
        if (Instance == null)
        {
        GameObject go = new GameObject("@UIManager");
        Instance = go.AddComponent<UIManager>();

        DontDestroyOnLoad(go);
        }
        return Instance;
    }
    #endregion

    #region UI Control
    Dictionary<string, GameObject> uiList = new Dictionary<string, GameObject>();

    public void OpenUI(string uiName)
    {
        if (uiList.ContainsKey(uiName) == false) // uiList에 uiName이 있는지 확인하는 코드
        {
        Object uiObj = Resources.Load("UI/"+uiName); // "UI/"는 Resources에 추가 된 경로를 표현할때 사용법이다.
        GameObject go = (GameObject)Instantiate(uiObj);
        uiList.Add(uiName, go);
        }
        else
            uiList[uiName].SetActive(true); // Dictionary[]의 대괄호에 이름을 적게되면 그 위치를 찾아준다. 그래서 그 위치를 찾고 setActive를 true로 햐주면 창이 나오게 된다.

    }

    public void CloseUI(string uiName)
    {
        if (uiList.ContainsKey(uiName) == true)
            uiList[uiName].SetActive(false);
    }

    #endregion

    public void SetEventSystem()
    {
        if (FindObjectOfType<EventSystem>() == false)
        {
            GameObject go = new GameObject("@EventSystem");
            go.AddComponent<EventSystem>();
            go.AddComponent<StandaloneInputModule>();
        }
    }
}