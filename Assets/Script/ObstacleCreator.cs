using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    //things = Obstacle,Gainer
    [Header("Obstacle")]
    public GameObject BackBoard;
    public GameObject[] Obstacles;

    public int ObstacleCountMinimun=10;
    public int ObstacleCountMaximum=20;

    public float MinSize=0.1f;
    public float MaxSize=1f;

    public float minDistance = 0.5f;

    [Header("Gainer")]
    public GameObject[] GainerPrefab;
    public int GainerMinCount = 10;
    public int GainerMaxCount = 20;

    public float increasePerGainer = 0.1f;

    public float gainerSize = 0.1f;
    public float minDistanceforgainer = 0.5f;

    public float maxSize = 2;

    [Header("Final")]
    public GameObject FinalBall;

    public LinkedList list;
    private void Start()
    {
        InitializeObstacle();
        InitializeFinalBall();
    }

    
    void InitializeObstacle()
    {
        int n = Random.Range(ObstacleCountMinimun, ObstacleCountMaximum);
        int destroyedCounter = 0;
        while(n>0)
        {
            GameObject go=SpawnRandom("Obstacle");
            bool check = checkOtherDistance(go.transform.position, minDistance);
            if(check)
            {
                go.transform.SetParent(BackBoard.transform);
                list.add("1", go);
                n--;
            }
            else
            {
                destroyedCounter++;
                if(destroyedCounter==10)
                {
                    n--;
                    destroyedCounter = 0;
                }
                Destroy(go);
            }
        }

        n = Random.Range(GainerMinCount, GainerMaxCount);
        destroyedCounter = 0;
        while (n > 0)
        {
            GameObject go = SpawnRandom("Gainer");
            bool check = checkOtherDistance(go.transform.position, minDistanceforgainer);
            if (check)
            {
                go.transform.SetParent(BackBoard.transform);
                list.add("1", go);
                n--;
            }
            else
            {
                destroyedCounter++;
                if (destroyedCounter == 10)
                {
                    n--;
                    destroyedCounter = 0;
                }
                Destroy(go);
            }
        }
    }

    GameObject SpawnRandom(string things)
    {
        int randomObject = 0 ;
        float randomSize = 0.3f;
        GameObject go=null;
        if (things=="Obstacle")
        {
            randomObject = Random.Range(0, Obstacles.Length);
            randomSize = Random.Range(0.3f, 1.3f);
            go = Instantiate(Obstacles[randomObject]);
        }
            
        if (things == "Gainer")
        {
            randomObject = Random.Range(0, GainerPrefab.Length);
            randomSize = gainerSize;
            go = Instantiate(GainerPrefab[randomObject]);
        }
            
         

        Vector3 newPosition = new Vector3(Random.Range(-2f, 2f), Random.Range(1, 20), 0.5f);

        go.transform.position = newPosition;
        go.transform.localScale =new Vector3(randomSize, randomSize, 1);
        
        return go;
    }

    bool checkOtherDistance(Vector3 spawnPoint,float minDistancee)
    {
        if(list.length()==0)
        {
            return true;
        }
        for(int i=0;i<list.length();i++)
        {
            GameObject temp = list.get(i).godata;
            float distance = Vector3.Distance(spawnPoint, temp.transform.position);
            list.set(i, distance.ToString(), temp);
        }

        list.manageMergeSort();
        if (list.floatconvert(list.head) > minDistancee)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }


    void InitializeFinalBall()
    {
        GameObject go = Instantiate(FinalBall);

        Vector3 newPosition =new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(22f, 25f), 0.5f);

        go.transform.position = newPosition;
        go.transform.SetParent(BackBoard.transform);
    }
}
