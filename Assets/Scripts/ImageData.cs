
using UnityEngine;

[CreateAssetMenu(fileName = "Image Data", menuName = "Image Data", order = 52)]

public class ImageData : ScriptableObject
{
    [SerializeField] private Sprite image;
    [SerializeField] private char sound;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private ParticleSystem particles;

    public Sprite Image => image;
    public char Sound => sound;
    public AudioClip AudioClip => audioClip;

    public ParticleSystem Particles => particles;
}

