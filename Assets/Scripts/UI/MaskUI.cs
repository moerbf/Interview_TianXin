using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class MaskUI : UIBase
{
    public delegate void OnMask();
    public OnMask onMaskOpen;
    public OnMask onMaskClose;
    public override UILayer uIlayer => UILayer.Mask;

    public Image comicImage;
    public Text loadingText;

    private Coroutine loadingCoroutine = null;
    public override void Awake()
    {
        base.Awake();
        comicImage = transform.Find("ComicImage").GetComponent<Image>();
        loadingText = transform.Find("LoadingText").GetComponent<Text>();
        defaultBlocksRaycasts = canvasGroup.blocksRaycasts;
    }
    public override void OnEnter()
    {
        canvasGroup.DOFade(1, 0.5f).OnComplete(() =>
        {
            onMaskOpen?.Invoke();
            onMaskOpen = null;
        });

        if (loadingCoroutine == null)
        {
            loadingCoroutine = StartCoroutine(Loading());
        }
        StartCoroutine(Exit());
    }
    public override void OnExit()
    {

        canvasGroup.DOFade(0, 0.5f).OnComplete(() =>
        {
            onMaskClose?.Invoke();
            onMaskClose = null;
        });
        canvasGroup.blocksRaycasts = false;

        if (loadingCoroutine != null)
        {
            StopCoroutine(loadingCoroutine);
            loadingCoroutine = null;
        }

        StopCoroutine(Exit());
    }
    public IEnumerator Exit()
    {
        yield return new WaitForSeconds(1.0f);

        UIManager.Instance.PopUI<MaskUI>();
    }
    public IEnumerator Loading()
    {
        string[] loadingStates = { "加载中", "加载中.", "加载中..", "加载中..." };

        int index = 0;
        while (true)
        {
            loadingText.text = loadingStates[index];
            index = (index + 1) % loadingStates.Length;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
