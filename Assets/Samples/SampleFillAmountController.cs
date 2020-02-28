using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KiliWare.FilledSprite.Sample {
    public enum ButtonType
    {
        Bottom,
        Right,
        Top,
        Left
    }

    public class SampleFillAmountController : MonoBehaviour 
    {
        [SerializeField] private Image myImage;
        [SerializeField] private SpriteRenderer mySpriteRenderer;
        [SerializeField] private Slider fillAmountSlider;
        [SerializeField] private Toggle clockwiseToggle;
        [SerializeField] private Text fillOriginLabel;
        private Material mySpriteMaterial;

        void Awake ()
        {
            mySpriteMaterial = mySpriteRenderer.material;
        }

        public void OnButtonChanged(int type)
        {
            myImage.fillOrigin = type;

            float originX = 0, originY = 0;
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
            mySpriteMaterial.SetFloat("_FillOriginX", originX);
            mySpriteMaterial.SetFloat("_FillOriginY", originY);
            fillOriginLabel.text = "FillOrigin: " + Enum.GetName(typeof(ButtonType), (ButtonType)type);
        }

        public void OnClockwiseModeChanged()
        {
            bool isClockWise = clockwiseToggle.isOn;
            myImage.fillClockwise = isClockWise;
            mySpriteMaterial.SetFloat("_Clockwise", isClockWise ? 1 : 0);
        }

        public void OnSliderChanged()
        {
            float fillAmountValue = fillAmountSlider.value;
            myImage.fillAmount = fillAmountValue;
            mySpriteMaterial.SetFloat("_FillAmount", fillAmountValue);
        }
    }
}