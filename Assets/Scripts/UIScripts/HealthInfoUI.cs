using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI maxHealthText;

    [SerializeField] HealthComponent playerHealthComponent;
    private void OnEnable()
    {
        PlayerEvents.OnHealthInitialized += OnHealthInitialized;
    }

    private void OnDisable()
    {
        PlayerEvents.OnHealthInitialized -= OnHealthInitialized;
    }

    void OnHealthInitialized(HealthComponent healthComponent)
    {
        playerHealthComponent = healthComponent;
    }

    // Update is called once per frame
    void Update()
    {

        healthText.text = playerHealthComponent.CurrentHealth.ToString();
        maxHealthText.text = playerHealthComponent.MaxHealth.ToString();

    }
}
