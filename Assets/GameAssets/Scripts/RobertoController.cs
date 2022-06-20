using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobertoController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float acceleration;
    [SerializeField] Collider swordCollider;

    public bool hasChestKey;
    public bool hasDoorKey;
    float maxSpeed = 8.0f;
    float minSpeed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    public float velocidadCaida;
    CharacterController ccmp;
    Animator anim;
    public int maxHealth = 10;
    public int currentHealth;
    public AudioSource source;
    public AudioClip swordSound;
    public AudioClip hitHobbit;
    public AudioClip stepGrass;


    // Start is called before the first frame update
    void Start()
    {
        minSpeed = speed;
        anim = GetComponent<Animator>();
        ccmp = GetComponent<CharacterController>();
        currentHealth = maxHealth;
        source.playOnAwake = false;
        source.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();

    }
    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool("IsWalking", true);
            if (speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
            }
        }
        else
        {
            speed = minSpeed;
            anim.SetBool("IsWalking", false);
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDirection.Normalize();
            moveDirection.y = velocidadCaida;
            ccmp.Move(moveDirection * speed * Time.deltaTime);
        }

        anim.SetFloat("Speed", speed);
        if (source.clip != stepGrass)
        {
            source.clip = stepGrass;
            source.loop = true;
            source.Play();
        }
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Attack");
            swordCollider.gameObject.SetActive(true);
            source.clip = swordSound;
            source.loop = false;
            source.Play();
        }
        
    }
    void TakenDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            anim.SetBool("isDead", true);
        }
    }

}
