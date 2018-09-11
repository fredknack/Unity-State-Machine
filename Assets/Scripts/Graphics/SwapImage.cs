using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapImage : MonoBehaviour
{
    public static SwapImage Instance { get; private set; }

    Image imageComponent;
    public Sprite firstImage;
    public Sprite secondImage;
    public Sprite thirdImage;
    public Sprite fourthImage;
    public Sprite fifthImage;

    private int slideNum;

    private bool Starting = false;
    public Image screen;
    float fadeTime = 1f;

    void Start()
    {
        imageComponent = GetComponent<Image>();
        AdvanceSlide();
    }

    public void AdvanceSlide()
    {
        Debug.Log("AdvanceSlide");
        slideNum = PersistentManagerScript.Instance.slideNum;
        if (slideNum == 1) 
        { 
            SetImage1();
            fadeScreenIn();
        } else if (slideNum == 2) 
        {
            SetImage2();
            fadeScreenIn();
        }
        else if (slideNum == 3)
        {
            SetImage3();
            fadeScreenIn();
        }
        else if (slideNum == 4)
        {
            SetImage4();
            fadeScreenIn();
        }
        else if (slideNum == 5)
        {
            SetImage5();
            fadeScreenIn();
        }
    }

    public void fadeScreenIn()
    {
        StartCoroutine(fadeInScreenCoroutine());
    }

    public void fadeScreenOut()
    {
        StartCoroutine(fadeOutScreenCoroutine());
    }

    public void SetImage1(){
        imageComponent.sprite = firstImage;
    }

    public void SetImage2(){
        imageComponent.sprite = secondImage;
    }

    public void SetImage3(){
        imageComponent.sprite = thirdImage;
    }

    public void SetImage4(){
        imageComponent.sprite = fourthImage;
    }

    public void SetImage5(){
        imageComponent.sprite = fifthImage;
    }

    IEnumerator fadeInScreenCoroutine()
    {
        yield return new WaitForSeconds(0.1f);

        CrossFadeAlphaWithCallBack(imageComponent, 1f, fadeTime, delegate
        {
            Debug.Log("End Fading In");

            fadeScreenOut();
        });
    }

    IEnumerator fadeOutScreenCoroutine()
    {
        yield return new WaitForSeconds(5);

        CrossFadeAlphaWithCallBack(imageComponent, 0f, fadeTime, delegate
        {
            Debug.Log("End Fading Out");

            if (PersistentManagerScript.Instance.slideNum >= 5)
            {
                PersistentManagerScript.Instance.slideNum = 1;
            } else {
                PersistentManagerScript.Instance.slideNum = PersistentManagerScript.Instance.slideNum + 1;
            }

            //fadeScreenIn();
            AdvanceSlide();
        });
    }

    void CrossFadeAlphaWithCallBack(Image img, float alpha, float duration, System.Action action)
    {
        StartCoroutine(CrossFadeAlphaCOR(img, alpha, duration, action));
    }

    IEnumerator CrossFadeAlphaCOR(Image img, float alpha, float duration, System.Action action)
    {
        Color currentColor = img.color;

        Color visibleColor = img.color;

        visibleColor.a = alpha;

        float counter = 0;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            img.color = Color.Lerp(currentColor, visibleColor, counter / duration);
            yield return null;
        }

        //Done. Execute callback
        action.Invoke();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}