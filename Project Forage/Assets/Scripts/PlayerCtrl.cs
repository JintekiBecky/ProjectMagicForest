using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public float playerSpeed = 4;
    public float walkSpeed = 4;
    public float sprintSpeed;

    Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    [Header("Sprint")]
    public bool sprintRecovery = false;

	public float maxStamina = 100f;
	public float currentStamina;
	public float staminaConsumption = 1f;
	public float recoveryRate = 0.25f;

    public Image bar;
    public GameObject sweat;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprintSpeed = playerSpeed * 2f;
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        Sprint();
		SetHealthBar();
        sprintBarRefill();
        PassiveRecovery();
	}

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }

    private void Sprint()
    {
       if (sprintRecovery == false)
        {
            if(currentStamina > 0)
            {
			    if (Input.GetKey(KeyCode.JoystickButton4))
			    {
				    playerSpeed = sprintSpeed;
				    currentStamina -= staminaConsumption;
				    Debug.Log(currentStamina);
			    }
		    }

            if (Input.GetKeyUp(KeyCode.Joystick1Button4))
            {
                playerSpeed = walkSpeed;
            }
        }

    }
	private void SetHealthBar()
	{
		bar.fillAmount = currentStamina / 100;
	}
    
    private void sprintBarRefill()
    {
        if (currentStamina < 0)
        {
            playerSpeed = walkSpeed;
            sprintRecovery = true;
            sweat.SetActive(true);
        }


        if(sprintRecovery)
        {
            for (int i = 0; i < maxStamina; i++)
            {
                currentStamina += staminaConsumption *Time.deltaTime;            
                if (currentStamina >= maxStamina)
                    {
                        currentStamina = maxStamina;
                        sprintRecovery = false;
                        sweat.SetActive(false);
                    }
            }

        }
    }

    private void PassiveRecovery()
    {
        if(!Input.GetKey(KeyCode.Joystick1Button4))
        {
            if (sprintRecovery == false)
            {
				for (int i = 0; i < maxStamina; i++)
                {
                    if(currentStamina < maxStamina)
                    {
						currentStamina += recoveryRate * Time.deltaTime;
					}
                    else
                    {
                        currentStamina = maxStamina;
                    }

                }

			}
        }
    }
}
