using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meme 
{
    // Start is called before the first frame update
    MemeBase _base;
    int level;

    public int HP { get; set; }
    public List<Move> Moves { get; set; }
    public Meme(MemeBase mbase, int pLevel) 
    {
        _base = mbase;
        level = pLevel;
        HP = _base.MaxHp;
        Moves = new List<Move>();
        foreach (var move in _base.LearnableMoves)
        {
            if (move.Level <= level)
            {
                Moves.Add(new Move(move.Base));
            }

            if (Moves.Count >= 4 )
            {
                break;
            }
        }
    }

    public int Attack
    {
        get { return Mathf.FloorToInt((_base.Attack * level) / 100f) + 5; }
    }
    public int Defence
    {
        get { return Mathf.FloorToInt((_base.Defence * level) / 100f) + 5; }
    }
    public int SpAttack
    {
        get { return Mathf.FloorToInt((_base.SpAttack * level) / 100f) + 5; }
    }
    public int SpDefence
    {
        get { return Mathf.FloorToInt((_base.SpDefence * level) / 100f) + 5; }
    }
    public int Speed
    {
        get { return Mathf.FloorToInt((_base.Speed * level) / 100f) + 5; }
    }
    public int MaxHp
    {
        get { return Mathf.FloorToInt((_base.MaxHp * level) / 100f) + 10; }
    }
}
