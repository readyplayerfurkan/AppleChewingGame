using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private DataContainer dataContainer;

    private void Start()
    {
        dataContainer.PlayerHealth = 1;
        StartCoroutine(DecreaseHealth());
    }

    private IEnumerator DecreaseHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (healthBar.value != 0)
                dataContainer.PlayerHealth -= 0.002f;
            healthBar.value = dataContainer.PlayerHealth;
        }  
    }
}
