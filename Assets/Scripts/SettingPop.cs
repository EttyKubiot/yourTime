
using UnityEngine;

using UnityEngine.UI;

public class SettingPop : MonoBehaviour
{
    [SerializeField]
    private ToggleGroup avatarToggleGroup;

    [SerializeField]
    private Slider soundSlider;

    [SerializeField]
    private Slider musicSlider;

    //[SerializeField]
    //private AnimatedButton resetProgressButton;

    [SerializeField]
    private Image resetProgressImage;

    [SerializeField]
    private Sprite resetProgressDisabledSprite;


    private int currentAvatar;
    private int currentSound;
    private int currentMusic;
    private int currentNotifications;

    
}

