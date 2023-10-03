using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public static int money;
    [SerializeField]
    private int startingMoney;
    void Start()
    {
        money = startingMoney;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int converstScoreToMoney(int score)
    {
        for (int i = 0; i < score; i += 100)
        {
            money++;
        }
        return money;
    }
}
