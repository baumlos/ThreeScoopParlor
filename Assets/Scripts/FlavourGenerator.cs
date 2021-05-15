using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlavourGenerator : MonoBehaviour
{
    // color matrix
    //

    public string GenerateOrder()
    {
        Debug.Log("TODO generate new order");
        return "todo";
    }

    public string GetResult(List<Icecream> icecreams)
    {
        Debug.Log("TODO generate result text");
        return NameCombination(icecreams);
    }

    public string NameCombination(List<Icecream> icecreams)
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
                    var last = icecream.Last[Random.Range(0, icecream.Last.Length)];
                    if (last.Any(char.IsUpper))
                        result += " ";
                    result += last;
                    break;
            }
        }

        return result;
    }
}
