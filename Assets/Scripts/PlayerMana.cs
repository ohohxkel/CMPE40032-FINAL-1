using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{

    Image manaBar;

    public float maxMana = 100f;
    public static float mana;
    // Start is called before the first frame update
    void Start()
    {
        manaBar = GetComponent<Image>();
        mana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        mana += 2f * Time.deltaTime;
        manaBar.fillAmount = mana / maxMana;
    }
}
