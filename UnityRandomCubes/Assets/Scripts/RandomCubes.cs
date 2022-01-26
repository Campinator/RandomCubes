/**
 * Created By: Camp Steiner 
 * Date Created: Jan 24, 2022
 * 
 * Last Edited By: Camp Steiner
 * Date Last Edited: Jan 26, 2022
 * 
 * Description: Spawn multiple cube prefabs into the scene 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    public GameObject cubePrefab; //its a cube, it gets spawned
    public float scalingFactor = 0.95f; //amount each cube shrinks each frame
    public int numberOfCubes = 0; //number of cubes currently in the scene
    [HideInInspector] public List<GameObject> cubeList; //list of the cubes

    // Start is called before the first frame update
    void Start()
    {
        cubeList = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++;
        GameObject cube = Instantiate<GameObject>(cubePrefab);

        cube.name = "Cubey_" + numberOfCubes;

        cube.transform.position = Random.insideUnitSphere; //random location inside sphere with r=1 centered on (0,0,0) of object this script is on

        cube.GetComponent<Renderer>().material.color =  new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        cubeList.Add(cube);
        List<GameObject> removeList = new List<GameObject>(); //to remove

        foreach(GameObject c in cubeList)
        {
            c.transform.localScale *= scalingFactor;
            if (c.transform.localScale.x <= 0.1f)
            {
                removeList.Add(c);
            }
        }
        foreach(GameObject r in removeList)
        {
            cubeList.Remove(r);
            Destroy(r);
        }
    }
}
