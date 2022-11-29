using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSingleton : MonoBehaviour
{
    //Player variables
    public int playerCurrentHealth;

    //To bêdzie trzeba du¿o testowaæ, wpisujê 30 bo takie jest w Hearthstone i jakoœ dzia³a
    public int playerMaxHealth = 30;

    //PLACEHOLDER
    [SerializeField] private GameObject deathMessage;


    public static ManagerSingleton Instance { get; private set; }

    private void Awake()        
    {
        // start of singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        // end of singleton pattern
    }



    // Start is called before the first frame update
    void Start()
    {
        //Player starts at full health
        playerCurrentHealth = playerMaxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        //Dying logic
        if (playerCurrentHealth <= 0)
        {
            playerDeath();
        }
    }


    public void playerDeath()
    {
        //PLACEHOLDER
        //Display the death screen and message
        deathMessage.SetActive(true);
    }

    public void Heal(int healedAmount)
    {
        //Restore a set amount of health
        playerCurrentHealth += healedAmount;

        //Do not allow overheal
        if (playerCurrentHealth > playerMaxHealth) {
            playerCurrentHealth = playerMaxHealth;
        }
    }
}
