using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [FormerlySerializedAs("playerHealthData")] [SerializeField] private DataContainer dataContainer;

    private void Start()
    {
        StartCoroutine(DecreaseHealth());
    }

    private IEnumerator DecreaseHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            dataContainer.playerHealth -= 0.002f;
            healthBar.value = dataContainer.playerHealth;

            if (healthBar.value == 0)
                break;
        }  
    }
}
