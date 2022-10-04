using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private void Start()
    {
        CheatConsoleManager.CreateCommand("id", Test);
    }

    public void Test()
    {
        Debug.Log("Testing..");
    }
}
