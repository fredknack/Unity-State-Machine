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

    void Start()
    {
        imageComponent = GetComponent<Image>();
        SetImage1();
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