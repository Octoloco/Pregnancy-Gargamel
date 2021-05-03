using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brush : MonoBehaviour
{
    public Image woman;
    public Image brush;
    public Sprite[] women;
    public Sprite[] brushes;
    bool dragging;
    int index;

    void Start()
    {
        GameObject.Find("TransitionCanvas").GetComponentInChildren<Animator>().SetBool("cover", false);
        dragging = false;
        index = 0;
        woman.sprite = women[index];
        brush.sprite = brushes[index];
    }

    private void Update()
    {
        if (dragging)
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
    }

    private void OnMouseDown()
    {
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (index < 4)
        {
            index++;
            woman.sprite = women[index];
            brush.sprite = brushes[index];
        }
        
    }
}
