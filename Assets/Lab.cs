using UnityEngine;

public class Lab : MonoBehaviour
{
    private void Awake()
    {

        Item current;


    }


    class Item
    {

    }

    private void Func()
    {
        Debug.Log("this message is form CSharp....");
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Func();
        }
    }
}
