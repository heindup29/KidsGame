using UnityEngine;
using System.Collections;

public class BallRotateScript : MonoBehaviour
{
    private Transform objectTransform;
    public Vector2 sPos;
    public float xOffset = 0.05f;
    public float yOffset = 0.05f;
    public bool moveableObjectSelected = false;


    private void Start()
    {
        objectTransform = gameObject.GetComponent<Transform>();
    }
    void Update()
    {
        if (Input.touches.Length != 0)
        {
            Touch[] myTouch = Input.touches;

            if (myTouch[0].phase == TouchPhase.Began  && GlobalVariables.objectSelected != true)
            {
                objectTransform.Rotate(rotationalDirectionAndReturnEuler(myTouch[0].deltaPosition), Space.World);
            }
            else if (myTouch[0].phase == TouchPhase.Moved  && GlobalVariables.objectSelected != true)
            {
                objectTransform.Rotate(rotationalDirectionAndReturnEuler(myTouch[0].deltaPosition), Space.World);
            }
            else if (myTouch[0].phase == TouchPhase.Ended  && GlobalVariables.objectSelected != true)
            {
                objectTransform.Rotate(rotationalDirectionAndReturnEuler(myTouch[0].deltaPosition), Space.World);
            }
        }
    }


    private Vector3 rotationalDirectionAndReturnEuler(Vector2 deltaPositionOfObject)
    {
        return new Vector3(deltaPositionOfObject.y * xOffset,0, 0 - deltaPositionOfObject.x* yOffset);
        
    }


    
}
