using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    static Data data;
    public int Num;
    public SpawIte S;
    public float littletime;
    public float Speed;

    private void Awake()
    {
        littletime = 1 / littletime;
        if (data == null)
        {
            data = Camera.main.GetComponent<Data>();
        }
    }
    private void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
        transform.localScale -= Vector3.one * littletime * Time.deltaTime;
        if (this.transform.localScale.x <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void Call()
    {
        data.AddData(Num);
        S.SpawnNew();
        this.enabled = true;
    }
}
