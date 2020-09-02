using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValRandomBase : MonoBehaviour
{
    public int RandomType;

    [SerializeField]
    GameObject NumberPrefab;
    GameObject SpawnObj;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNumber();
    }

    public void SpawnNumber()
    {
        SpawnObj = Instantiate(NumberPrefab);
        SpawnObj.GetComponent<ValControll>().motherBase = this;
        SpawnObj.GetComponent<ValControll>().RandomType = RandomType;

        SpawnObj.GetComponent<DragDrop>().ResetPos();
    }

}
