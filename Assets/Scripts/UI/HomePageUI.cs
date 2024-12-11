using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePageUI : UIBase
{
    public override UILayer uIlayer => UILayer.Base;

    public override void OnExit()
    {
        base.OnExit();
        UIManager.Instance.PopUI<VideoUI>();
    }
}
