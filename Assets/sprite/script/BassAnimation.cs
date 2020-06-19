using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = getClickObject();
        if (obj != null)
        {
            Debug.Log(obj);
        }
    }

    private GameObject getClickObject()
    {
        GameObject clickedGameObject = null;
        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
            }

            Debug.Log(clickedGameObject);
        }

        return clickedGameObject;
    }
}
