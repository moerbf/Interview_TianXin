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
        transform.DOScale(new Vector3(1, 1, 1), 0.5f);
    }
}
