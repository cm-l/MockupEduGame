using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player, healthBar, phaseScroll;
    public TextMeshPro phaseText;
    public Renderer rndr;
    public Material[] material;
    public AudioClip hurtSound;

    [SerializeField]
    private float secondsPerDivider = 1f;
    private float reactionTime = 0, time = 0, seconds = 0;
    private int hp = 2, actionValue = 1, previousValue = 1, dividend;
    private bool playerAttackPhase = true;

    private void Start()
    {
        rndr.material = material[0];
        player = GameObject.FindGameObjectWithTag("Player");
        ChangePhase();
    }

    void Update()
    {
        TimeHandler();
    }

    private void TimeHandler()
    {
        time = Time.time;

        if (time > reactionTime)
        {
            if (!playerAttackPhase)
                PlayerDamaged();

            ChangePhase();
        }
    }

    public void Defend(int damage)
    {
        if (damage == actionValue)
        {
            Debug.Log("Sukces!");

            if (--hp < 0)
                this.gameObject.SetActive(false);
            else
                healthBar.GetComponent<HealthBar>().TakeDamage(hp);

            SoundSystemSingleton.Instance.PlaySfxSound(hurtSound);

        }

        ChangePhase();
    }

    public void Attack(int playerDefense)
    {
        if (playerDefense != actionValue)
            PlayerDamaged();

        ChangePhase();
    }

    public void ChangePhase()
    {
        previousValue = actionValue;

        do
            actionValue = Random.Range(2, 10) * Random.Range(2, 10);
        while (actionValue == previousValue);
        
        seconds = 2f;

        dividend = actionValue;

        for (int div = 2; div <= dividend; div++)
            while (dividend % div == 0)
            {
                seconds += secondsPerDivider;
                dividend /= div;
            }

        reactionTime = Time.time + seconds;
        playerAttackPhase = !playerAttackPhase;

        if (playerAttackPhase)
        {
            
            phaseText.text = "Atakuj!";
            rndr.material = material[0];
        }
        else
        {
            phaseText.text = "Broñ siê!";
            rndr.material = material[1];
        }
        
        phaseScroll.SetActive(true);
        Invoke(nameof(DisableScroll), 1f);
    }

    public void ReceiveCombo(int value)
    {
        if (playerAttackPhase)
            Defend(value);
        else
            Attack(value);
    }

    public void PlayerDamaged()
    {
        player.GetComponent<PlayerController>().TakeDamage();
    }

    public float GetReactionTime()
    {
        return reactionTime - time;
    }

    public int GetActionValue()
    {
        return actionValue;
    }

    public void DisableScroll()
    {
        phaseScroll.SetActive(false); 
    }
}