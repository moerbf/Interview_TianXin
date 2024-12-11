using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static private UIManager _instance;
    static public UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject uiManagerObj = new GameObject("UIManager");
                _instance = uiManagerObj.AddComponent<UIManager>();
            }
            return _instance;
        }
    }

    public Dictionary<UIType, UIBase> uICacheDictionary = new Dictionary<UIType, UIBase>();
    public Stack<UIBase>[] _uiLayerStack = new Stack<UIBase>[4];

    public Canvas[] canvas;

    private void Awake()
    {
        _instance = this;
        canvas = GameObject.Find("UI").GetComponentsInChildren<Canvas>();

        for (int i = 0; i < _uiLayerStack.Length; i++)
        {
            _uiLayerStack[i] = new Stack<UIBase>();
        }
    }
    // 得到UI
    public UIBase GetUI<T>() where T : UIBase
    {
        UIType uiType = Enum.Parse<UIType>(typeof(T).Name);

        if (uICacheDictionary.ContainsKey(uiType))
        {
            return uICacheDictionary[uiType];
        }
        else
        {
            GameObject uiObject = Resources.Load<GameObject>("Prefabs/" + uiType.ToString()); // 从Prefabs文件夹中加载UI对象

            if (uiObject == null)
            {
                Debug.LogError("UI Object not found: " + uiType.ToString());
                return null;
            }

            UIBase uiBase = GameObject.Instantiate(uiObject).AddComponent<T>();
            uiBase.transform.SetParent(canvas[(int)uiBase.uIlayer].transform, false);
            uICacheDictionary.Add(uiType, uiBase);
            return uiBase;
        }
    }
    // 隐藏UI
    public void HideUI<T>() where T : UIBase
    {
        UIBase currentUI = null;
        UIType uiType = Enum.Parse<UIType>(typeof(T).Name);

        if (uICacheDictionary.TryGetValue(uiType, out currentUI))
        {

            if (!_uiLayerStack[(int)currentUI.uIlayer].Contains(currentUI))
            {
                currentUI.OnPause();
            }
        }
    }
    // 弹出UI
    public void PopUI<T>() where T : UIBase
    {
        UIType uiType = Enum.Parse<UIType>(typeof(T).Name);
        UIBase currentUI = null;

        if (uICacheDictionary.TryGetValue(uiType, out currentUI))
        {
            if (_uiLayerStack[(int)currentUI.uIlayer].Count > 0 && _uiLayerStack[(int)currentUI.uIlayer].Peek() == currentUI)
            {
                _uiLayerStack[(int)currentUI.uIlayer].Pop().OnExit();

                if (_uiLayerStack[(int)currentUI.uIlayer].Count > 0)
                {
                    _uiLayerStack[(int)currentUI.uIlayer].Peek().OnResume();
                }
            }
        }
    }
    public void PopByLayer(UILayer layer)
    {

        while (_uiLayerStack[(int)layer].Count > 0)
        {
            _uiLayerStack[(int)layer].Pop().OnExit();
        }
    }
    // 显示UI
    public void ShowUI<T>() where T : UIBase
    {
        UIBase currentUI = null;
        UIType uiType = Enum.Parse<UIType>(typeof(T).Name);

        if (uICacheDictionary.TryGetValue(uiType, out currentUI))
        {
            if (!_uiLayerStack[(int)currentUI.uIlayer].Contains(currentUI))
            {
                currentUI.OnEnter();
                _uiLayerStack[(int)currentUI.uIlayer].Push(currentUI);
            }
        }
        else
        {
            currentUI = GetUI<T>();
            if (currentUI != null)
            {
                currentUI.OnEnter();

                _uiLayerStack[(int)currentUI.uIlayer].Push(currentUI);
            }
        }
    }

}
