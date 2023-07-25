using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ScannableItem : MonoBehaviour
{
    public float price;
    public Item item;
    [SerializeField]
    private Image img;

    private bool canFade;
    private float currentAlpha;
    private float elapsedTime;

    [SerializeField]
    private Sprite[] sprites;

    public bool wasScanned;

    private void Start()
    {
        MatchItemSprite();
    }

    public void ScanItem()
    {
        currentAlpha = 255f;
        canFade = true;
    }

    private void Update()
    {
        if (!wasScanned)
        {
            if (canFade && currentAlpha > 0f)
            {
                Color c = img.color;
                elapsedTime += Time.deltaTime;
                c.a = 1.0f - Mathf.Clamp01(elapsedTime / 1f);
                img.color = c;
            }

            if (currentAlpha < 0f)
            {
                wasScanned = true;
            }
        }
    }

    public void MatchItemSprite()
    {
        // lightbulb = 0, highVoltBattery = 1, lowVoltBattery = 2,
        // motherboard = 3, oil = 4, peanutbutter = 5,
        // soda = 6, twink = 7, sock = 8

        img.sprite = sprites[(int)item];
    }

}
