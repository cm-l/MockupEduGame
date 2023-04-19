using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player, healthBar, phaseScroll;
    public TextMeshPro phaseText;
    public Renderer rndr;
    public Material[] material;
    public AudioClip hurtSound, attackSound, attackTrumpet, defenceTrumpet;

    [SerializeField] private float secondsPerDivider = 1f;
    [HideInInspector] public float reactionTime {get; private set; }
    [HideInInspector] public int actionValue { get; private set; }
    private float time, seconds;
    private int hp = 2, previousValue = 1, dividend;
    private bool playerAttackPhase = true;

    private void Start()
    {
        rndr.material = material[0];
        player = GameObject.FindGameObjectWithTag("Player");
        ChangePhase();
    }

    void Update()
    {
        HandleTime();
    }

    private void HandleTime()
    {
        time = Time.time;

        if (time > reactionTime)
        {
            if (playerAttackPhase == false)
                PlayerDamaged();

            ChangePhase();
        }
    }

    private void Defend(int receivedValue)
    {
        if (receivedValue == actionValue)
        {
            if (--hp < 0) {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                GameProgression.AddLevelsCompleted();
                GameProgression.UpdateGameStage();
                Debug.Log("LevelsCompleted: " + GameProgression.GetLevelsCompleted() + "\n" + "Current stage: " + GameProgression.GetCurrentGameStage());

                switch (GameProgression.GetCurrentGameStage()) {
                    case 1: SceneManager.LoadSceneAsync("EnemyFight_Dungeon1"); break;
                    case 2: SceneManager.LoadSceneAsync("EnemyFight_Dungeon2"); break;
                    case 3: SceneManager.LoadSceneAsync("EnemyFight_Dungeon3"); break;
                    case 4: SceneManager.LoadSceneAsync("TheEnd"); break;
                    default: Debug.Log("Uh"); break;
                }
                // this.gameObject.SetActive(false);
            }

            else
                healthBar.GetComponent<HealthBar>().TakeDamage(hp);
            
            PlaySound(hurtSound);
        }

        ChangePhase();
    }

    private void Attack(int playerDefense)
    {
        if (playerDefense != actionValue)
        {
           PlayerDamaged();
           PlaySound(attackSound);
        }

        ChangePhase();
    }

    private void ChangePhase()
    {
        CalculateValue();
        CalculateReactionTime();

        playerAttackPhase = !playerAttackPhase;

        if (playerAttackPhase == true)
        {
            phaseText.text = "Attack!";
            rndr.material = material[0];
            PlaySound(defenceTrumpet);
        }
        else
        {
            phaseText.text = "Defend!";
            rndr.material = material[1];
            PlaySound(attackTrumpet);
        }

        phaseScroll.SetActive(true);
        Invoke(nameof(DisableScroll), 1f);
    }

    private void CalculateValue()
    {
        previousValue = actionValue == 0 ? 1 : actionValue;

        do
        {
            actionValue = Random.Range(2, 10) * Random.Range(2, 10);
        }
        while (actionValue == previousValue);
    }

    private void CalculateReactionTime()
    {
        seconds = 2f;
        dividend = actionValue;

        for (int div = 2; div <= dividend; div++)
        {
            while (dividend % div == 0)
            {
                seconds += secondsPerDivider;
                dividend /= div;
            }
        }

        reactionTime = Time.time + seconds;
    }

    public void ReceiveCombo(int value)
    {
        if (playerAttackPhase == true)
            Defend(value);
        else
            Attack(value);
    }

    private void PlayerDamaged()
    {
        player.GetComponent<PlayerController>().TakeDamage();
    }

    private void DisableScroll()
    {
        phaseScroll.SetActive(false); 
    }

    private void PlaySound(AudioClip sound)
    {
        SoundSystemSingleton.Instance.PlaySfxSound(sound);
    }

}