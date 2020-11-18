using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIButton : MonoBehaviour


{

    Health the_object_we_wish_to_change;
    // Start is called before the first frame update
    void Start()
    {
        the_object_we_wish_to_change = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      void OnGUI(){
        if (GUI.Button (new Rect(0,0,80,20),"Reset Health")){
           the_object_we_wish_to_change. adjust_health(50);
        //transfer to main menu sceen
        //nameofSceen.SetActive();
        }

        if (GUI.Button (new Rect(100,0,80,20),"Pause")){
            print("You clicked the pause button");
        //transfer to pause sceen
        //pauseSceen.SetActive();
        /*if (timeScale==1){
            timeScale=0;
        }
        else{
            timescale=1;
        }
        */
        }
    }
}
