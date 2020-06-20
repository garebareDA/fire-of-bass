using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassAnimation : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;

    GameObject fires;

    Animator handRghit;
    Animator body;
    Animator handLeft;
    Animator fires1;
    Animator fires2;

    protected AudioSource source;

    int fireCount = 0;
    int clickCounter;
    float timeCountUp = -1f;
    float timeOut = 0f;
    float timeFireCountUp = -1f;
    float fireTimeOut = 0f;

    bool IsFire = false;

    // Start is called before the first frame update
    void Start()
    {
        fires = GameObject.Find("fires");
        handRghit = transform.GetChild(0).gameObject.GetComponent<Animator>();
        body = transform.GetChild(1).gameObject.GetComponent<Animator>();
        fires.SetActive(false);
        handLeft = transform.GetChild(2).gameObject.GetComponent<Animator>();
        source = GetComponents<AudioSource>()[0];
        
        fires1 = fires.transform.GetChild(0).gameObject.GetComponent<Animator>();
        fires2 = fires.transform.GetChild(1).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCountUp -= Time.deltaTime;
        timeFireCountUp -= Time.deltaTime;
  
        GameObject obj = getClickObject();

        if (timeCountUp < timeOut)
        {
            timeCountUp = -1f;
            fireCount = 0;
        }

        if (timeFireCountUp < fireTimeOut && IsFire == true)
        {
            IsFire = false;
            fires.SetActive(false);
        }

        if (obj != null && obj.name == "bass")
        {
            clickCounter += 1;
            fireCount += 1;
            timeCountUp = 0.5f;

            if (fireCount == 3 && IsFire == false)
            {
                Debug.Log("fire!");
                IsFire = true;
                timeFireCountUp = 2f;
                fires.SetActive(true);
                fires1.Play("fireEfect");
                fires2.Play("fireEfect");
            }

            source.Stop();
            source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
            int leftHandRandom = Random.Range(0, 4);

            handRghit.Play("play");


            pixelHand(leftHandRandom);
            pixelMove(clickCounter);

            if (clickCounter == 60)
            {
                clickCounter = 0;
            }
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

    private void pixelMove(int random)
    {
        switch (random)
        {
            case 3:
                moveRhigt();
                break;
            case 4:
                body.Play("stay");
                break;
            case 10:
                moveRhigt();
                break;
            case 18:
                moveRhigt();
                break;
            case 20:
                body.Play("stay");
                break;
            case 27:
                moveLeft();
                break;
            case 30:
                moveLeft();
                break;
            case 35:
                body.Play("stay");
                break;
            case 40:
                moveLeft();
                break;
            case 54:
                body.Play("stay");
                break;
            case 60:
                moveRhigt();
                break;
            default:
                break;
        }
    }

    private void pixelHand(int random)
    {
        switch (random)
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
    }

    private void moveRhigt()
    {
        body.Play("move");
        transform.Translate(0.05f, 0, 0);
    }

    private void moveLeft()
    {
        body.Play("move");
        transform.Translate(-0.05f, 0, 0);
    }
}
