using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Weapon weapon;
    private float nextFire = 0.0f;
    [SerializeField] private float fireRate = 0.0f;

    Vector2 moveDirection;
    Vector2 mousePosition;

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

    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}
