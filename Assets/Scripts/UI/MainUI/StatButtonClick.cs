using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatButtonClick : MonoBehaviour
{
    private Button button;
    public StatButton buttonType;

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ClickButton);
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void ClickButton()
    {
        player.StatButtonAdd(buttonType);
    }
}
