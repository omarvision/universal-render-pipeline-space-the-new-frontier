using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int NumAsteroids = 25;
    public Vector3 Spawn = new Vector3(15, 5, 15);
    public float SizeRange = 20;
    public GameObject[] prefabs = null;
    private List<GameObject> Asteroids = new List<GameObject>();

    private void Start()
    {
        GameObject obj = null;
        for (int i = 0; i < NumAsteroids; i++)
        {
            int which = Random.Range(0, 4);
            switch (which)
            {
                case 0:
                    obj = Instantiate(prefabs[0], this.transform);                    
                    break;
                case 1:
                    obj = Instantiate(prefabs[1], this.transform);
                    break;
                case 2:
                    obj = Instantiate(prefabs[2], this.transform);
                    break;
                case 3:
                    obj = Instantiate(prefabs[3], this.transform);
                    break;
            }

            obj.transform.localPosition = new Vector3(Random.Range(-Spawn.x, Spawn.x), Random.Range(-Spawn.y, Spawn.y), Random.Range(-Spawn.z, Spawn.z));

            float rscale = Random.Range(this.transform.localScale.x, this.transform.localScale.x * SizeRange);
            rscale *= 10;
            obj.transform.localScale = Vector3.Scale(obj.transform.localScale, new Vector3(rscale, rscale, rscale));           

            Asteroids.Add(obj);
        }
    }
}
