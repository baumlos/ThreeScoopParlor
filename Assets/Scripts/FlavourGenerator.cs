using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlavourGenerator : MonoBehaviour
{
    [SerializeField] private string[] _promptSentences;
    [SerializeField] private string[] _promptAdjectives;
    private int _sentenceIndex;
    private int _adjectiveIndex;
    

    private void Start()
    {
        _promptSentences = RandomizeArray(_promptSentences);
        _promptAdjectives = RandomizeArray(_promptAdjectives);
    }

    private string[] RandomizeArray(string[] array)
    {
        System.Random rnd = new System.Random();
        return array.OrderBy(x => rnd.Next()).ToArray();
    }

    public string GenerateOrder()
    {
        var sentenceParts = _promptSentences[_sentenceIndex++].Split('_');
        var order = $"{sentenceParts[0]}{_promptAdjectives[_adjectiveIndex++]}{sentenceParts[1]}";
        
        // check if reached end of prompts
        if (_sentenceIndex >= _promptSentences.Length)
        {
            _promptSentences = RandomizeArray(_promptSentences);
            _sentenceIndex = 0;
        }
        if(_adjectiveIndex > _promptAdjectives.Length)
        {
            _promptAdjectives = RandomizeArray(_promptAdjectives);
            _adjectiveIndex = 0;
        }
        return order;
    }

    public string GetResult(List<Icecream> icecreams)
    {
        Debug.Log("TODO generate result text");
        return NameCombination(icecreams);
    }

    private string NameCombination(List<Icecream> icecreams)
    {
        string result = "";
        for (var i = 0; i < icecreams.Count; i++)
        {
            var icecream = icecreams[i];

            switch (i)
            {
                case 0:
                    result += icecream.First[Random.Range(0, icecream.First.Length)].Replace("_", " ");
                    break;
                case 1:
                    var middle = icecream.Middle[Random.Range(0, icecream.Middle.Length)];
                    if (result.Contains(" "))
                        result += char.ToUpper(middle[0]) + middle.Substring(1);
                    else
                        result += middle;
                    break;
                case 2:
                    var last = icecream.Last[Random.Range(0, icecream.Last.Length)].Replace("_", " ");
                    if ((last[0].ToString()).Any(char.IsUpper))
                        result += " ";
                    result += last;
                    break;
            }
        }

        return result;
    }
}
