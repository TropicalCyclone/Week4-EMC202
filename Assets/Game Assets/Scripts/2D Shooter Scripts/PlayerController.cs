using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [SerializeField] public float HitPoints;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] private float fireRate = 0.0f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Weapon weapon;
    private float nextFire = 0.0f;
    
    public HealthBarBehaviour healthBar;
    public ScoreManager score;

    Vector2 moveDirection;
    Vector2 mousePosition;

    private void OnEnable()
    {
        ResumeGame();

        healthBar = GameObject.FindWithTag("UIDisplay").GetComponent<HealthBarBehaviour>();
        score = GameObject.FindWithTag("UIDisplay").GetComponent<ScoreManager>();
        HitPoints = PlayerPrefs.GetFloat("player_HP");
        healthBar.SetHealth(HitPoints, PlayerPrefs.GetFloat("player_HP"));
    }
    void Update()
    {
     
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        /*
        nextFire += Time.deltaTime;

        if (Input.GetMouseButton(0) && nextFire >= fireRate)
        {
            nextFire = 0;
            weapon.Fire();

        }
        */

        moveDirection = new Vector2(moveX, moveY).normalized;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Retry();
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }



    public void TakeHit(float damage)
    {

        HitPoints -= damage;
        healthBar.SetHealth(HitPoints, PlayerPrefs.GetFloat("player_HP"));
        if (HitPoints <= 0)
        {

            gameObject.SetActive(false);
            PauseGame();
            SceneManager.LoadScene("Selection Screen");
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void ResetScore()
    {
        score.ResetScore();
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;

    }
}
    
