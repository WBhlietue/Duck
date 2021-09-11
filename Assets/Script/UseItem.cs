using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UseItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool Clicked = false;
    float count = 0;
    bool longcli = false;
    public Data d;
    public int num;
    void Update()
    {
        if (Clicked)
        {
            count += Time.deltaTime;
            if (count >= 2)
            {
                longcli = true;
                d.Use(num, 1);
                count = 0;
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Clicked = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Clicked = false;
        if (!longcli)
        {
            d.Use(num, 1);
        }
        else
        {
            longcli = false;
        }
    }
}
