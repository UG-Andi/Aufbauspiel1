using UnityEngine;
using System.Collections;

public class HouseScript : MonoBehaviour {

    //Referenzen
    private TaxManager taxManager;
    private HouseDatabase houseDB;
    private HouseInformation houseInf;

    //Ints
    [Header("Data")]
    public int tier;
    public int placeInList;


    private int tier1Count = 0;
    private int tier2Count = 0;


    //Bools
    public bool isBuilt;

    private bool canUpgradeTo2;         //UPGRADEN DER HÄUSER!
    private bool canUpgradeTo3;

    private bool addToTax;

    private int counter;

    void Awake()
    {
        counter = 0;
        addToTax = false;
        isBuilt = false;

        canUpgradeTo2 = false;
        canUpgradeTo3 = false;

        taxManager = GameObject.FindGameObjectWithTag("Manager").GetComponentInChildren<TaxManager>();
        houseDB = GameObject.Find("HouseDatabase").GetComponent<HouseDatabase>();
        houseInf = GameObject.Find("HouseInformation").GetComponent<HouseInformation>();
    }

    void Update()
    {
        //Steuern erhöhen
        switch (tier)
        {
            case 1:
                if (isBuilt && tier1Count == 0)
                {
                    taxManager.newHousesTier1++;
                    tier1Count++;

                    taxManager.demandOnTrade += houseInf.tradeDemandTier1;
                    taxManager.demandOnIndustry += houseInf.industryDemandTier1;

                    //HouseDB
                    for (int i = 0; i < houseDB.tier1Houses.Count; i++)
                    {
                        if (houseDB.tier1Houses[i] == null)
                        {
                            houseDB.tier1Houses[i] = this.gameObject;
                            if (i + 1 == houseDB.tier1Houses.Count)
                            {
                                houseDB.tier1Houses.Add(null);
                            }
                            break;
                        }
                    }
                }
                break;

            case 2:
                if (isBuilt && tier2Count == 0)
                {
                    taxManager.newHousesTier1--;
                    taxManager.newHousesTier2++;
                    tier2Count++;

                    taxManager.demandOnTrade += houseInf.tradeDemandTier2;
                    taxManager.demandOnIndustry += houseInf.industryDemandTier2;

                    //HouseDB
                    for (int i = 0; i < houseDB.tier2Houses.Count; i++)
                    {
                        if (houseDB.tier2Houses[i] == null)
                        {
                            houseDB.tier2Houses[i] = this.gameObject;
                            if (i + 1 == houseDB.tier2Houses.Count)
                            {
                                houseDB.tier2Houses.Add(null);
                            }
                            break;
                        }
                    }
                }
                break;
        }
        //Upgrading - Stuff:
    }
}
