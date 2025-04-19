using TMPro;
using UnityEngine;

public class SpeedTracker : MonoBehaviour
{

    public PlaneController planeController;

    public TMP_Text text;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.SetText("" + planeController.thrust);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        text.SetText("" + planeController.thrust);
    }
}
