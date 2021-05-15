using UnityEngine;

[CreateAssetMenu(fileName = "New Icecream Flavour", menuName = "Icecream")]
public class Icecream : MonoBehaviour
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
}
