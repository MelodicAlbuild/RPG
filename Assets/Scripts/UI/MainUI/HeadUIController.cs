using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeadUIController : MonoBehaviour
{
    public Player player;

    public Slider healthSlider;
    public TMP_Text healthText;

    public Slider xpSlider;
    public TMP_Text xpText;
    public TMP_Text xpTextLevelCurrent;
    public TMP_Text xpTextLevelNext;

    public StatUIController suiController;
    public GameObject statPanel;

    public GameObject inventoryPanel;

    private void Start()
    {
        // Health
        player.SetMaxHealth(0);
    }

    private void Update()
    {
        // Health
        healthText.text = player.GetCurrentHealth() + " / " + player.GetMaxHealth();
        healthSlider.SetValueWithoutNotify((float)player.GetCurrentHealth() / player.GetMaxHealth());

        // XP
        xpText.text = player.GetCurrentXP() + " / " + player.GetMaxXP();
        xpSlider.SetValueWithoutNotify((float)player.GetCurrentXP() / player.GetMaxXP());
        xpTextLevelCurrent.text = player.GetCurrentLevel().ToString();
        xpTextLevelNext.text = (player.GetCurrentLevel() + 1).ToString();

        // Stats
        suiController.UpdateTexts(player);

        if (Input.GetKeyDown(KeyCode.X))
        {
            statPanel.SetActive(!statPanel.activeInHierarchy);

            if (statPanel.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);

            if (inventoryPanel.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
