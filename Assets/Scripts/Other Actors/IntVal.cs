using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute]
public class IntVal : ScriptableObject
{
    public int initialVal;
    public int currentVal;

    // Start is called before the first frame update
    void Start()
    {
        currentVal = initialVal;
    }
}
