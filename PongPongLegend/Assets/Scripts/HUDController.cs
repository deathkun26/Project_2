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
    public void UpdateHealth(int crt, int max)
    {
        lifeText.text = crt.ToString() + "/" + max.ToString();
        healthbar.fillAmount = (float)crt / max;
    }
    
}
