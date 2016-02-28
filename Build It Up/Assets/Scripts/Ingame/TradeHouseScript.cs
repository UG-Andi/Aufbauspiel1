using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> origin/master

public class TradeHouseScript : MonoBehaviour
{

<<<<<<< HEAD
    //Referenzen
    private TaxManager taxManager;
    private HouseDatabase houseDB;

    //Ints
    [Header("Data")]
    public int tier;
    public int placeInList;

    [Header("Lower Demand")]
    public int lowerDemand;
=======
	//Referenzen
    private TaxManager taxManager;

    //Ints
    public int tier;
>>>>>>> origin/master

    //Bools
    public bool isBuilt;
    private bool addToTax;

    private int counter;

    void Awake()
    {
        counter = 0;
        addToTax = false;
        isBuilt = false;
<<<<<<< HEAD

        taxManager = GameObject.FindGameObjectWithTag("Manager").GetComponentInChildren<TaxManager>();
        houseDB = GameObject.Find("HouseDatabase").GetComponent<HouseDatabase>();
=======
        taxManager = GameObject.FindGameObjectWithTag("Manager").GetComponentInChildren<TaxManager>();

        tier = 1;
>>>>>>> origin/master
    }

    void Update()
    {
        if (isBuilt && counter == 0)
        {
<<<<<<< HEAD
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
=======
            taxManager.newTradeTier1++;
            counter++;
        }

        //Upgrading - Stuff:
    }
}
>>>>>>> origin/master
