using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Move", menuName = "meme/create new Move")]

public class MoveBase : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;
    [SerializeField] MemeType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

    public string Name
    {
        get { return name; }
    }
    public string Description
    {
        get { return description; }
    }
    public MemeType Type
    {
        get { return type; }
    }
    public int Power
    {
        get { return power; }
    }
    public int Accuracy
    {
        get { return accuracy; }
    }
    public int Pp
    {
        get { return pp; }
    }
}
