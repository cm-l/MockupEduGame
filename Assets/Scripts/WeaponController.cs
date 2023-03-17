using UnityEngine;
using TMPro;
using System;

public class WeaponController : MonoBehaviour
{
    public Camera playerCam;
    public GameObject playerCamera, currentWeaponGO, currentEnemy;
    public GameObject[] directionIndicator, weapon, cooldownIndicator;
    public TextMeshProUGUI multiplier, enemyActionValue, timerText;

    [SerializeField]
    private TextMeshProUGUI[] dirTextBelt;

    [SerializeField]
    private float lowerLimit = 0.5f, upperLimit = 0.75f, weaponCoolDown = 0.75f;
    private float xDelta = 0, yDelta = 0;

    [HideInInspector]
    public int currentWeapon = 2, currentDamage = 1;
    readonly int[] VALUES = {2, 3, 5, 7};
    private bool isLookingAtEnemy = false, isInCoolDown = false;
    Transform enemyParent;

    void Start()
    {
        currentEnemy = new GameObject();
        EnemySelectionHandler();
        currentWeaponGO = weapon[0];
        multiplier.text = currentDamage.ToString();
    }

    void Update()
    {
        EnemySelectionHandler();
        InputHandler();
        UIHandler();
    }

    private void InputHandler()
    {
        xDelta = playerCamera.GetComponent<CameraController>().xDelta;
        yDelta = playerCamera.GetComponent<CameraController>().yDelta;
        if (!isInCoolDown)
            ChangeWeaponWithCamera(xDelta, yDelta);

        if (Input.GetKeyDown(KeyCode.DownArrow) && !isInCoolDown)
            ChangeWeapon(0);
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isInCoolDown)
            ChangeWeapon(1);
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !isInCoolDown)
            ChangeWeapon(2);
        else if (Input.GetKeyDown(KeyCode.UpArrow) && !isInCoolDown)
            ChangeWeapon(3);
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0))
            AttackWrapper(AttackWithWeapon);
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentDamage = 1;
            multiplier.text = currentDamage.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
            AttackWrapper(EndCombo);
    }

    private void EnemySelectionHandler()
    {
        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);

        

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                currentEnemy = hit.transform.gameObject;
                isLookingAtEnemy = true;
            }
            else
                isLookingAtEnemy = false;
        }
    }

    private void UIHandler()
    {
        enemyParent = currentEnemy.transform.parent;

        if (enemyParent != null)
        {
            enemyActionValue.text = enemyParent.GetComponent<EnemyController>().GetActionValue().ToString();
            timerText.text = enemyParent.GetComponent<EnemyController>().GetReactionTime().ToString("F0");
        }
    }

    public void ChangeWeapon(int i)
    {
        currentWeapon = VALUES[i];
        for (int j = 0; j < 4; j++)
        {
            dirTextBelt[j].color = Color.white;
            directionIndicator[j].SetActive(false);
            weapon[j].SetActive(false);
            // currentWeaponGO.GetComponent<Animator>().SetTrigger("TriggerHide");

            if (j == i)
            {
                dirTextBelt[j].color = Color.red;
                directionIndicator[j].SetActive(true);

                currentWeaponGO = weapon[j];
                currentWeaponGO.SetActive(true);
                // currentWeaponGO.GetComponent<Animator>().SetTrigger("TriggerDraw");
            }
        }
    }

    public void ChangeWeaponWithCamera(float xDelta, float yDelta)
    {
        if ((Math.Abs(xDelta) > lowerLimit && Math.Abs(xDelta) < upperLimit) 
            || (Math.Abs(yDelta) > lowerLimit && Math.Abs(yDelta) < upperLimit))
        {
            Debug.Log("DeltaX: " + Math.Abs(xDelta) + " DeltaY: " + Math.Abs(xDelta));
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

    public void AttackWrapper(Action action)
    {
        isInCoolDown = true;
        cooldownIndicator[Array.IndexOf(VALUES, currentWeapon)].SetActive(true);
        currentWeaponGO.GetComponent<Animator>().SetTrigger("TriggerAttack");

        action();

        Invoke(nameof(EndCoolDown), weaponCoolDown);
    }

    public void AttackWithWeapon()
    {
        if (isLookingAtEnemy)
        {
            currentDamage *= currentWeapon;
            multiplier.text = currentDamage.ToString();

            if (enemyParent != null)
                if (currentDamage == enemyParent.GetComponent<EnemyController>().GetActionValue())
                    AttackWrapper(EndCombo);
            
        }
    }

    public void EndCombo()
    {
        if (isLookingAtEnemy)
            currentEnemy.transform.parent.GetComponent<EnemyController>().ReceiveCombo(currentDamage);

        currentDamage = 1;
        multiplier.text = currentDamage.ToString();
    }

    public void EndCoolDown()
    {
        isInCoolDown = false;
        cooldownIndicator[Array.IndexOf(VALUES, currentWeapon)].SetActive(false);
    }
}