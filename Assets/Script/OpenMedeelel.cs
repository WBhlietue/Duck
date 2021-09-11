using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMedeelel : MonoBehaviour
{
    public GameObject[] Medee;
    public GameObject thismedee;
    public void Click()
    {
        for (int i = 0; i < Medee.Length; i++)
        {
            Medee[i].SetActive(false);
        }
        thismedee.SetActive(true);
    }
}
