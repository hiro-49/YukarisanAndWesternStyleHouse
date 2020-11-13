using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Stages")]
public class Stages : ScriptableObject
{
    public List<StageConnectionElement> stages;

    public Dictionary<string, GameObject> ToDictionary()
    {
        Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();
        foreach (StageConnectionElement element in stages)
        {
            dictionary.Add(element.key, element.stage);
        }
        return dictionary;
    }

}
