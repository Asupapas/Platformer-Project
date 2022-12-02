using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlatformer : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1.0f;
    [SerializeField]
    float jumpSpeed = 1.0f;
    bool grounded = false;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    [SerializeField]
    float jumpcharge = 2.0f;
    [SerializeField]
    private InputActionReference movement, attack, pointerPosition;
    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
    }
    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = movement.action.ReadValue<Vector2>();
        Vector2 velocity = rb.velocity;
        velocity.x = moveX * moveSpeed;
        rb.velocity = velocity;
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            animator.SetTrigger("Jump");
        }
        if (rb.velocity.y < -0.1f && !grounded)
        {
            animator.SetTrigger("Fall");
        }

        animator.SetFloat("xInput", moveX);
        animator.SetBool("grounded", grounded);
        if (moveX < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveX > 0)
        {
            spriteRenderer.flipX = false;
        }
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumpcharge = 2;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            rb.AddForce(new Vector2(0, 100 * 7));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void PerformAttack(InputAction.CallbackContext obj)
    {
        if (WeaponParent == null)
        {
            Debug.LogError("Weapon parent is null", gameObject);
            return;
        }
        WeaponParent.PerformAnAttack();
    }
    private void Awake()
    {
        weaponParent = GetComponentInChildren<WeaponParent>();
        angentAnimations = GetComponentInChildren<AgentParent>
    }
    private void AnimateCharacter()
    {
        Vector2 lookDirection = PointerInput - (Vector2)transform.position;
        if (weaponParent.WeaponRotationStopped == false)
            agentAnimations.RotateToPointer(lookDirection);
        agentAnimations.PlayAnimation(movementInput);
    }
}
