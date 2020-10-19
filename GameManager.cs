using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
 
public class GameManager : Singleton<GameManager>
{
    public Btn_Tower ClickBtn { get; set; }

    private int currency;

    [SerializeField]
    private Text currencyText;


    public int Currency
    {
        get
        {
            return currency;
        }
        set
        {
            this.currency = value;
            this.currencyText.text = value.ToString() + "<color=lime>$</color>";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //set currency
        Currency = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //Run Method
        ZoneBan();
    }
    public void PickTower(Btn_Tower towerBtn)
    {
        //Click towerBottum , can't but when the remaining money is lower
        if (currency >= towerBtn.Money)
        {
            //Click towerButton
            this.ClickBtn = towerBtn;
            //Instance towerSprite follow mouse
            Hover.Instance.Activate(towerBtn.Sprite);           
        }

    }
    public void BuyTower()
    {
        //Buy tower => - Money , - Currency
        if (Currency >= ClickBtn.Money)
        {
            //reduce currency when Click Btntower
            Currency -= ClickBtn.Money;
            //Destory sprite Follow the mouse
            Hover.Instance.Del_Activate();

        }
    }
    private void ZoneBan()
    {
        //deletetower when click
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Destory sprite Follow the mouse
            Hover.Instance.Del_Activate();
        }
    }
}



