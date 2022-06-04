using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGold : MonoBehaviour
{

    public static SetGold setgold;

    private void Awake()
    {
        setgold = this;
    }

    public int money = 0;
   public void SetGoldCoins(int ammountofGold)
    {
        money += ammountofGold;
        Debug.Log(money);
        gameObject.GetComponent<Text>().text = money.ToString();
        
    }  

}
