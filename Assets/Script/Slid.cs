using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slid : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IPointerDownHandler
{
    bool enter = false;
    public float speed;
    public Transform Nowpos;
    public Transform Targetpos;
    public float zuruu;
    public GameObject Slide;
    float value = 0;
    public Vector3 MouseStart;
    private void Start()
    {
        zuruu = Targetpos.position.y - Nowpos.position.y;
    }
    void Update()
    {

        if (enter)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                value += speed;
                if (value > 1)
                {
                    value = 1;
                }
                Slide.transform.position = Nowpos.position + new Vector3(0, zuruu * value, 0);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                value -= speed;
                if (value < 0)
                {
                    value = 0;
                }
                Slide.transform.position = Nowpos.position + new Vector3(0, zuruu * value, 0);
            }

        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        enter = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        enter = false;
    }
    public void OnDrag(PointerEventData eventData)
    {

        if (Input.mousePosition.y >= Nowpos.position.y && Input.mousePosition.y <= Targetpos.position.y)
        {
            Slide.transform.position = new Vector3(Slide.transform.position.x, Input.mousePosition.y, Slide.transform.position.z);
        }
        else
        {
            if (Slide.transform.position.y < Nowpos.position.y)
            {
                Slide.transform.position = Nowpos.position;
            }
            if (Slide.transform.position.y > Targetpos.position.y)
            {
                Slide.transform.position = Targetpos.position;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        MouseStart = Input.mousePosition;
    }
}
