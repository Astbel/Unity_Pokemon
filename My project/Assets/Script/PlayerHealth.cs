using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator anim;
    public int LifePoint;
    public int blinks;
    public float time,hit_player_cd_time;
    public int dieTime;
    private Renderer myRender;
    private ScreenFlash sf;
    private Rigidbody2D rb;
     private PolygonCollider2D Poly;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.LifeFull = LifePoint;
        HealthBar.LifePoint = LifePoint;
        myRender = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
        sf =GetComponent<ScreenFlash>();
        rb =GetComponent<Rigidbody2D>();
        Poly = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamagePlayer(int Damage)
    {
        sf.FlashScreen();
        LifePoint -= Damage;
        if (LifePoint < 0)
        {
            LifePoint = 0;
        }
        HealthBar.LifePoint = LifePoint;
        if (LifePoint <= 0)
        {
            rb.velocity = new Vector2(0,0);
            GameController.isGameAlive =false;
            anim.SetTrigger("Die");
            Invoke("KillPlayer", dieTime);
        }
        BlinkPlayer(blinks, time);
        Poly.enabled =false;
        StartCoroutine(HitplayerBox());
    }

    void KillPlayer()
    {
        Destroy(gameObject);
    }
    void BlinkPlayer(int numBlink, float second)
    {
        StartCoroutine(DoBlinks(numBlink, second));
    }
    IEnumerator DoBlinks(int numBlink, float second)
    {
        for (int i = 0; i < numBlink * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(second);
        }
        myRender.enabled = true;
    }

    IEnumerator HitplayerBox()
    {
        yield return new WaitForSeconds(hit_player_cd_time);
        Poly.enabled =true;
    }

}
