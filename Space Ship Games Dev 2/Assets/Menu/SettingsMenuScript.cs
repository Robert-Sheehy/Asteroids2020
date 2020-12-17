using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenuScript : MonoBehaviour
{
    public void UpdateNumberOfAsteroids()
    {
        PersistentScript.numberOfAsteroids = (int) GameObject.Find("NumberOfAsteroidsSlider").GetComponent<Slider>().value;
        GameObject.Find("NumberOfAsteroidsDisplay").GetComponent<TextMeshProUGUI>().text = PersistentScript.numberOfAsteroids.ToString();
    }

    public void UpdateWorldRadius()
    {
        PersistentScript.worldRadius = (int)GameObject.Find("WorldRadiusSlider").GetComponent<Slider>().value;
        GameObject.Find("WorldRadiusDisplay").GetComponent<TextMeshProUGUI>().text = PersistentScript.worldRadius.ToString();
    }

    public void UpdateGameVolume()
    {
        PersistentScript.gameVolume = (int)GameObject.Find("GameVolumeSlider").GetComponent<Slider>().value;
        GameObject.Find("GameVolumeDisplay").GetComponent<TextMeshProUGUI>().text = PersistentScript.gameVolume.ToString();
    }
}
