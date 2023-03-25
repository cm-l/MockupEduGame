using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player, healthBar, phaseScroll;
    public TextMeshPro phaseText;
    public Renderer rndr;
    public Material[] material;

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
            if (!playerAttackPhase)
                PlayerDamaged();

            ChangePhase();
        }
    }

    public void Defend(int receivedValue)
    {
        if (receivedValue == actionValue)
        {
            Debug.Log("Sukces!");

            if (--hp < 0)
                this.gameObject.SetActive(false);
            else
                healthBar.GetComponent<HealthBar>().TakeDamage(hp);
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
        previousValue = actionValue == 0 ? 1 : actionValue;

        do
        {
            actionValue = Random.Range(2, 10) * Random.Range(2, 10);
        }
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

        if (playerAttackPhase == true)
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
        if (playerAttackPhase == true)
            Defend(value);
        else
            Attack(value);
    }

    public void PlayerDamaged()
    {
        player.GetComponent<PlayerController>().TakeDamage();
    }

    public void DisableScroll()
    {
        phaseScroll.SetActive(false); 
    }
}