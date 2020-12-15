using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutTextHere : MonoBehaviour
{
    internal enum Screen_Placements { Left, Right, Up, Down}

    Text testText;
    Text shipText;
    Canvas Screen_Canvas;
    // Start is called before the first frame update
    void Start()
    {
        Screen_Canvas = gameObject.GetComponentInChildren<Canvas>();

        GameObject newGO = new GameObject("myTextGO");


        //Manager_Script.FindObjectsOfType<List<Asteroid_Control>>

        testText = FindObjectOfType<Text>();
        shipText = FindObjectOfType<Text>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void numberOfAsteroidsIs(int count)
    {
        testText.text = count.ToString();
    }

    internal Text createText(string text_start, Screen_Placements place)
    {

        Text myText = createText(text_start);

        re_position(myText, place);

        return myText;
    }

    internal Text createText(string text_start, Screen_Placements place1, Screen_Placements place2)
    {

        Text myText = createText(text_start);

        re_position(myText, place1);
        re_position(myText, place2);

        return myText;
    }

    private static void re_position( Text myText, Screen_Placements place)
    {
        Vector2 position = myText.rectTransform.position;
        switch (place)
        {
            case Screen_Placements.Up:

                position = new Vector2(position.x, Screen.height - 20);

                break;

            case Screen_Placements.Down:

                position = new Vector2(position.x, 20);

                break;

            case Screen_Placements.Left:
                position = new Vector2(30, position.y);
                myText.alignment = TextAnchor.MiddleRight;
                break;

            case Screen_Placements.Right:
                position = new Vector2(Screen.width - 30, position.y);

                break;



        }
        myText.rectTransform.position = position;
    }

    internal Text createText(string text_start)
    {

        GameObject newGO = new GameObject("myTextGO", typeof(RectTransform));
        newGO.transform.SetParent(Screen_Canvas.transform);
        Text myText = newGO.AddComponent<Text>();
        myText.text = text_start;
        myText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        myText.fontSize = 16;
        myText.rectTransform.position = new Vector2(Screen.width / 2, Screen.height / 2);
        myText.rectTransform.sizeDelta = new Vector2(100, 50);
        myText.alignment = TextAnchor.MiddleCenter;
        return myText;
    }

    internal void healthOfShipIs(int health)
    {
        shipText.text = health.ToString();
    }

}
