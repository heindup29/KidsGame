using UnityEngine;

public class MoveShapeTouchScript : MonoBehaviour
{

    private Transform objectTransform;
    public Vector2 sPos;
    public Vector3 objectStartingPos;
    private Ray rayFromCamera;

    private RaycastHit rayHitInfo;
    private bool moveableobjectSelected = false;
    private Vector3 originalScale;

    void Start()
    {
        objectTransform = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.touches.Length != 0)
        {
            Touch[] myTouch = Input.touches;
            rayFromCamera = Camera.main.ScreenPointToRay(myTouch[0].position);

            RaycastHit rayInfo = new RaycastHit();

            if (myTouch[0].phase == TouchPhase.Began)
            {
                if (Physics.Raycast(rayFromCamera, out rayInfo, 200))
                {
                    if (rayInfo.transform.gameObject.tag == "MoveableObject")
                    {
                        moveableobjectSelected = true;
                        originalScale = gameObject.transform.localScale;
                        gameObject.transform.localScale = new Vector3(1.33f, 1.33f, 1.33f);
                    }
                }
            }

            if (moveableobjectSelected)
            {
                if (myTouch[0].phase == TouchPhase.Began)
                {
                    sPos = myTouch[0].position;
                    GlobalVariables.objectSelected = true;
                    objectStartingPos = gameObject.transform.position;
                }
                else if (myTouch[0].phase == TouchPhase.Moved)
                {
                    float x = (myTouch[0].position.x / Screen.width * 7.66f * 2f) - 7.66f;
                    float z = (myTouch[0].position.y / Screen.height * 4.75f * 2) - 4.74f;
                    Vector3 tempVector3 = new Vector3(x, 7f, z);

                    objectTransform.position = tempVector3;
                }
                else if (myTouch[0].phase == TouchPhase.Ended)
                {
                    float x = (myTouch[0].position.x / Screen.width * 7.66f * 2f) - 7.66f;
                    float z = (myTouch[0].position.y / Screen.height * 4.75f * 2) - 4.74f;
                    Vector3 tempVector3 = new Vector3(x, 7f, z);

                    objectTransform.position = tempVector3;
                    GlobalVariables.objectSelected = false;
                    gameObject.transform.localScale = originalScale;
                    moveableobjectSelected = false;

                    Ray rayFromMovableObject = new Ray { origin = gameObject.transform.position, direction = Vector3.down };

                    if (Physics.Raycast(rayFromMovableObject, out rayHitInfo, 2f))
                    {
                        Debug.Log(rayHitInfo.transform.gameObject.name);
                        if (rayHitInfo.transform.gameObject.name.ToLower().Contains(gameObject.transform.name.ToLower()))
                        {
                            Object.Destroy(gameObject);
                            GlobalVariables.CreateRandomMovableShape();
                        }
                    }
                    gameObject.transform.position = objectStartingPos;
                }
            }
        }
    }
}
