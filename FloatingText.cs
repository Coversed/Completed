using UnityEngine;
using UnityEngine.UI;

public class FloatingText 
{
    public bool active;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;


    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);


    }

    public void Hide()
    {
        active = false;
        go.SetActive(active);

    }

    public void UpdateFloatingText()
    {
        if (!active)
            return;

        //When the game started - when the test is shown > duration eg(10 seconds - 7seconds > 2 seconds therefore hide)

        if (Time.time - lastShown > duration)
            Hide();

        go.transform.position += motion * Time.deltaTime;
    }
}  
