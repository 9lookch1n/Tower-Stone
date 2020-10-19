using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : Singleton<Hover> //Singleton
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Use Method
        FollowMouse();
    }
    private void FollowMouse()
    {
        //Create a condition to follow the mouse
        if (spriteRenderer.enabled)
        {
            //FollowMouse and Connect with mousePoition
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Set up just axis X and Y
            transform.position = new Vector3(transform.position.x, transform.position.y);
        }

    }
    public void Activate(Sprite sprite)
    {
        //set up sprite
        this.spriteRenderer.sprite = sprite;
        spriteRenderer.enabled = true;
    }
    public void Del_Activate()
    {
        //set up sprite
        spriteRenderer.enabled = false;
        //set in Gamemanager
        GameManager.Instance.ClickBtn = null; 
    }
}
