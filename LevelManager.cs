using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.Collections;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    private GameObject Ground; //CreateGameObject


    // Start is called before the first frame update
    void Start()
    { 
        // Use Method
        CreateLevel();
    }

    public Dictionary<Point, TileScript> Tiles { get; set; } //Dictionary

    private void CreateLevel()
    {
        // Set Point
        Tiles = new Dictionary<Point, TileScript>();
        //Instantiate prefabs
        Instantiate(Ground);

    }
    
}
