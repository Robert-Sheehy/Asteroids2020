using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentScript : MonoBehaviour
{
    public static int numberOfAsteroids;
    public static int musicVolume;
    public static int soundEffectsVolume;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
