using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TipsUI : UIBase
{
    public override UILayer uIlayer => UILayer.Mask;

    public Button okBtn;
    public override void Awake()
    {
        base.Awake();
        okBtn = transform.Find("OKBtn").GetComponent<Button>();
        okBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.PopUI<TipsUI>();
        });
    }
    public override void OnEnter()
    {
        base.OnEnter();
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.3f);
    }
}
