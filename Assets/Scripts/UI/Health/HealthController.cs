using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Slider healthBar;

    private void Start()
    {
        StartCoroutine(DecreaseHealth());
    }

    private IEnumerator DecreaseHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            healthBar.value -= 0.002f;

            if (healthBar.value == 0)
                break;
        }  
    }
}
