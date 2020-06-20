using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassAnimation : MonoBehaviour
{
    Animator handRghit;
    Animator body;
    Animator handLeft;
    int clickCounter;
    // Start is called before the first frame update
    void Start()
    {
        handRghit = transform.GetChild(0).gameObject.GetComponent<Animator>();
        body = transform.GetChild(1).gameObject.GetComponent<Animator>();
        handLeft = transform.GetChild(2).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = getClickObject();
        if (obj == null)
        {
            return;
        }

        if (obj.name == "bass")
        {
            Debug.Log(obj.ToString());
            handRghit.Play("play");
            int leftHandRandom = Random.RandomRange(0, 4);
            clickCounter = clickCounter + 1;

            switch (leftHandRandom)
            {
                case 0:
                    handLeft.Play("idle");
                    break;
                case 1:
                    handLeft.Play("onehgit");
                    break;
                case 2:
                    handLeft.Play("mid");
                    break;
                case 3:
                    handLeft.Play("onedown");
                    break;
                case 4:
                    handLeft.Play("down");
                    break;
                default:
                    break;
            }

            if (clickCounter == 20)
            {
                clickCounter = 0;
            }

            switch (clickCounter)
            {
                case 3:
                    body.Play("move");
                    transform.Translate(0.1f, 0, 0);
                    break;
                case 4:
                    body.Play("stay");
                    break;
                default:
                    break;
            }

            Debug.Log(clickCounter);
 
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
        }

        return clickedGameObject;
    }
}
