using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private Bank _bank;

    private void Start()
    {
        _bank.GetComponent<Bank>();
    }
}
