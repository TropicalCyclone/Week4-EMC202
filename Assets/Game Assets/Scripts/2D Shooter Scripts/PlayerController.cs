using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [SerializeField] public float HitPoints;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Weapon weapon;

    private GameObject uiDisplay;
    private EndGameUI endUiDisplay;
    public HealthBarBehaviour healthBar;
    public ScoreManager score;
    public bool isDisabled = false;
    Vector2 moveDirection;
    Vector2 mousePosition;

    private void OnEnable()
    {
        ResumeGame();
        uiDisplay = GameObject.FindWithTag("UIDisplay");
        healthBar = uiDisplay.GetComponent<HealthBarBehaviour>();
        endUiDisplay = uiDisplay.GetComponent<EndGameUI>();
        score = uiDisplay.GetComponent<ScoreManager>();
        HitPoints = PlayerPrefs.GetFloat("player_HP");
        healthBar.SetHealth(HitPoints, PlayerPrefs.GetFloat("player_HP"));
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("isDisabled") == 0)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector2(moveX, moveY).normalized;

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
            FindObjectOfType<AudioManager>().Play("Death");
            gameObject.SetActive(false);
            endUiDisplay.ShowEndScreen();
            
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
    
