using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UseMutlti : MonoBehaviour
{
    public InputField i;
    public Data d;
    public int num;

    public void Click()
    {
        d.Use(num, Int32.Parse(i.text));
    }

}
