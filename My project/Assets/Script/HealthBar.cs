using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text HealthText;
    public static int LifePoint;
    public static int LifeFull;

    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        // LifePoint = LifeFull;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)LifePoint / (float)LifeFull;
        HealthText.text = LifePoint.ToString() + "/" + LifeFull.ToString();
    }
}
