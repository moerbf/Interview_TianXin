using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureUI : UIBase
{
    public override UILayer uIlayer => UILayer.Base;

    public Button mainTaskBtn;
    public override void Awake()
    {
        base.Awake();
        mainTaskBtn = transform.Find("MainTaskBtn").GetComponent<Button>();
        mainTaskBtn.onClick.AddListener(OnMainTaskBtnClick);
    }

    private void OnMainTaskBtnClick()
    {
       UIManager.Instance.ShowUI<MainTaskUI>();
    }

    public override void OnExit()
    {
        base.OnExit();
        UIManager.Instance.PopUI<VideoUI>();
        UIManager.Instance.PopUI<HUDUI>();
    }
}
