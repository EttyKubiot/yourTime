using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwapperS : MonoBehaviour
{
    [SerializeField]
    private Sprite enabledSprite;

    [SerializeField]
    private Sprite disabledSprite;
#pragma warning restore 649

    private Image image;

    /// <summary>
    /// Unity's Awake method.
    /// </summary>
    public void Awake()
    {
        image = GetComponent<Image>();
    }

    /// <summary>
    /// Swaps the sprite.
    /// </summary>
    public void SwapSprite()
    {
        image.sprite = image.sprite == enabledSprite ? disabledSprite : enabledSprite;
    }

    /// <summary>
    /// Sets the sprite as enabled/disabled.
    /// </summary>
    /// <param name="spriteEnabled">True if the sprite should be enabled; false otherwise.</param>
    public void SetEnabled(bool spriteEnabled)
    {
        image.sprite = spriteEnabled ? enabledSprite : disabledSprite;
    }
}

