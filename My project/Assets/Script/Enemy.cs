using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color orginal_Color;
    public int damge, LifePoint;

    public GameObject BloodEffect;
    private PlayerHealth playerHealth;
    public float flashtime;
    // Start is called before the first frame update
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        orginal_Color = sr.color;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (LifePoint <= 0)
        {
            Destroy(gameObject);
        }
    }

    /*Take Damage*/
    public void TakeDamage(int damge)
    {
        LifePoint -= damge;
        FlashColor(flashtime);
        Instantiate(BloodEffect, transform.position, Quaternion.identity);
        GameController.camShake.Shake();
    }


    //flash how long for input peremeter
    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("Reset_Color", time);
    }

    void Reset_Color()
    {
        sr.color = orginal_Color;
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        /*如果接觸到Tag player 且 collider 是膠囊型判定是玩家*/
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damge);
            }

        }
    }

}
