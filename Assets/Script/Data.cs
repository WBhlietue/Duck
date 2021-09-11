using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public List<Items> i = new List<Items>();
    private void Awake()
    {

        for (int j = 0; j < i.Count; j++)
        {
            if (PlayerPrefs.HasKey(j.ToString()))
            {
                i[j].count = PlayerPrefs.GetInt(j.ToString());
            }
            if (i[j].count == 0)
            {
                i[j].UI.SetActive(false);
            }
            else
            {
                i[j].Too.text = i[j].count.ToString();
                i[j].Heregleh.text = i[j].count.ToString();
            }
        }
    }
    public void AddData(int A)
    {

        i[A - 1].count++;
        i[A - 1].UI.SetActive(true);
        i[A - 1].Too.text = i[A - 1].count.ToString();
        i[A - 1].Heregleh.text = i[A - 1].count.ToString();
        PlayerPrefs.SetInt((A - 1).ToString(), i[A - 1].count);
    }
    public void Use(int A, int b)
    {
        if (i[A - 1].count >= b)
        {
            i[A - 1].count -= b;
            if (i[A - 1].count == 0)
            {
                i[A - 1].UI.SetActive(false);
                i[A - 1].Medeelel.SetActive(false);
                i[A - 1].Olon.SetActive(false);
            }
            else
            {
                i[A - 1].Too.text = i[A - 1].count.ToString();
                i[A - 1].Heregleh.text = i[A - 1].count.ToString();
                PlayerPrefs.SetInt((A - 1).ToString(), i[A - 1].count);
            }
        }

    }

    public void RestartGame()
    {
        PlayerPrefs.DeleteAll();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
[System.Serializable]
public class Items
{
    public GameObject UI;
    public Text Too;
    public Text Heregleh;
    public int count;
    public GameObject Medeelel;
    public GameObject Olon;
}
