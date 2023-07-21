using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{

    public List<GameObject> groundList = new List<GameObject>();
    public int offset;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < groundList.Count; i++){
            Instantiate(groundList[i], new Vector3(0, 0, i * 40), transform.rotation);
            offset += 40;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecycleGround(GameObject ground){
        ground.transform.position = new Vector3(0, 0, offset);
        offset += 40;
        groundList.Add(ground);
        groundList.RemoveAt(0);
    }
}
