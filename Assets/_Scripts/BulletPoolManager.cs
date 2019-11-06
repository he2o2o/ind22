using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    //public GameObject bullet;
    private static BulletPoolManager _instance;
    //The property to reture a instance
    public static BulletPoolManager Instance
    {
        //creat the object and assign the instance
        get
        {
            //create logic to make instance
            if (_instance == null)
            {
                GameObject go = new GameObject("BulletPoolManager");
                //get the object and add the scrip to it
                go.AddComponent<BulletPoolManager>();
            }
            return _instance;
        }
    }

    // when the object is loading we need to assign the instance
    


    //TODO: create a structure to contain a collection of bullets
    public static BulletPoolManager current;
    public GameObject poolobj;
    public int poolam = 15;
    public bool willGrow = true;

    List<GameObject> poolobjs;

    void Awake()
    {
        current = this;
    }




    // Start is called before the first frame update
    void Start()
    {
        // TODO: add a series of bullets to the Bullet Pool
        poolobjs = new List<GameObject>();

        for (int i = 0; i < poolam; i++)
        {
            GameObject obj = (GameObject)Instantiate(poolobj);
            obj.SetActive(false);
            poolobjs.Add(obj);
        }
    }

   

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        for (int i = 0; i < poolobjs.Count; i++)
        {
            if (!poolobjs[i].activeInHierarchy)
            {
                return poolobjs[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(poolobj);
            poolobjs.Add(obj);
            return obj;

        }
        return null;
            
    }

   

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject poolobj)
    {
        Invoke("Destory", 2f);
        poolobj.SetActive(false);
        CancelInvoke();

    }
}
