using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSingleton : MonoBehaviour
{

    [Header("Player Stats")]
    //Player variables - how much health
    public int playerCurrentHealth;

    //To bêdzie trzeba du¿o testowaæ, wpisujê 30 bo takie jest w Hearthstone i jakoœ dzia³a
    public int playerMaxHealth = 30;

    //Ile mia³ HP zaczynaj¹c i koñcz¹c turê? Mo¿e potem siê przydaæ do kart/itemów
    public int startedTurnWithHealth;
    public int endedTurnWithHealth;
    public int preBlockHealth;
    public bool hasBlockedAlready;

    //Blockade
    public int playerBlockade = 0;

    //Mana/resource to play cards
    public int manaCurrentPoints;
    public int manaMaxPoints = 3;

    //Gold
    public int playerGold = 40;

    [Header("\nLevel status and scenes")]
    // Next enemy encounter
    public SO_Enemy nextEncounteredEnemy;

    // Next encounter (minigame?)
    //encounter int in build order???

    [Header("\nGame Over Settings")]
    //PLACEHOLDER
    public GameObject deathMessage;
    [SerializeField] private AudioClip deathSfx;
    public bool hasDied = false;

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

        // Grab death message panel
        deathMessage = GameObject.FindGameObjectWithTag("Death Screen");
    }



    // Start is called before the first frame update
    void Start()
    {
        //And at full mana
        //DEPRECATED this is now handled by the refiller object
        //manaCurrentPoints = manaMaxPoints; 


        //Ten obiekt zachowuje siê miêdzy scenami: jego "Start" to pierwsza scena
        //Wiêc ¿eby resetowaæ manê co ka¿dy pojedynek, u¿ywam do tego innego obiektu z metod¹ w starcie
        //TODO kiedyœ to poprawiæ


        //Player starts at full health
        playerCurrentHealth = playerMaxHealth;

        startedTurnWithHealth = playerCurrentHealth;

        preBlockHealth = playerCurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {

        //Dying logic
        if (playerCurrentHealth <= 0 && !hasDied)
        {
            playerDeath();
        }
    }


    public void takeDamage(int damage)
    {
        playerCurrentHealth -= damage;
    }

    public void playerDeath()
    {
        //Kill player
        hasDied = true;

        //PLACEHOLDER
        // TO TRZEBA ZMIENIÆ ¯EBY ROBI£O INSTANTIATE(UI JAKIŒ TAM GAME OVER SCREEN)!!!!!!!!!
        //Display the death screen and message
        //deathMessage.SetActive(true);
        //deathMessage.transform.localScale = new Vector3(4, 4, 4);

        //Play death sound effect
        SoundSystemSingleton.Instance.PlaySfxSound(deathSfx);

        //Make the music go down in pitch maybe?
        SoundSystemSingleton.Instance.ChangeMusicPitch(0.36f);
    }

    public void Heal(int healedAmount)
    {
        //Restore a set amount of health
        playerCurrentHealth += healedAmount;

        //Do not allow overheal
        if (playerCurrentHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
    }

    public void Barricade(int barricadeAmount)
    {
        // Same as healing but allow for overheal
        playerCurrentHealth += barricadeAmount;
    }

    public void Block(int blockAmount)
    {
        GameObject.Find("Enemy").GetComponent<EnemyBehaviuur>().damageCapability -= blockAmount;
    }

    public void ActivateDefensiveActionFromCard(int barricade, int block, int heal)
    {
        if (barricade != 0)
        {
            Barricade(barricade);
        }

        if (block != 0)
        {
            Block(block);
        }

        if (heal != 0)
        {
            Heal(heal);
        }
    }

    public void ActivateSpecialActionFromCardOnPlayer(int draw, int sacrifice, int pay)
    {
        if (draw != 0)
        {
            Debug.Log($"Drawn {draw} cards!");
        }

        if (sacrifice != 0)
        {
            takeDamage(sacrifice);
        }

        if (pay != 0)
        {
                spendGold(pay);
        }
    }

    public void consumeMana(int amount)
    {
        manaCurrentPoints -= amount;
    }

    public void gainGold(int amount)
    {
        playerGold += amount;
    }

    public void spendGold(int amount)
    {
        playerGold -= amount;
    }
}
