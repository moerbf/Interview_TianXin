using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTaskUI : UIBase
{
    public override UILayer uIlayer => UILayer.Base;

    public Button backBtn;

    public override void Awake()
    {
        base.Awake();
        backBtn = transform.Find("BackBtn").GetComponent<Button>();
        backBtn.onClick.AddListener(OnBackBtnClick);
    }

    private void OnBackBtnClick()
    {
        UIManager.Instance.PopUI<MainTaskUI>();
    }
}
