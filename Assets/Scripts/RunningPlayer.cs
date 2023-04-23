using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RunningPlayer : MonoBehaviour {
    public Rigidbody rb;

    [SerializeField] private float speed = 0.5f;
    private float[] lanes = { -2f, 0f, 2f };
    private int currentLane = 1; // 0 = lewa, 1 = środek, 2 = prawa
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
            currentLane--;
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < lanes.Length - 1)
            currentLane++;
    }

    [SerializeField] private float transitionSpeed = 8f;
    private void FixedUpdate() {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 targetPosition = new Vector3(lanes[currentLane], rb.position.y, rb.position.z);
        rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, transitionSpeed * Time.fixedDeltaTime) + forwardMove);
    }

    [SerializeField] private AudioClip goodAnswerSound;
    [SerializeField] private AudioClip wrongAnswerSound;
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Good")) {
            TMPController.addPoint();
            TMPController.changeEquation(EnemySpawner.firstEquationNumberOnMonster, EnemySpawner.resultEquationNumberOnMonster);
            
            SoundSystemSingleton.Instance.PlaySfxSound(goodAnswerSound);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Wrong")) {
            TMPController.substractPoint();
            TMPController.changeEquation(EnemySpawner.firstEquationNumberOnMonster, EnemySpawner.resultEquationNumberOnMonster);

            SoundSystemSingleton.Instance.PlaySfxSound(wrongAnswerSound);
            Destroy(other.gameObject);
        }
    }
}
