using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public bool defaultBlocksRaycasts = true;
    
    public virtual UILayer uIlayer { get; }
    public virtual void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }
    public virtual void OnEnter() 
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = defaultBlocksRaycasts;
    }
    public virtual void OnPause() 
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
    public virtual void OnResume() 
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = defaultBlocksRaycasts;
    }
    public virtual void OnExit() 
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }

}
