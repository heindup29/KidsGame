using System.Text;
using UnityEditor;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    public GameObject pauseMenuUI;
    static public bool objectSelected = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuUI.SetActive(true);

        }

    }

    static public void CreateRandomMovableShape()
    {
        //System.Random randomNumberGen = new System.Random();
        StringBuilder str = new StringBuilder();

        //int rnd = randomNumberGen.Next(1,10);

        /*string[] prefabList = 
        {

        };*/

        str.Append("Assets/Prefabs/");
        //str.Append(prefabList[rnd]);
        str.Append("Triangle");
        str.Append(".prefab");


        Object prefab = AssetDatabase.LoadAssetAtPath(str.ToString(), typeof(GameObject));
        GameObject clone = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;

        clone.transform.position = Vector3.one;

    }

    static void ShapeInsertedIntoPuzzelBox()
    {

    }
}
