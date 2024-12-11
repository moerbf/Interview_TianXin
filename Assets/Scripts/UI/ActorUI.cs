using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorUI : UIBase
{
    public Transform content;

    public override UILayer uIlayer => UILayer.Base;
    // FunctionButtons...
    public override void Awake()
    {
        base.Awake();
        content = transform.Find("Scroll View/Viewport/Content");
    }
}
