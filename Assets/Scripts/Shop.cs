using System;
using UnityEngine;

[System.Serializable]
public class Shop
{
    public int playerMoney = 0;

    // H�m th�m ti?n
    public void AddMoney(int amount)
    {
        playerMoney += amount;
    }
}
