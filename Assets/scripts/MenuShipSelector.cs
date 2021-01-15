using UnityEngine;
using UnityEngine.UI;

public class MenuShipSelector : MonoBehaviour
{
    public Sprite[] shipsSprites;
    public GameObject SelectedShip;

    private void Start()
    {
        //SPAWN ALIEN SHIP
        if (PlayerPrefs.GetInt("alienship") == 1)
        {
            SelectedShip.GetComponent<Image>().sprite = shipsSprites[2];
        }
        //SPAWN SPACE SHIP
        else if (PlayerPrefs.GetInt("spaceship") == 1)
        {
            SelectedShip.GetComponent<Image>().sprite = shipsSprites[0];
        }
        //SPAWN ROCKET SHIP
        else if (PlayerPrefs.GetInt("rocketship") == 1)
        {
            SelectedShip.GetComponent<Image>().sprite = shipsSprites[1];
        }
        else
        {
            SelectedShip.GetComponent<Image>().sprite = shipsSprites[0];
        }
        
    }

    public void RightButton()
    {
        Sprite oldSprite = SelectedShip.GetComponent<Image>().sprite;
        // IF OLDSPRITE == Spaceship
        if (oldSprite == shipsSprites[0])
        {
            SelectedShip.GetComponent<Image>().sprite = shipsSprites[1];
            PlayerPrefs.SetInt("spaceship",0);
            PlayerPrefs.SetInt("rocketship",1);
        }
        // IF OLDSPRITE == rocketship
        else if (oldSprite == shipsSprites[1])
        {
            SelectedShip.GetComponent<Image>().sprite = shipsSprites[2];
            PlayerPrefs.SetInt("rocketship",0);
            PlayerPrefs.SetInt("alienship",1);
        }
        // IF OLDSPRITE == alienship
        else if (oldSprite == shipsSprites[2])
        {
            SelectedShip.GetComponent<Image>().sprite = shipsSprites[0];
            PlayerPrefs.SetInt("alienship",0);
            PlayerPrefs.SetInt("spaceship",1);
        }
        
        
    }

    public void LeftButton()
    {
        Sprite oldSprite = SelectedShip.GetComponent<Image>().sprite;
        // IF OLDSPRITE == Spaceship
        if (oldSprite == shipsSprites[0])
        {
            SelectedShip.GetComponent<Image>().sprite = shipsSprites[2];
            PlayerPrefs.SetInt("spaceship",0);
            PlayerPrefs.SetInt("alienship",1);
        }
        // IF OLDSPRITE == rocketship
        else if (oldSprite == shipsSprites[1])
        {
            SelectedShip.GetComponent<Image>().sprite = shipsSprites[0];
            PlayerPrefs.SetInt("rocketship",0);
            PlayerPrefs.SetInt("spaceship",1);
        }
        // IF OLDSPRITE == alienship
        else if (oldSprite == shipsSprites[2])
        {
            SelectedShip.GetComponent<Image>().sprite = shipsSprites[1];
            PlayerPrefs.SetInt("alienship",0);
            PlayerPrefs.SetInt("rocketship",1);
        }
    }
    
    

    
}
