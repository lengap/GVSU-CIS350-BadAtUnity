using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

//This is the player character, which is controlled by the user
public class Player : MonoBehaviour
{
    //variables
    public HealthBar healthBar;
    public Animator animator;
    public GameObject deathEffect;
    
    //public int respawn;
    public int battery;
	public bool canShoot = true;
    public ammoBar ammoBar;
    public int health;
    private int maxHealth = 100;
    
    public bool facingRight = true;
    private bool activeShield;
    private bool activeDamage;
    float speed = 3.0f;
    private float horizontal;
    private float vertical;
    
    Rigidbody2D rb;

    // Start is called before the first frame update
    //Instantiates the player, along with beginning health & ammunition
    void Start()
    {
		health = PlayerPrefs.GetInt("PlayerCurrHealth");
		battery = PlayerPrefs.GetInt("PlayerCurrAmmo");
        ammoBar.SetMaxAmmo(PlayerPrefs.GetInt("PlayerCurrAmmo"));
        rb = GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(PlayerPrefs.GetInt("PlayerCurrHealth"));
        activeShield = false;
        activeDamage=false;
    }

    // Update is called once per frame
    //Logic looks for conditions on which to perform an action, i.e.: moving, shooting
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
		animator.SetBool("Hurt", false);
        if(horizontal==0)
        {
            animator.SetFloat("Speed", Mathf.Abs(vertical));
        }

	    //flips character based on movement
        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }

        //flips character based on movement
        else if (horizontal < 0 && facingRight)
        {
            Flip();
        }

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);

        //if player has ammunition, and "Fire1"/Spacebar is pressed, then shoot
		if(battery > 0){
			if(Input.GetButtonDown("Fire1") && canShoot)
			{
				if(battery > 0)
				{
					battery -= 1;
					PlayerPrefs.SetInt("PlayerCurrAmmo", battery);
					ammoBar.SetAmmo(battery);
				} 
				else
				{
					canShoot = false;
				}
			}
        }
    }

    //function flips player in order to shoot and face the correct direciton
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    //increases batter/ammo if player pickups battery object
    public void incBattery()
    {
        //each battery pickup incremenets ammunition by 25 
        battery = battery + 25;
		canShoot = true;
		PlayerPrefs.SetInt("PlayerCurrAmmo", battery);
        ammoBar.SetAmmo(battery);
    }

    //Function is called when player is hit by an enemy, or landmine.  Lowers health of player
    public void TakeDamage(int damage)
    {
        //if chield powerup is not active, take damaga as usual
        if (activeShield == false)
        {

            health -= damage;
			PlayerPrefs.SetInt("PlayerCurrHealth", health);
            healthBar.SetHealth(health);
            animator.SetBool("Hurt", true);

            //If player dies, game over
            if (health <= 0)
            {
                SceneManager.LoadScene("Loss");
            }
        }
    }
    //Function increments player health when player pickups health object.  Incremenets by parameter "damage" amount
	public void HealDamage(int damage)
    {
        health += damage;
		PlayerPrefs.SetInt("PlayerCurrHealth", health);
        healthBar.SetHealth(health);
    }
    
    //Function sets hurt animation
    public void recovered()
    {
        animator.SetBool("Hurt", false);
    }

    //Function for activating shield powerup
    public void activateShield()
    {
        activeShield = true;
    }
	
    //Function for deactivating shield powerup
	public void deactivateShield()
    {
        activeShield = false;
    }

    //Function activates and deactvates player taking damage
    public void activateDamage()
    {
        if(activeDamage  == false)
        {
            activeDamage = true;
        }

        else
        {
            activeDamage = false;
        }
        
    }
}
