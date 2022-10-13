using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    private int _coins;

    public int Coins => _coins;

    public void AddCoins(int value)
    {
        _coins += value;
    }

    public void RemoveCoins(int value)
    {
        _coins -= value;
    }
}
