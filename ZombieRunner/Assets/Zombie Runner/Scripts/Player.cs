using UnityEngine;using System.Collections;public class Player : MonoBehaviour{    public Transform playerSpawnPoints;
    public GameObject LandingAreaPrefab;    private Transform[] spawnPoints;    private bool lastRespawnToggle = false;    private bool reSpawn = false;

    // Use this for initialization
    void Start()    {        spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();    }    // Update is called once per frame    void Update()    {        if(lastRespawnToggle != reSpawn)        {            Respawn();            reSpawn = false;        }        else        {            lastRespawnToggle = reSpawn;        }    }    private void Respawn()    {        int i = Random.Range(1, spawnPoints.Length);        transform.position = spawnPoints[i].transform.position;    }    void OnFindClearArea()
    {
        Invoke("DropFlare", 3f);
    }    void DropFlare()
    {
        //Drop a flare
        Instantiate(LandingAreaPrefab, transform.position, transform.rotation);
    }}