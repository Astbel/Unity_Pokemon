using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator anim;
    public int LifePoint;
    public int blinks;
    public float time;

    public int dieTime;
    private Renderer myRender;

    // Start is called before the first frame update
    void Start()
    {
        myRender = GetComponent<Renderer>();
        anim =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamagePlayer(int Damage)
    {
        LifePoint -= Damage;
        if (LifePoint <= 0)
        {
            anim.SetTrigger("Die");
            Invoke("KillPlayer",dieTime);
        }
        BlinkPlayer(blinks,time);
    }

    void KillPlayer()
    {
        Destroy(gameObject);
    }
    void BlinkPlayer(int numBlink, float second)
    {
        StartCoroutine(DoBlinks(numBlink,second));
    }

    IEnumerator DoBlinks(int numBlink, float second)
    {
        for (int i = 0; i < numBlink*2; i++)
        {
            myRender.enabled =!myRender.enabled;
            yield return new WaitForSeconds(second);
        }
        myRender.enabled = true;
    }

}
