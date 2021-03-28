using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meme 
{
    // Start is called before the first frame update
    MemeBase _base;
    int level;

    public Meme(MemeBase mbase, int pLevel) 
    {
        _base = mbase;
        level = pLevel;


    }

    public int Attack
    {
        get { return Mathf.FloorToInt((_base.Attack * level) / 100f) + 5; }
    }
    public int MaxHp
    {
        get { return Mathf.FloorToInt((_base.MaxHp * level) / 100f) + 10; }
    }
}
