using UnityEngine;
using TMPro;
using System;

public class WeaponController : MonoBehaviour
{
    public Camera playerCam;
    public GameObject playerCamera, currentEnemy, dummyEnemy;
    public GameObject[] directionIndicator, weapon, cooldownIndicator;
    public Animator weaponAnimator;
    private Transform enemyParent;
    public TextMeshProUGUI multiplier, enemyActionValue, timerText;
    [SerializeField] private TextMeshProUGUI[] dirTextBelt;

    [SerializeField] private float lowerLimit = 0.5f, upperLimit = 0.75f, weaponCoolDown = 0.5f;
    private float xDelta, yDelta;
    private int currentWeapon, previousWeapon, currentDamage = 1, nextDamage;
    private readonly int[] VALUES = {2, 3, 5, 7};
    private bool isLookingAtEnemy, isInCoolDown;

    void Start()
    {
        ChangeWeapon(0);
        multiplier.text = currentDamage.ToString();
    }

    void Update()
    {
        HandleInput();
        HandleEnemySelection();
        HandleEnemyIntel();
    }

    private void HandleInput()
    {

        if (isInCoolDown == false)
        {        
            xDelta = playerCamera.GetComponent<CameraController>().xDelta;
            yDelta = playerCamera.GetComponent<CameraController>().yDelta;

            ChangeWeaponWithCamera(xDelta, yDelta);

            if (Input.GetKeyDown(KeyCode.DownArrow))
                ChangeWeapon(0);
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                ChangeWeapon(1);
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                ChangeWeapon(2);
            else if (Input.GetKeyDown(KeyCode.UpArrow))
                ChangeWeapon(3);
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0))
            AttackWrapper(AttackWithWeapon);

        if (Input.GetKeyDown(KeyCode.Mouse1))
            AttackWrapper(EndCombo);

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    currentDamage = 1;
        //    multiplier.text = currentDamage.ToString();
        //}
    }

    private void HandleEnemySelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                currentEnemy = hit.transform.gameObject;
                isLookingAtEnemy = true;
            }
            else
            {
                if (dummyEnemy == null)
                    dummyEnemy = new GameObject();

                currentEnemy = dummyEnemy;
                isLookingAtEnemy = false;
            }
        }
    }

    private void HandleEnemyIntel()
    {
        enemyParent = currentEnemy.transform.parent;

        if (enemyParent != null)
        {
            enemyActionValue.text = enemyParent.GetComponent<EnemyController>().actionValue.ToString();
            timerText.text = (enemyParent.GetComponent<EnemyController>().reactionTime - Time.time).ToString("F0");
        }
    }

    private void ChangeWeapon(int weaponIndex)
    {
        if ((weaponIndex == currentWeapon) || (isInCoolDown == true))
            return;

        StartCoolDown();
        previousWeapon = currentWeapon;
        StartCoolDown();
        Invoke(nameof(EndCoolDown), weaponCoolDown);

        SwitchAnimator();
        weaponAnimator.SetTrigger("TriggerHide");
        dirTextBelt[previousWeapon].color = Color.white;
        directionIndicator[previousWeapon].SetActive(false);
        Invoke(nameof(HideWeapon), weaponCoolDown);

        currentWeapon = weaponIndex;
        nextDamage = VALUES[weaponIndex];

        dirTextBelt[currentWeapon].color = Color.red;
        directionIndicator[currentWeapon].SetActive(true);
        Invoke(nameof(DrawWeapon), weaponCoolDown);
    }

    private void DrawWeapon()
    {
        weapon[currentWeapon].SetActive(true);
        SwitchAnimator();
        weaponAnimator.SetTrigger("TriggerDraw");
    }

    private void HideWeapon()
    {
        weapon[previousWeapon].SetActive(false);
    }

    private void ChangeWeaponWithCamera(float xDelta, float yDelta)
    {
        if ((Math.Abs(xDelta) > lowerLimit && Math.Abs(xDelta) < upperLimit) 
            || (Math.Abs(yDelta) > lowerLimit && Math.Abs(yDelta) < upperLimit))
        {
            // Debug.Log("DeltaX: " + Math.Abs(xDelta) + " DeltaY: " + Math.Abs(xDelta));
            if (xDelta > yDelta)
            {
                if (xDelta > -yDelta)
                    ChangeWeapon(3);
                else if (xDelta < -yDelta) 
                    ChangeWeapon(2);
            }
            else if (yDelta > xDelta)
            {
                if (yDelta > -xDelta)
                    ChangeWeapon(1);
                else if (yDelta < -xDelta)
                    ChangeWeapon(0);
            }
        }
    }

    private void AttackWrapper(Action action)
    {
        if (isInCoolDown == true)
            return;

        StartCoolDown();
        weaponAnimator.SetTrigger("TriggerAttack");

        action();

        Invoke(nameof(EndCoolDown), weaponCoolDown);
    }

    private void AttackWithWeapon()
    {
        if (isLookingAtEnemy == true)
        {
            currentDamage *= nextDamage;
            Mathf.Clamp(currentDamage, 1, 100);
            multiplier.text = currentDamage.ToString();

            if (enemyParent != null)
                if (currentDamage == enemyParent.GetComponent<EnemyController>().actionValue)
                    EndCombo();
        }
    }

    private void EndCombo()
    {
        if (isLookingAtEnemy == true)
        {
            currentEnemy.transform.parent.GetComponent<EnemyController>().ReceiveCombo(currentDamage);
            HandleEnemyIntel();
        }
            
        currentDamage = 1;
        multiplier.text = currentDamage.ToString();
    }

    private void StartCoolDown()
    {
        isInCoolDown = true;
        cooldownIndicator[currentWeapon].SetActive(true);
    }

    private void EndCoolDown()
    {
        isInCoolDown = false;
        cooldownIndicator[currentWeapon].SetActive(false); // disable indicator lock after hit
    }

    private void SwitchAnimator()
    {
        weaponAnimator = weapon[currentWeapon].GetComponent<Animator>();
    }
}