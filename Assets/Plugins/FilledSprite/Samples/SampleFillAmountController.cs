using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonType
{
    Bottom,
    Right,
    Top,
    Left
}

public class SampleFillAmountController : MonoBehaviour {
    [SerializeField] private GameObject MyImageObject;
    [SerializeField] private GameObject MySpriteObject;
    private Image MyImage;
    private Material MySpriteMaterial;
    [SerializeField] private Slider MySlider;
    [SerializeField] private Toggle MyToggle;
    [SerializeField] private Button[] MyButtons;
    [SerializeField] private Text OriginLabel;

    void Start () {
        MyImage = MyImageObject.GetComponent<Image>();
        MySpriteMaterial = MySpriteObject.GetComponent<SpriteRenderer>().material;
    }

    public void OnButtonChanged(int type){
        MyImage.fillOrigin = type;

        float originX = 0;
        float originY = 0;
        switch((ButtonType)type){
            case ButtonType.Bottom:
                originY = -1;
                break;
            case ButtonType.Right:
                originX = 1;
                break;
            case ButtonType.Top:
                originY = 1;
                break;
            case ButtonType.Left:
                originX = -1;
                break;
        }
        MySpriteMaterial.SetFloat("_FillOriginX", originX);
        MySpriteMaterial.SetFloat("_FillOriginY", originY);
        OriginLabel.text = "FillOrigin: " + Enum.GetName(typeof(ButtonType), (ButtonType)type);
    }

    public void OnClockwiseModeChanged()
    {
        bool value = MyToggle.isOn;
        MyImage.fillClockwise = value;
        MySpriteMaterial.SetFloat("_Clockwise", value ? 1 : 0);
    }

    public void OnSliderChanged()
    {
        float value = MySlider.value;
        MyImage.fillAmount = value;
        MySpriteMaterial.SetFloat("_FillAmount", value);
    }
}