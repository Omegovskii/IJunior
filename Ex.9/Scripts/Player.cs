using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider HealthBar;

    private float HealthPoint = 100f;

    public void TakeDamage(float damage)
    {
        if(HealthPoint > HealthBar.minValue)
        {
            HealthPoint -= damage;
        }
        
        if(HealthPoint < HealthBar.minValue)
        {
            HealthPoint = 0;
        }

        StartCoroutine(UpdateHealthBar());
    }

    public void UseFirstAidKit(float healthPoint)
    {
        if (HealthPoint < HealthBar.maxValue)
        {
            HealthPoint += healthPoint;
        }

        if (HealthPoint > HealthBar.maxValue)
        {
            HealthPoint = 0;
        }

        StartCoroutine(UpdateHealthBar());
    }

    private IEnumerator UpdateHealthBar()
    {
        float speed = 7f;

        while (HealthBar.value != HealthPoint)
        {
            HealthBar.value = Mathf.MoveTowards(HealthBar.value, HealthPoint, speed*Time.deltaTime);

            yield return null;
        }
    }
}
