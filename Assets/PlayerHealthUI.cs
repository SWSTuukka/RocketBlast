using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public GameObject healthLogo;
    private TMP_Text healthText;
    private PlayerController playerController;
    private Animator healthAnimator;

    private void Start()
    {
        healthText = GetComponent<TMP_Text>();
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        healthAnimator = GetComponent<Animator>();
        healthLogo=GameObject.Find("playerhealth");
        
        UpdateHealthUI();
        HideHealthText();
    }
    private void UpdateHealthUI()
    {
        healthText.text = " " + playerController.CurrentHealth.ToString();
    }

    private void Update()
    {
        UpdateHealthUI();
    }
    public void ShowHealthText()
    {
        healthAnimator.SetTrigger("health");
    }

    public void HideHealthText()
    {
        healthAnimator.SetTrigger("health");
    }

    public void OnPlayerTakeDamage()
    {

        healthAnimator.SetTrigger("health");
        ShowHealthText();
        healthLogo.GetComponent<AlphaFade>().fade = true;
    }
}

