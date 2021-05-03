using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game3 : MonoBehaviour
{
    public Image woman; 
    public Image shoe; 
    public Sprite[] shoes; 
    public Sprite[] women;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("TransitionCanvas").GetComponentInChildren<Animator>().SetBool("cover", false);
        index = 0;
    }

    public void Right()
    {
        index++;
        if (index > shoes.Length - 1)
        {
            index = 0;
        }
        woman.sprite = women[index];
        shoe.sprite = shoes[index];
    }

    public void Left()
    {
        index--;
        if (index < 0)
        {
            index = shoes.Length - 1;
        }
        woman.sprite = women[index];
        shoe.sprite = shoes[index];
    }
}
