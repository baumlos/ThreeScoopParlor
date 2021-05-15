using UnityEngine;

[CreateAssetMenu(fileName = "New Icecream Flavour", menuName = "Icecream")]
public class Icecream : ScriptableObject
{
    public string Name;
    public enum FlavourColor
    {
        White,
        Red,
        Yellow,
        Blue,
        Green
    }
    public FlavourColor Color;

    public enum FlavourMood
    {
        Anger,
        Fear,
        Sad,
        Sexy, 
        Joy
    }
    public FlavourMood Mood;

    public Mesh Mesh;
    public Texture Texture;
}
