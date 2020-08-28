using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCreateControll : SingletonMonoBehavior<CharCreateControll>
{

    public CharData charData;

    public GameObject PropertyBoxPrefab;
    public ValRandomBase[] valRandomBases;

    Vector2 SpawnPoint;

    private void Start()
    {
        SpawnPropertyBox(new Vector2(SpawnPoint.x, SpawnPoint.y)).UpdateText("STR");
        SpawnPropertyBox(new Vector2(SpawnPoint.x + 300, SpawnPoint.y)).UpdateText("DEX");
    }

    PropertyBoxControll SpawnPropertyBox(Vector2 SpawnPoint)
    {
        GameObject SpawnObj = Instantiate(PropertyBoxPrefab);
        SpawnObj.GetComponent<RectTransform>().parent = CharCreateCanvasControll.instance.transform;
        SpawnObj.GetComponent<RectTransform>().anchoredPosition = SpawnPoint;

        return SpawnObj.GetComponent<PropertyBoxControll>();
    }
}

public struct CharData
{
    public enum CharPropertyEnum
    {
        STR,
        CON,
        DEX,
        APP,
        POW,
        INT,
        SIZE,
        EDU,
        LUCK
    }

    public int STR {
        get {
            return Property[CharPropertyEnum.STR];
        }
        set {
             Property[CharPropertyEnum.STR] = value;
        }
    }
    public int CON {
        get {
            return Property[CharPropertyEnum.CON];
        }
        set {
            Property[CharPropertyEnum.CON] = value;
        }
    }
    public int DEX {
        get {
            return Property[CharPropertyEnum.DEX];
        }
        set {
            Property[CharPropertyEnum.DEX] = value;
        }
    }
    public int APP {
        get {
            return Property[CharPropertyEnum.APP];
        }
        set {
            Property[CharPropertyEnum.APP] = value;
        }
    }
    public int POW {
        get {
            return Property[CharPropertyEnum.POW];
        }
        set {
            Property[CharPropertyEnum.POW] = value;
        }
    }

    public int INT {
        get {
            return Property[CharPropertyEnum.INT];
        }
        set {
            Property[CharPropertyEnum.INT] = value;
        }
    }
    public int SIZE {
        get {
            return Property[CharPropertyEnum.SIZE];
        }
        set {
            Property[CharPropertyEnum.SIZE] = value;
        }
    }
    public int EDU {
        get {
            return Property[CharPropertyEnum.EDU];
        }
        set {
            Property[CharPropertyEnum.EDU] = value;
        }
    }

    public int LUCK {
        get {
            return Property[CharPropertyEnum.LUCK];
        }
        set {
            Property[CharPropertyEnum.LUCK] = value;
        }
    }

    Dictionary<CharPropertyEnum, int> Property;
}
