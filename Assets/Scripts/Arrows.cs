using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrows : MonoBehaviour
{
    public Sprite[] images;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        GetComponent<Image>().enabled = false;
        GetComponent<Image>().sprite = images[index];
    }

    public void Right()
    {
        index++;
        if (index > images.Length - 1)
        {
            index = 0;
        }
        GetComponent<Image>().sprite = images[index];
    }

    public void Left()
    {
        index--;
        if (index < 0)
        {
            index = images.Length - 1;
        }
        GetComponent<Image>().sprite = images[index];
    }
}
