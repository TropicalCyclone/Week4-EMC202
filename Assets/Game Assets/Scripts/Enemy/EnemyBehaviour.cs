using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float HitPoints;
    [SerializeField] private float MaxHitPoints = 5f;
    public HealthBarBehaviour healthBar;
    public ScoreManager scoreManager;
    public float speed;
    private Transform Player;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] private Transform Sprite;
    [SerializeField] private float damageTimeout = 1f;
    private bool canTakeDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.FindWithTag("UIDisplay").GetComponent<ScoreManager>();
        HitPoints = MaxHitPoints;
        healthBar.SetHealth(HitPoints, MaxHitPoints);
        Player = GameObject.FindWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            Vector3 direction = Player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            Sprite.rotation = Quaternion.Slerp(Sprite.rotation, q, Time.deltaTime * speed);
            direction.Normalize();
            movement = direction;
        }
    }
    
    public void TakeHit(float damage)
    {
        HitPoints -= damage;
        healthBar.SetHealth(HitPoints, MaxHitPoints);

        if (HitPoints <= 0)
        {
            scoreManager.AddToScore(1);
            gameObject.SetActive(false);       
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
            var player = collision.gameObject.GetComponentInParent<PlayerController>();
            if (canTakeDamage && collision.gameObject.tag == "Player")
            {
                player.TakeHit(1);
                StartCoroutine(damageTimer());
            }

        
    }

    public void ResetHitPoints()
    {
        HitPoints = MaxHitPoints;
        healthBar.SetHealth(HitPoints, MaxHitPoints);
    }

    private IEnumerator damageTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageTimeout);
        canTakeDamage = true;
    }
}

