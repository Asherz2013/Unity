﻿using UnityEngine;
    public GameObject LandingAreaPrefab;

    // Use this for initialization
    void Start()
    {
        Invoke("DropFlare", 3f);
    }
    {
        //Drop a flare
        Instantiate(LandingAreaPrefab, transform.position, transform.rotation);
    }