using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private int valueMax = 100;
    [SerializeField] private int value = 100;

    [SerializeField] private TMPro.TextMeshProUGUI _textMeshProUGUI;
    public void Start()
    {
        UpdateVisual();
    }

    public void SetValueMax(int valMax)
    {
        valueMax = valMax;
        if (value > valueMax)
        {
            value = valueMax;
        }
        UpdateVisual();
    }

    public void SetValue(int val)
    {
        value = val;
        if (value > valueMax)
        {
            value = valueMax;
        }

        UpdateVisual();
    }

    private void UpdateVisual()
    {
        float val = (float)value / valueMax;
        if (val > 1)
        {
            val = 1f;
        }
        if (val < 0)
        {
            val = 0;
        }

        (_image.transform as RectTransform).localScale = new Vector2(val, 1);
        
        if(_textMeshProUGUI)
            _textMeshProUGUI.text = value.ToString() + "/" + valueMax.ToString();
    }

    private void OnValidate()
    {
        UpdateVisual();
    }
}
