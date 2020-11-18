using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    TextMeshPro ourHealthDisplay;
    internal int health = 100;
    bool isDisplayed = true;
    //TMPro Text health_Display;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newGO = new GameObject("Health Text");
        newGO.transform.parent = transform;
        ourHealthDisplay = newGO.AddComponent<TextMeshPro>();
        if (ourHealthDisplay)
        { ourHealthDisplay.text = health.ToString(); }
        else print("Warning: No TMP component found");

        
        ourHealthDisplay.rectTransform.sizeDelta = new Vector2(10, 20);
        ourHealthDisplay.alignment = TextAlignmentOptions.Top;

        ourHealthDisplay.enabled = isDisplayed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void adjust_health(int adjustment)
    {
        health += adjustment;
        ourHealthDisplay.enabled = true;
        ourHealthDisplay.text = health.ToString();
      //   health_Display.Text = health.ToString();
        if (health<0)
        Destroy(gameObject);
    }
}
