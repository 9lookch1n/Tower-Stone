using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_Tower : MonoBehaviour
{
    // Script This will get the value to use.

    [SerializeField]
    private GameObject towerPrefab;

    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private int money;

    [SerializeField]
    private Text moneyText;

    public GameObject TowerPrefab 
    {
        get
        {
            return towerPrefab;
        }
    }

    public Sprite Sprite 
    {
        get
        {
            return sprite; 
        }
    }

    public int Money 
    { get
        {
            return money;
        }

    }

    private void Start()
    {
        moneyText.text = Money + "$";
    }

}
