using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOneDevice : MonoBehaviour
{
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject Carousel;
    public GameObject offScreen;
    bool dragging;
    void Start()
    {
        GameObject.Find("TransitionCanvas").GetComponentInChildren<Animator>().SetBool("cover", false);
        transform.position = Vector3.zero;
        dragging = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dragging = false;
        Carousel.GetComponent<Image>().enabled = true;
        offScreen.GetComponent<Image>().enabled = false;
        leftArrow.GetComponent<Button>().interactable = true;
        rightArrow.GetComponent<Button>().interactable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dragging = true;
        Carousel.GetComponent<Image>().enabled = false;
        offScreen.GetComponent<Image>().enabled = true;
        leftArrow.GetComponent<Button>().interactable = false;
        rightArrow.GetComponent<Button>().interactable = false;
    }
}
