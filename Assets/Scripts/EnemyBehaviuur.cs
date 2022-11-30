using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyBehaviuur : MonoBehaviour
{
    //SO reference
    public SO_Enemy enemyScriptableObject;

    //Damage via SO ref
    public int damageCapability;

    //Updated value of enemy
    public int currentNumber;

    //Display damageNumber
    public TextMeshPro displayedNumber;

    //Has the battle been won by the player?
    public bool isEnemyDead = false;

    //Music theme
    private AudioClip musicTheme;

    //Win noise
    [SerializeField] private AudioClip victorySfx;

    //Damage noise
    private AudioClip damageSfx;

    private void Awake()
    {
        displayedNumber = transform.GetChild(0).GetComponent<TextMeshPro>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Set damage to damage (very smart)
        damageCapability = enemyScriptableObject.damage;

        //Set to starting damageNumber once encounter starts
        currentNumber = enemyScriptableObject.startingNumber;

        //Set music theme and play it immidietly
        musicTheme = enemyScriptableObject.enemyMusicTrack;
        playEnemyMusicTheme(musicTheme);

        //Set attack sound
        damageSfx = enemyScriptableObject.enemyAttackSound;

        //Set the sprite to scriptable object sprite
        gameObject.GetComponent<MeshRenderer>().material = enemyScriptableObject.enemySpriteMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        //Set display to what is the actual value
        displayedNumber.SetText(currentNumber.ToString() + "/" + enemyScriptableObject.startingNumber);

        //For testing
        if (Input.GetKeyDown(KeyCode.L)) {
            changeValueByCard(2f, OffensiveAction.multiplyByNumber);
        }

        //Victory
        enemyDeath();
    }


    public void enemyDeath()
    {
        if (currentNumber <= 0 && !isEnemyDead)
        {
            SoundSystemSingleton.Instance.StopTheMusic();
            SoundSystemSingleton.Instance.PlaySfxSound(victorySfx);
            isEnemyDead = true;
        }
    }

    public void changeValueByCard(float amount, OffensiveAction operand)
    {
        //Dodawanie/odejmowanie
        if (operand == OffensiveAction.dealDamage)
        {
            currentNumber =   Mathf.RoundToInt(currentNumber - amount);
        }

        //Mno¿enie/dzielenie
        if (operand == OffensiveAction.multiplyByNumber)
        {
            currentNumber = Mathf.RoundToInt(currentNumber * amount);
        }

        //Potêgowanie/pierwiastkowanie
        if (operand == OffensiveAction.raiseToPowerOfNumber)
        {
            currentNumber = Mathf.RoundToInt(Mathf.Pow(currentNumber, amount));
        }

        //Tu doda siê jak¹œ logikê z dŸwiêkami, animacj¹ (np. jakiœ screenshake?)
        // numberDisplay.getcomponent<anim>().blablablabl
    }

    // FUNKCJE ZACHOWAÑ
    // Zgodnie z sugesti¹ na spotkaniu kó³ka, przeciwnicy powinni mieæ kilka zachowañ
    // Np. podzielenie siê przez n, dodanie do siebie n, pomno¿enie siê przez -1
    // ale najbardziej podstawowym (i najprostszym do zaprogramowania) zachowaniem jest atak

    public void enemyActionAttack()
    {
        ManagerSingleton.Instance.playerCurrentHealth -= damageCapability;
        SoundSystemSingleton.Instance.PlaySfxSound(damageSfx);
    }

    public void halfWayThere()
    {
        currentNumber = Mathf.RoundToInt(currentNumber / 2);
    }

    public void playEnemyMusicTheme(AudioClip theme)
    {
        SoundSystemSingleton.Instance.PlayMusicSound(theme);
    }
}
