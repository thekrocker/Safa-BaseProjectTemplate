using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyTester : MonoBehaviour
{
    public float currency;
    void Update()
    {
        Debug.Log(currency.ToCurrency());
    }
}