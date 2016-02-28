using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TaxManager : MonoBehaviour {

	//Referenzen
    private IngameManager ingameManager;

    [SerializeField]
    //Floats
    public float cooldown;
    private float timer;

    //Ints
    public int totalTaxes;

    [Header("Tier 1 Houses")]
    public int houseTier1Tax;           //HousesTier1
    public int newHousesTier1;   
    public int housesTier1;
    private int housesTier1TotalTaxes;
 

    [Header("Tier 2 Houses")]
    public int houseTier2Tax;
    public int newHousesTier2;
    public int housesTier2;
    private int housesTier2TotalTaxes;
  

    [Header("Tier 1 Trades")]
    public int tradeTier1Tax;
    public int newTradeTier1; 
    public int tradeTier1;
    private int tradeTier1TotalTaxes;
   

    [Header("Demand on Trade")]
    public int demandOnTrade;
    private Slider tradeSlider;

    [Header("Demand on Industry")]
    public int demandOnIndustry;
    private Slider industrySlider;

    void Start()
    {
        //Referenzen
        ingameManager = GameObject.FindGameObjectWithTag("Manager").GetComponentInChildren<IngameManager>();

        tradeSlider = GameObject.Find("TradeSlider").GetComponent<Slider>();
        industrySlider = GameObject.Find("IndustrySlider").GetComponent<Slider>();

    }

    void Update()
    {
        if (timer <= 0)
        {
            UpdateHouses();
            timer = cooldown;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void UpdateHouses()
    {
                                                                     //House_Tier1
        if (newHousesTier1 != 0)
        {
            housesTier1 += newHousesTier1;
            //Total Tax
            housesTier1TotalTaxes = houseTier1Tax * housesTier1;
        }

                                                                    //House_Tier2
        if (newHousesTier2 != 0)
        {
            housesTier2 += newHousesTier2;
            //Total Tax
            housesTier2TotalTaxes = houseTier2Tax * housesTier2;
        }

                                                                    //Trade_Tier1
        if (newTradeTier1 != 0)
        {
            tradeTier1 += newTradeTier1;
            //Total Tax
            tradeTier1TotalTaxes = tradeTier1Tax * tradeTier1;
        }




        // FINAL calculations
        totalTaxes = housesTier1TotalTaxes + housesTier2TotalTaxes + tradeTier1TotalTaxes;

        ingameManager.money += totalTaxes;
        ingameManager.income = totalTaxes;

        //Resets Taxes
        newHousesTier1 = 0;
        newHousesTier2 = 0;
        newTradeTier1 = 0;
    
    
        // Demand - Managment

        tradeSlider.value = demandOnTrade;
        industrySlider.value = demandOnIndustry;
    
    }
}
