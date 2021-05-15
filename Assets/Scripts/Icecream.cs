using UnityEngine;
public class Icecream : MonoBehaviour
{
    public string Name;
    public string[] First;
    public string[] Middle;
    public string[] Last;
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
}
