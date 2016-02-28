﻿using UnityEngine;
using System.Collections;

public class BuildingPlacement : MonoBehaviour {

    private PlaceableBuildings placeableBuilding;
    private PlaceableBuildings placeableBuildingOld;
<<<<<<< HEAD
    private BuildingManager buildingManager;
    private Transform currentBuilding;
    private bool hasPlaced;

    public LayerMask buildingsMask;

    void Start()
    {
        buildingManager = GetComponent<BuildingManager>();
=======
    private GameObject placedObject;
    private BuildingManager buildingManager;
    private Transform currentBuilding;
    public bool hasPlaced;
    public float fieldQuotient;

    public LayerMask buildingsMask;

    private int number;
    private int Wohnwagen;
    private int Wohnhaus;
    private int Store;

    void Start()
    {
        buildingManager = GetComponent<BuildingManager>();
        hasPlaced = true;
        Wohnwagen = 1;
        Wohnhaus = 1;
        Store = 1;
>>>>>>> origin/master
    }

	void Update ()
    {
        Vector3 m = Input.mousePosition;
        m = new Vector3(m.x, m.y, transform.position.y);
        Vector3 p = GetComponent<Camera>().ScreenToWorldPoint(m);

        if (currentBuilding != null && !hasPlaced)
        {
<<<<<<< HEAD
            currentBuilding.position = new Vector3(Mathf.Round(p.x / 1) * 1, 0, Mathf.Round(p.z / 0.4f) * 0.4f);
=======
            currentBuilding.position = new Vector3(Mathf.Round(p.x / fieldQuotient) * fieldQuotient, 0, Mathf.Round(p.z / fieldQuotient) * fieldQuotient);
>>>>>>> origin/master

            if (Input.GetMouseButtonDown(0))
            {
                if (IsLegalPosition())
                {
<<<<<<< HEAD
                    hasPlaced = true;
                    buildingManager.baumenüActive = true;  
                    placeableBuilding.isPlaced = true;               
=======
                    placedObject = currentBuilding.gameObject;
                    hasPlaced = true;
                    placeableBuilding.isPlaced = true;
                    buildingManager.baumenüActive = true;
                    RenameObject();        
>>>>>>> origin/master
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 rayVector = p - transform.position;
                RaycastHit hit = new RaycastHit();
                Ray ray = new Ray(new Vector3(p.x, p.y, p.z), rayVector);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, buildingsMask))
                {
                    if (placeableBuildingOld != null)
                    {
                        placeableBuildingOld.SetSelected(false);
                    }
                    hit.collider.gameObject.GetComponent<PlaceableBuildings>().SetSelected(true);
                    placeableBuildingOld = hit.collider.gameObject.GetComponent<PlaceableBuildings>();
                }

                else
                {
                    if (placeableBuildingOld != null)
                    {
                        placeableBuildingOld.SetSelected(false);
                    }
                }
            }
        }
	}

    bool IsLegalPosition()
    {
        if (placeableBuilding.colliders.Count > 0)
        {
            return false;
        }
        return true;
    }

    public void SetItem(GameObject b)
    {
        hasPlaced = false;
        currentBuilding = ((GameObject)Instantiate(b)).transform;
        placeableBuilding = currentBuilding.GetComponent<PlaceableBuildings>();
    }
<<<<<<< HEAD
=======

    void RenameObject ()
    {
        switch (buildingManager.buttonIndex)
        {
            case 1: number = Wohnwagen;
                    Wohnwagen++;
                break;

            case 2: number = Wohnhaus;
                    Wohnhaus++;
                break;

            case 101: number = Store;
                      Store++;
                break;
        }

        string numberOfTypeOfBuilding = number.ToString();
        placedObject.name = placedObject.name.Replace("(Clone)", " " + numberOfTypeOfBuilding);
    }
>>>>>>> origin/master
}
