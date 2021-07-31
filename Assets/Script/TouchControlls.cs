using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControlls : MonoBehaviour
{
    private Vector3 position;
    private float width;
    private float height;

    public GameObject Background;
    public Transform RightObject;
    public Transform LeftObject;

    bool isRight = false;
    bool isLeft = true;

    Vector3 RightTouchPosition = Vector3.zero;
    Vector3 LeftTouchPostion = Vector3.zero;

    float leftDistance = 0f;
    float rightDistance = 0f;

    bool isrightUp = false;
    bool isleftUp = false;

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        // Position used for the cube.
        position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void OnGUI()
    {
        // Compute a fontSize based on the size of the screen width.
        GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);

        GUI.Label(new Rect(20, 20, width, height * 0.25f),
            "x = " + position.x.ToString("f2") +
            ", y = " + position.y.ToString("f2"));
    }

    void Update()
    {
        // Handle screen touches.
        if (Input.touchCount == 1)
        {
            var touch = Input.touches[0];
            if (touch.position.x < Screen.width / 2)
            {
                DoLeftSideStuff(0);
            }
            if (touch.position.x > Screen.width / 2)
            {
                DoRightSideStuff(0);
            }
        }

        if (Input.touchCount == 2)
        {
            var touch = Input.touches[1];
            if (touch.position.x < Screen.width / 2)
            {
                DoLeftSideStuff(1);
            }
            else if (touch.position.x > Screen.width / 2)
            {
                DoRightSideStuff(1);
            }

            var touchh = Input.touches[0];
            if (touchh.position.x < Screen.width / 2)
            {
                DoLeftSideStuff(0);
            }
            else if (touchh.position.x > Screen.width / 2)
            {
                DoRightSideStuff(0);
            }
        }

        MainCalcualtion();

        isLeft = false;
        isRight = false;
        
    }

    void DoLeftSideStuff(int index)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.touches[index].position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            LeftTouchPostion = hit.point;
            if (LeftObject.position.y > LeftTouchPostion.y)
                isleftUp = false;
            else
                isleftUp = true;
            leftDistance = Vector3.Distance(hit.point, LeftObject.position);
            isLeft = true;
        }
    }

    void DoRightSideStuff(int index)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.touches[index].position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            RightTouchPosition = hit.point;
            if (RightObject.position.y > RightTouchPosition.y)
                isrightUp = false;
            else
                isrightUp = true;
            rightDistance = Vector3.Distance(hit.point, RightObject.position);
            isRight = true;

        }
    }

    void MainCalcualtion()
    {
        if (isRight && isLeft && rightDistance > 0.5f && leftDistance >0.5f)
        {
            if (isleftUp && isrightUp)
                MoveUpAndDown(true);
            else if (!isleftUp && !isrightUp)
                MoveUpAndDown(false);
            else if (isleftUp && !isrightUp)
                RotateClockAnticlock(true);
            else if (!isleftUp && isrightUp)
                RotateClockAnticlock(false);

            //if (isleftUp && !isrightUp)
            //    RotateClockAnticlock(true);
            //else if (!isleftUp && isrightUp)
            //    RotateClockAnticlock(false);

        }
        calculateToMoveBoard();
        
    }

    void MoveUpAndDown(bool isup)
    {
        if(isup)
            gameObject.transform.position +=new Vector3(0, 0.1f * Time.deltaTime * ((leftDistance + rightDistance) / 2), 0);
        else
            gameObject.transform.position -= new Vector3(0, 0.1f * Time.deltaTime * ((leftDistance + rightDistance) / 2), 0);
    }


    void RotateClockAnticlock(bool isclock)
    {
        if (!isclock)
        {
            gameObject.transform.RotateAround(gameObject.transform.position, Vector3.forward, 5f * Time.deltaTime * ((leftDistance+rightDistance)/2));
        }
        else
        {
            gameObject.transform.RotateAround(gameObject.transform.position, Vector3.back, 5f * Time.deltaTime * ((leftDistance + rightDistance) / 2));
        }
    }

    void calculateToMoveBoard()
    {
        if(gameObject.transform.position.y>-2)
        {
            float distance = gameObject.transform.position.y;
            if (distance < 0)
                distance = (distance * -1);
            else
                distance = distance + 2;

            Background.transform.position -= new Vector3(0, 0.1f * Time.deltaTime * (distance/2), 0);
        }
        
    }


    //1. move upwards -> if the difference is 1 then move upwards and both are true
    //2. move downwords -> if the differene is 1 then move download and both are false
    //3. rotate right 
    //4. rotate left
}
