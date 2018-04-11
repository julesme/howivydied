using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechFit : MonoBehaviour
{

    private float width, height;
    public RectTransform rt;
    public RectTransform rt2;

    void Start()
    {
        //rt = GetComponent<RectTransform>();
        rt2 = GetComponent<RectTransform>();
    }

    void Update()
    {
        width = rt.rect.width;
        height = rt.rect.height;
        rt2.sizeDelta = new Vector2(width+100, height+50);
    }
}