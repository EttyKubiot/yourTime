
using UnityEngine;

[CreateAssetMenu(fileName = "Avatar Data", menuName = "Avater Data", order = 53)]

public class AvatarData : ScriptableObject
{
    [SerializeField] private Sprite image;
    [SerializeField] private char sound;
    [SerializeField] private AudioClip audioClip;

    public Sprite Image => image;
    public char Sound => sound;
    public AudioClip AudioClip => audioClip;
}
