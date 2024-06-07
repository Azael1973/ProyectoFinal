using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subitems : MonoBehaviour
{
    public Text subItemsText;
    public int subItemsAmount;

    public static Subitems instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        subItemsText.text = "x " + subItemsAmount.ToString();
    }

    public void SubItem(int subItemAmount)
    {
        subItemsAmount += subItemAmount;
        subItemsText.text = "x " + subItemsAmount.ToString();
    }
}
