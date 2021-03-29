using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move 
{
    // Start is called before the first frame update
    public MoveBase Base { get; set; }
    public int PP { get; set; }

    public Move(MoveBase pBase)
    {
        Base = pBase;
        PP = pBase.Pp;

    }
}
  