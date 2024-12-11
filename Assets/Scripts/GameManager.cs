using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        InitUI();
    }
    void InitUI()
    {
        UIManager.Instance.ShowUI<VideoUI>();
        UIManager.Instance.ShowUI<HomePageUI>();
        UIManager.Instance.ShowUI<MenuUI>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
