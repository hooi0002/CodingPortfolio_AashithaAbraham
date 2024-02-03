using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ammoText;

    public void UpdateAmmo(int bulletsInMag, int totalBullet)
    {
        ammoText.text = "Ammo: " + bulletsInMag + " / " + totalBullet;
    }
}
