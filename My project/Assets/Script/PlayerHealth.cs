using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int LifePoint;
    public int blinks;
    public float time;
    private Renderer myRender;

    // Start is called before the first frame update
    void Start()
    {
        myRender = GetComponent<Renderer>();
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
            Destroy(gameObject);
        }
        BlinkPlayer(blinks,time);
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
