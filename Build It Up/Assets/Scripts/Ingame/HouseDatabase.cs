using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HouseDatabase : MonoBehaviour {

    //Referenzen
    private TaxManager taxManager;

    // Houses
    public List<GameObject> tier1Houses;
    public List<GameObject> tier2Houses;
	
    // Trade
    public List<GameObject> tier1Trade;

    // Industry 
    public List<GameObject> tier1Factory;



    void Start()
    {
        // Referenzen
        taxManager = GameObject.Find("TaxManager").GetComponent<TaxManager>();

        // "Aktiviert" Listen
        tier1Houses.Add(null);
        tier2Houses.Add(null);

        tier1Trade.Add(null);

        tier1Factory.Add(null);
    }

    void Update()
    {

        // HOUSES

        // Tier1
        if (tier1Houses[0] != null)
        {
            for (int x = 0; x < tier1Houses.Count; x++)
            {
                if (tier1Houses[x] != null)
                {
                    GameObject building = tier1Houses[x];
                    building.GetComponent<HouseScript>().placeInList = x;
                }
            }
        }

        // Tier2
        if (tier2Houses[0] != null)
        {
            for (int x = 0; x < tier2Houses.Count; x++)
            {
                if (tier2Houses[x] != null)
                {
                    GameObject building = tier2Houses[x];
                    building.GetComponent<HouseScript>().placeInList = x;
                }
            }
        }

        // TRADE

        // Tier1
        if (tier1Trade[0] != null)
        {
            for (int x = 0; x < tier1Trade.Count; x++)
            {
                if(tier1Trade[x] != null)
                {
                     GameObject building = tier1Trade[x];
                     building.GetComponent<TradeHouseScript>().placeInList = x;
                }
            }
        }
    }
}
