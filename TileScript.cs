using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
    //set Point GridPosition
    public Point GridPosition { get; private set; }

    //bool IsEmpty
    public bool IsEmpty { get; private set; }

    //color use when click
    //Color32 use RGB 0 -> 255
    private Color32 fullColor = new Color32(255,118,118,255);

    private Color32 emptyColor = new Color32(90, 255, 90, 255); 

    //sprite
    private SpriteRenderer SpriteRenderer;
    

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent Sprite
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Method Get value Point and Vector3
    public void Setup(Point gridPos, Vector3 WorldPos)
    {
        //IsEmpty true
        IsEmpty = true;

        //set up GridPostion
        this.GridPosition = GridPosition;
        //set up transform
        transform.position = WorldPos;

        //Script LevelManager add
        LevelManager.Instance.Tiles.Add(gridPos, this);

    }

    private void OnMouseOver()
    {
        //Check pressing
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickBtn != null)
        {
            if (IsEmpty == true) // true
            {
                //Color = Green
                ColorTile(fullColor);
            }
            //I don't know why it's not showing ^^
            else if (IsEmpty == false) // false 
            {
                //Color = Red
                ColorTile(emptyColor);
            }
            if (Input.GetMouseButtonDown(0))
            {
                //run method 
                PlaceTower();
            }
        }  
    }
    private void OnMouseExit()
    {
        //Color start white
        ColorTile(Color.white);
    }
    private void PlaceTower()
    {
        // Check the button press to create a tower according to the button.
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickBtn != null)
        {
            //Set Instantiate GameObject as picture both position and do not rotate
            GameObject tower = (GameObject)Instantiate(GameManager.Instance.ClickBtn.TowerPrefab, transform.position, Quaternion.identity); // Instantiate TowerPrefab and dont Rotate
            tower.GetComponent<SpriteRenderer>().sortingOrder = GridPosition.Y;

            //set tower tranform
            tower.transform.SetParent(transform);

            //bool IsEmpty
            IsEmpty = false;
            //Color start white
            ColorTile(Color.white);

            //Script gamemanager about the purchase
            GameManager.Instance.BuyTower();
        }

    } 
    private void  ColorTile(Color newColor)
    {
        // set a new color
        SpriteRenderer.color = newColor;
    }

}
