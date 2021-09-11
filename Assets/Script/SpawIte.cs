using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawIte : MonoBehaviour
{
    public GameObject Item;
    public float targettime;
    GameObject A;
    float count;
    private void Update()
    {
        count += Time.deltaTime;
        if (count >= targettime)
        {
            count = 0;
            A = Instantiate(Item, this.transform.position, this.transform.rotation);
            A.GetComponent<ItemInfo>().S = this;
            this.enabled = false;
        }
    }
    public void SpawnNew()
    {
        this.enabled = true;
    }
}
