using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HUDController : MonoBehaviour
{
    public TMP_Text lifeText;
    public Image healthbar;
    public TMP_Text healthText;
    public TMP_Text enemyText;
    public int enemyCount;
    public void UpdateHealth(int crt, int max)
    {
        healthText.text = crt.ToString() + "/" + max.ToString();
        healthbar.fillAmount = (float)crt / max;
    }

    public void UpdateEnemy()
    {
        enemyCount--;
        enemyText.text = "Enemy : " + enemyCount.ToString();
    }

}
