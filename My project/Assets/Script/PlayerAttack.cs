using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float time,Starttime;
    public int damge;
    private Animator anim;
    private PolygonCollider2D coli2D;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coli2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            anim.SetTrigger("Attack");
            StartCoroutine(StartAttack());
        }
    }
     IEnumerator StartAttack()
     {
         yield return new WaitForSeconds(Starttime);
         coli2D.enabled = true;
         StartCoroutine(disableHitBox());
     }
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        coli2D.enabled = false;
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damge);
        }
    }
}
