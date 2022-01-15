using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatUIController : MonoBehaviour
{
    public TMP_Text attackText;
    public TMP_Text speedText;
    public TMP_Text healthText;
    public TMP_Text defenseText;
    public TMP_Text intelectText;
    public TMP_Text vitalityText;

    public TMP_Text pointsText;

    public void UpdateTexts(Player player)
    {
        attackText.text = player.attack.ToString();
        speedText.text = player.speed.ToString();
        healthText.text = player.health.ToString();
        defenseText.text = player.defense.ToString();
        intelectText.text = player.intelect.ToString();
        vitalityText.text = player.vitality.ToString();

        pointsText.text = player.allocationPoints.ToString();
    }
}
