using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutTextHere : MonoBehaviour
{
    internal enum Screen_Placements { Left, Right, Up, Down}

    float warning_opasity = 1.0f;
    Text Current_Warning;
    Text testText;
    Text shipText;
    Canvas Screen_Canvas;
    float n_time = 5.0f;
    bool notThere = true;



    // Start is called before the first frame update
    void Start()
    {
        Screen_Canvas = gameObject.GetComponentInChildren<Canvas>();

        //Manager_Script.FindObjectsOfType<List<Asteroid_Control>>

        testText = FindObjectOfType<Text>();
        shipText = FindObjectOfType<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Current_Warning)
        {           
            Current_Warning.color = new Color(1, 0, 0, warning_opasity);
            warning_opasity -= 0.01f;
            if (warning_opasity < 0)
                warning_opasity = 1.0f;
        }

        if(Current_Warning)
        {

            if (n_time > 0)
                {
                    Current_Warning.gameObject.SetActive(notThere);
                    n_time -= 0.01f;
                }
            else if (n_time <= 0)
                {
                    notThere = false;
                    Current_Warning.gameObject.SetActive(notThere);
                }

        }


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
        myText.color = Color.green;
        return myText;
    }

    internal void healthOfShipIs(int health)
    {
        shipText.text = health.ToString();
    }

    internal void createWarning(string warningMessage)
    {
        Current_Warning =  createText(warningMessage);
        Current_Warning.rectTransform.sizeDelta = new Vector2(300, 200);
        Current_Warning.fontSize = 48;
    }


}
