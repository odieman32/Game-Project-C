using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private RectTransform bar;
    private Image barImage;

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<RectTransform>();
        barImage = GetComponent<Image>();
        Health.totalHealth = 1f;
    }

    public void Damage(float damage)
    {
        //if the scale of the healthbar is greater than 0 then player takes damage
        if ((Health.totalHealth -= damage) >= 0f)
        {
            Health.totalHealth -= damage;
        }
        else
        {
            Health.totalHealth = 0f;
        }
        //if health bar is below 0.3 scale then the bar turns red
        if(Health.totalHealth < 0.3f)
        {
            barImage.color = Color.red;
        }
        SetSize(Health.totalHealth);

    }

    public void SetSize(float size)
    {
        //size of healthbar
        bar.localScale = new Vector3(size, 1f);
    }    
}
