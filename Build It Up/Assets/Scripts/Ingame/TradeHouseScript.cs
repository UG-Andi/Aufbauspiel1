using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TradeHouseScript : MonoBehaviour
{

    //Referenzen
    private TaxManager taxManager;
    private HouseDatabase houseDB;

    //Ints
    [Header("Data")]
    public int tier;
    public int placeInList;

    [Header("Lower Demand")]
    public int lowerDemand;

    //Bools
    public bool isBuilt;
    private bool addToTax;

    private int counter;

    void Awake()
    {
        counter = 0;
        addToTax = false;
        isBuilt = false;

        taxManager = GameObject.FindGameObjectWithTag("Manager").GetComponentInChildren<TaxManager>();
        houseDB = GameObject.Find("HouseDatabase").GetComponent<HouseDatabase>();
    }

    void Update()
    {
        if (isBuilt && counter == 0)
        {
            switch (tier)
            {
                case 1:
                    //Taxes
                    taxManager.demandOnTrade -= lowerDemand;
                    taxManager.newTradeTier1++;
                    counter++;

                    //HouseDB
                    for (int i = 0; i < houseDB.tier1Trade.Count; i++)
                    {
                        if (houseDB.tier1Trade[i] == null)
                        {
                            houseDB.tier1Trade[i] = this.gameObject;
                            if (i + 1 == houseDB.tier1Trade.Count)
                            {
                                houseDB.tier1Trade.Add(null);
                            }
                            break;
                        }
                    }
                    break;
            }

            //Upgrading - Stuff:
        }
    }
}