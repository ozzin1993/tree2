using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class game_script : MonoBehaviour
{
    public List<GameObject> objects;
    //public GameObject player;
    public GameObject trunk;
    public GameObject branch;
    public GameObject branch_left;
    public GameObject[] items=new GameObject[3];
    public int count;
    public int y = 0;
    System.Random rnd = new System.Random();



    // Use this for initialization
    void Start()
    {
        startgame(count,0);
    }

    // Update is called once per frame
    void Update()
    {
        removeItem();
    }
    void startgame(int length, int head)
    {
        items[0] = trunk;
        items[1] = branch;
        items[2] = branch_left;
        objects = new List<GameObject>();
        GameObject tmp;
        
        for(int i = head; i < length; i++)
        {
            if (i == 0) tmp = Instantiate(items[0]);
            else tmp = newitem(); 
            Vector3 temp = tmp.transform.position;
            temp.y = i * 2;
            tmp.transform.position = temp;
            objects.Add(tmp);

        }
    }
    void removeItem()
    {



        if (Input.GetKeyDown("space"))
        {

            Vector3 tempCount = objects[count - 1].transform.position;
            Destroy(objects[0]);
            objects.RemoveAt(0);
            GameObject temp;
            for (int i = 0; i < objects.Count; i++)
            { 
                    Vector3 vector = objects[i].transform.position;
                    vector.y -= 2;
                    objects[i].transform.position = vector;
            }

            temp = newitem();
            temp.transform.position = tempCount;
            objects.Add(temp);

        }
    }
    GameObject newitem ()
    {
        GameObject tmp;
        int x = rnd.Next(0, 3);
        if ((x == 1 && y == 2) || (x == 2 && y == 1))
        {
            tmp = Instantiate(items[0]);

        }
        else
        {
            tmp = Instantiate(items[x]);

        }
        y = x;
        return tmp;
    }
    void transformPos(char t)
    {

    }
}




    