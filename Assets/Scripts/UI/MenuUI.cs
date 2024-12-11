using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MenuUI : UIBase
{
    public override UILayer uIlayer => UILayer.Top;

    public Button homePageBtn;
    public Button actorBtn;
    public Button storyBtn;
    public Button adventureBtn;
    public Button unionBtn;
    public Button capsuleBtn;
    public Button mainMenuBtn;

    public Button selectBtn;
    public float originalY;
    public override void Awake()
    {
        base.Awake();
        homePageBtn = transform.Find("HomePageBtn").GetComponent<Button>();
        actorBtn = transform.Find("ActorBtn").GetComponent<Button>();
        storyBtn = transform.Find("StoryBtn").GetComponent<Button>();
        adventureBtn = transform.Find("AdventureBtn").GetComponent<Button>();
        unionBtn = transform.Find("UnionBtn").GetComponent<Button>();
        capsuleBtn = transform.Find("CapsuleBtn").GetComponent<Button>();
        mainMenuBtn = transform.Find("MainMenuBtn").GetComponent<Button>();

        homePageBtn.onClick.AddListener(OnHomePageBtnClick);
        actorBtn.onClick.AddListener(OnActorBtnClick);
        storyBtn.onClick.AddListener(OnStoryBtnClick);
        adventureBtn.onClick.AddListener(OnAdvanceBtnClick);
        unionBtn.onClick.AddListener(OnUnionBtnClick);
        capsuleBtn.onClick.AddListener(OnCapsuleBtnClick);
        mainMenuBtn.onClick.AddListener(OnMainMenuBtnClick);

    }

    private void Start()
    {
        selectBtn = homePageBtn;
        originalY = selectBtn.transform.localPosition.y;

        StartCoroutine(BtnJump());
    }
    private void OnActorBtnClick()
    {
        if (selectBtn == actorBtn)
        {
            return;
        }
        // 按钮复位
        selectBtn.transform.localPosition = new Vector3(selectBtn.transform.localPosition.x
            , originalY, selectBtn.transform.localPosition.z);
        selectBtn = actorBtn;

        MaskUI maskUI = (MaskUI)UIManager.Instance.GetUI<MaskUI>();
        maskUI.onMaskOpen += () => 
        {
            UIManager.Instance.PopByLayer(UILayer.Base);
            UIManager.Instance.ShowUI<ActorUI>();
        };
        UIManager.Instance.ShowUI<MaskUI>();
    }
    private void OnAdvanceBtnClick()
    {
        if (selectBtn == adventureBtn)
        {
            return;
        }

        selectBtn.transform.localPosition = new Vector3(selectBtn.transform.localPosition.x
            , originalY, selectBtn.transform.localPosition.z);
        selectBtn = adventureBtn;


        MaskUI maskUI = (MaskUI)UIManager.Instance.GetUI<MaskUI>();
        maskUI.onMaskOpen += () => 
        {
            UIManager.Instance.PopByLayer(UILayer.Base);
            UIManager.Instance.ShowUI<VideoUI>();
            UIManager.Instance.ShowUI<HUDUI>();
            UIManager.Instance.ShowUI<AdventureUI>();
        };
        UIManager.Instance.ShowUI<MaskUI>();
    }
    private void OnCapsuleBtnClick()
    {
        if (selectBtn == capsuleBtn)
        {
            return;
        }
        // 按钮复位
        selectBtn.transform.localPosition = new Vector3(selectBtn.transform.localPosition.x
            , originalY, selectBtn.transform.localPosition.z);
        selectBtn = actorBtn;

        UIManager.Instance.ShowUI<TipsUI>();
    }
    private void OnHomePageBtnClick()
    {
        if (selectBtn == homePageBtn)
        {
            return;
        }

        selectBtn.transform.localPosition = new Vector3(selectBtn.transform.localPosition.x
            , originalY, selectBtn.transform.localPosition.z);
        selectBtn = homePageBtn;


        MaskUI maskUI = (MaskUI)UIManager.Instance.GetUI<MaskUI>();
        maskUI.onMaskOpen += () => 
        {
            UIManager.Instance.PopByLayer(UILayer.Base);
            UIManager.Instance.ShowUI<VideoUI>();
            UIManager.Instance.ShowUI<HomePageUI>();
        };
        UIManager.Instance.ShowUI<MaskUI>();
    }
    private void OnMainMenuBtnClick()
    {
        if (selectBtn == mainMenuBtn)
        {
            return;
        }
        // 按钮复位
        selectBtn.transform.localPosition = new Vector3(selectBtn.transform.localPosition.x
            , originalY, selectBtn.transform.localPosition.z);
        selectBtn = actorBtn;

        UIManager.Instance.ShowUI<TipsUI>();
    }
    private void OnStoryBtnClick()
    {
        if (selectBtn == storyBtn)
        {
            return;
        }
        // 按钮复位
        selectBtn.transform.localPosition = new Vector3(selectBtn.transform.localPosition.x
            , originalY, selectBtn.transform.localPosition.z);
        selectBtn = actorBtn;

        UIManager.Instance.ShowUI<TipsUI>();
    }
    private void OnUnionBtnClick()
    {
        if (selectBtn == unionBtn)
        {
            return;
        }
        // 按钮复位
        selectBtn.transform.localPosition = new Vector3(selectBtn.transform.localPosition.x
            , originalY, selectBtn.transform.localPosition.z);
        selectBtn = actorBtn;

        UIManager.Instance.ShowUI<TipsUI>();
    }
    public override void OnExit()
    {
    }
    // 弹动动画
    public IEnumerator BtnJump()
    {
        while (true)
        {
            selectBtn.transform.DOLocalJump(
                new Vector3(selectBtn.transform.localPosition.x,
                            selectBtn.transform.localPosition.y + 10,
                            selectBtn.transform.localPosition.z),
                jumpPower: 10,
                numJumps: 1,
                duration: 0.5f).OnKill(() =>
                {
                    selectBtn.transform.localPosition = selectBtn.transform.localPosition = new Vector3(selectBtn.transform.localPosition.x
            , originalY, selectBtn.transform.localPosition.z);
                });

            yield return new WaitForSeconds(1f);
        }
    }
}
