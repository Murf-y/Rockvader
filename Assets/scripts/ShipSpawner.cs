using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject[] spaceShips;
    void Start()
    {
        //SPAWN ALIEN SHIP
        if (PlayerPrefs.GetInt("alienship") == 1)
        {
            Instantiate(spaceShips[0], transform.position, quaternion.identity);
        }
        //SPAWN SPACE SHIP
        else if (PlayerPrefs.GetInt("spaceship") == 1)
        {
            Instantiate(spaceShips[1], transform.position, quaternion.identity);
        }
        //SPAWN ROCKET SHIP
        else if (PlayerPrefs.GetInt("rocketship") == 1)
        {
            Instantiate(spaceShips[2], transform.position, quaternion.identity);
        }
        //SPAWN THE DEFAULT SHIP
        else
        {
            Instantiate(spaceShips[1], transform.position, quaternion.identity);
        }
        
    }

   
}
