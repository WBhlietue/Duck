using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaterMove : MonoBehaviour
{
    public Animator A;
    public float speed;
    public float Jumpforce;
    public Rigidbody2D R;
    bool CanJump = false;
    public GameObject Gameover;
    bool selected = false;
    void FixedUpdate()
    {
        float a = Input.GetAxis("Horizontal");
        A.SetFloat("speed", a != 0 ? 1 : 0);
        transform.Translate(Vector2.left * speed * Time.fixedDeltaTime * Mathf.Abs(a));
        Camera.main.transform.position = this.transform.position - new Vector3(0, 0, 10);
        if (a > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (a < 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            CanJump = false;
            R.AddForce(Vector2.up * Jumpforce);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            CanJump = true;
        }
        if (other.gameObject.CompareTag("goal"))
        {
            if (!selected)
            {
                selected = true;
                Gameover.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            other.gameObject.GetComponent<ItemInfo>().Call();
        }
    }
}
