using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCreateControll : SingletonMonoBehavior<CharCreateControll>
{

    public CharData charData;

    public GameObject PropertyBoxPrefab;
    public GameObject ChooseBoxPrefab;

    public List< GameObject >  SpawnedObjs;
     List<PropertyBoxControll> propertyBoxControlls;

    [SerializeField]
    Vector2 SpawnPoint;

    [SerializeField]
    Vector2 ChooseBoxSpawnPoint;

   public int StepCounter;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            StepCounter = Mathf.Clamp(StepCounter - 1 , 1 , 4);
            ResetContent();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddStep();
            ResetContent();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            print("Checker : " + CheckAllPropertyBoxDone() );
        }

    }

    private void Start()
    {
        SpawnedObjs = new List<GameObject>();
        propertyBoxControlls = new List<PropertyBoxControll>();
        charData = new CharData();
        StepCounter = 1;

        ResetContent();
    }

    public void AddStep()
    {
        StepCounter = Mathf.Clamp(StepCounter + 1, 1, 4);
    }

    public void ResetContent()
    {
        foreach (var item in SpawnedObjs)
        {
            Destroy(item);
        }
        SpawnedObjs = new List<GameObject>();
        propertyBoxControlls = new List<PropertyBoxControll>();

        switch (StepCounter)
        {
            case 1:
                OnFirstCreateStep();
                break;
            case 2:
                OnSecCreateStep();
                break;
            case 3:
                OnThirdCreateStep();
                break;
            case 4:
                OnResultCreateStep();
                break;
            default:
                break;
        }
    }

   public bool CheckAllPropertyBoxDone()
    {
        foreach (var item in propertyBoxControlls)
        {
            if (!item.IsHaveValue)
            {
                return false; 
            }
        }
        return true;
    }

    void OnFirstCreateStep()
    {
        int RandomType = 1;
        SpawnPropertyBox(CharData.CharPropertyEnum.STR, new Vector2(SpawnPoint.x + (300 * 0), SpawnPoint.y), false);
        SpawnPropertyBox(CharData.CharPropertyEnum.DEX, new Vector2(SpawnPoint.x + (300 * 1), SpawnPoint.y), false);
        SpawnPropertyBox(CharData.CharPropertyEnum.CON, new Vector2(SpawnPoint.x + (300 * 2), SpawnPoint.y), false);
        SpawnPropertyBox(CharData.CharPropertyEnum.APP, new Vector2(SpawnPoint.x + (300 * 3), SpawnPoint.y), false);
        SpawnPropertyBox(CharData.CharPropertyEnum.POW, new Vector2(SpawnPoint.x + (300 * 4), SpawnPoint.y), false);

        SpawnChooseBox(RandomType, new Vector2(ChooseBoxSpawnPoint.x + (175 * 0), ChooseBoxSpawnPoint.y));
        SpawnChooseBox(RandomType, new Vector2(ChooseBoxSpawnPoint.x + (175 * 1), ChooseBoxSpawnPoint.y));
        SpawnChooseBox(RandomType, new Vector2(ChooseBoxSpawnPoint.x + (175 * 2), ChooseBoxSpawnPoint.y));
        SpawnChooseBox(RandomType, new Vector2(ChooseBoxSpawnPoint.x + (175 * 3), ChooseBoxSpawnPoint.y));
        SpawnChooseBox(RandomType, new Vector2(ChooseBoxSpawnPoint.x + (175 * 4), ChooseBoxSpawnPoint.y));
        SpawnChooseBox(RandomType, new Vector2(ChooseBoxSpawnPoint.x + (175 * 5), ChooseBoxSpawnPoint.y));
        SpawnChooseBox(RandomType, new Vector2(ChooseBoxSpawnPoint.x + (175 * 6), ChooseBoxSpawnPoint.y));
    }

    void OnSecCreateStep()
    {
        int RandomType = 2;

        SpawnPropertyBox(CharData.CharPropertyEnum.STR, new Vector2(SpawnPoint.x + (300 * 0), SpawnPoint.y), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.DEX, new Vector2(SpawnPoint.x + (300 * 1), SpawnPoint.y), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.CON, new Vector2(SpawnPoint.x + (300 * 2), SpawnPoint.y), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.APP, new Vector2(SpawnPoint.x + (300 * 3), SpawnPoint.y), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.POW, new Vector2(SpawnPoint.x + (300 * 4), SpawnPoint.y), true);

        SpawnPropertyBox(CharData.CharPropertyEnum.INT, new Vector2(SpawnPoint.x + (300 * 0), SpawnPoint.y + (-150 * 1)), false);
        SpawnPropertyBox(CharData.CharPropertyEnum.SIZE, new Vector2(SpawnPoint.x + (300 * 1), SpawnPoint.y + (-150 * 1)), false);
        SpawnPropertyBox(CharData.CharPropertyEnum.EDU, new Vector2(SpawnPoint.x + (300 * 2), SpawnPoint.y + (-150 * 1)), false);

        SpawnChooseBox(RandomType, new Vector2(ChooseBoxSpawnPoint.x + (175 * 0), ChooseBoxSpawnPoint.y));
        SpawnChooseBox(RandomType, new Vector2(ChooseBoxSpawnPoint.x + (175 * 1), ChooseBoxSpawnPoint.y));
        SpawnChooseBox(RandomType, new Vector2(ChooseBoxSpawnPoint.x + (175 * 2), ChooseBoxSpawnPoint.y));
        SpawnChooseBox(RandomType, new Vector2(ChooseBoxSpawnPoint.x + (175 * 3), ChooseBoxSpawnPoint.y));
    }

    void OnThirdCreateStep()
    {
        int RandomType = 1;

        SpawnPropertyBox(CharData.CharPropertyEnum.STR, new Vector2(SpawnPoint.x + (300 * 0), SpawnPoint.y), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.DEX, new Vector2(SpawnPoint.x + (300 * 1), SpawnPoint.y), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.CON, new Vector2(SpawnPoint.x + (300 * 2), SpawnPoint.y), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.APP, new Vector2(SpawnPoint.x + (300 * 3), SpawnPoint.y), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.POW, new Vector2(SpawnPoint.x + (300 * 4), SpawnPoint.y), true);

        SpawnPropertyBox(CharData.CharPropertyEnum.INT, new Vector2(SpawnPoint.x + (300 * 0), SpawnPoint.y + (-150 * 1)), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.SIZE, new Vector2(SpawnPoint.x + (300 * 1), SpawnPoint.y + (-150 * 1)), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.EDU, new Vector2(SpawnPoint.x + (300 * 2), SpawnPoint.y + (-150 * 1)), true);

        SpawnPropertyBox(CharData.CharPropertyEnum.LUCK, new Vector2(SpawnPoint.x + (300 * 0), SpawnPoint.y + (-150 * 2) ) , false);

        SpawnChooseBox(RandomType, new Vector2(ChooseBoxSpawnPoint.x + (175 * 0), ChooseBoxSpawnPoint.y));
        SpawnChooseBox(RandomType, new Vector2(ChooseBoxSpawnPoint.x + (175 * 1), ChooseBoxSpawnPoint.y));
    }

    void OnResultCreateStep()
    {
        SpawnPropertyBox(CharData.CharPropertyEnum.STR, new Vector2(SpawnPoint.x + (300 * 0), SpawnPoint.y), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.DEX, new Vector2(SpawnPoint.x + (300 * 1), SpawnPoint.y), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.CON, new Vector2(SpawnPoint.x + (300 * 2), SpawnPoint.y), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.APP, new Vector2(SpawnPoint.x + (300 * 3), SpawnPoint.y), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.POW, new Vector2(SpawnPoint.x + (300 * 4), SpawnPoint.y), true);

        SpawnPropertyBox(CharData.CharPropertyEnum.INT, new Vector2(SpawnPoint.x + (300 * 0), SpawnPoint.y + (-150 * 1)), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.SIZE, new Vector2(SpawnPoint.x + (300 * 1), SpawnPoint.y + (-150 * 1)), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.EDU, new Vector2(SpawnPoint.x + (300 * 2), SpawnPoint.y + (-150 * 1)), true);

        SpawnPropertyBox(CharData.CharPropertyEnum.LUCK, new Vector2(SpawnPoint.x + (300 * 0), SpawnPoint.y + (-150 * 2) ), true);

        charData.GenDerivedValuePropertyData();

        SpawnPropertyBox(CharData.CharPropertyEnum.SAN, new Vector2(SpawnPoint.x + (300 * 0), SpawnPoint.y + (-150 * 3)), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.MP, new Vector2(SpawnPoint.x + (300 * 1), SpawnPoint.y + (-150 * 3)), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.HP, new Vector2(SpawnPoint.x + (300 * 2), SpawnPoint.y + (-150 * 3)), true);
        SpawnPropertyBox(CharData.CharPropertyEnum.MOV, new Vector2(SpawnPoint.x + (300 * 3), SpawnPoint.y + (-150 * 3)), true);

        SpawnDBBox(new Vector2(SpawnPoint.x + (300 * 0), SpawnPoint.y + (-150 * 4)) );
        SpawnBuildBox(new Vector2(SpawnPoint.x + (300 * 1), SpawnPoint.y + (-150 * 4)) );

    }


    PropertyBoxControll SpawnPropertyBox(CharData.CharPropertyEnum Type , Vector2 SpawnPoint , bool ReadOnly)
    {
        GameObject SpawnObj = Instantiate(PropertyBoxPrefab);
        SpawnObj.GetComponent<RectTransform>().parent = CharCreateCanvasControll.instance.transform;
        SpawnObj.GetComponent<RectTransform>().anchoredPosition = SpawnPoint;

        SpawnObj.GetComponent<PropertyBoxControll>().Type = Type;

        if (ReadOnly)
        {
            SpawnObj.GetComponent<PropertyBoxControll>().value = charData.GetPropertyData(Type).ToString();
            SpawnObj.GetComponent<PropertyBoxControll>().TextDisplayOnly = true;
        }

        SpawnedObjs.Add(SpawnObj);
        propertyBoxControlls.Add(SpawnObj.GetComponent<PropertyBoxControll>());
        return SpawnObj.GetComponent<PropertyBoxControll>();
    }

    PropertyBoxControll SpawnDBBox(Vector2 SpawnPoint)
    {
        GameObject SpawnObj = Instantiate(PropertyBoxPrefab);
        SpawnObj.GetComponent<RectTransform>().parent = CharCreateCanvasControll.instance.transform;
        SpawnObj.GetComponent<RectTransform>().anchoredPosition = SpawnPoint;


        SpawnObj.GetComponent<PropertyBoxControll>().value = charData.DamageBouns;
        SpawnObj.GetComponent<PropertyBoxControll>().SpecValueViewText = "DB";
        SpawnObj.GetComponent<PropertyBoxControll>().TextDisplayOnly = true;

        SpawnedObjs.Add(SpawnObj);
        propertyBoxControlls.Add(SpawnObj.GetComponent<PropertyBoxControll>());
        return SpawnObj.GetComponent<PropertyBoxControll>();
    }
    PropertyBoxControll SpawnBuildBox(Vector2 SpawnPoint)
    {
        GameObject SpawnObj = Instantiate(PropertyBoxPrefab);
        SpawnObj.GetComponent<RectTransform>().parent = CharCreateCanvasControll.instance.transform;
        SpawnObj.GetComponent<RectTransform>().anchoredPosition = SpawnPoint;


        SpawnObj.GetComponent<PropertyBoxControll>().value = charData.Build;
        SpawnObj.GetComponent<PropertyBoxControll>().SpecValueViewText = "BUILD";
        SpawnObj.GetComponent<PropertyBoxControll>().TextDisplayOnly = true;

        SpawnedObjs.Add(SpawnObj);
        propertyBoxControlls.Add(SpawnObj.GetComponent<PropertyBoxControll>());
        return SpawnObj.GetComponent<PropertyBoxControll>();
    }

    ValRandomBase SpawnChooseBox(int RandomType, Vector2 SpawnPoint)
    {
        GameObject SpawnObj = Instantiate(ChooseBoxPrefab);
        SpawnObj.GetComponent<RectTransform>().parent = CharCreateCanvasControll.instance.transform;
        SpawnObj.GetComponent<RectTransform>().anchoredPosition = SpawnPoint;

        SpawnObj.GetComponent<ValRandomBase>().RandomType = RandomType;

        SpawnedObjs.Add(SpawnObj);
        return SpawnObj.GetComponent<ValRandomBase>();
    }

}

public struct CharData
{
    public enum CharPropertyEnum
    {
        None,
        STR,
        CON,
        DEX,
        APP,
        POW,
        INT,
        SIZE,
        EDU,
        LUCK,

        SAN,
        MP,
        HP,
        MOV
    }

    Dictionary<CharPropertyEnum, int> Property;

    public string DamageBouns;
    public string Build;

    public int GetPropertyData(CharPropertyEnum Type)
    {
        if (Property == null)
        {
            Property = new Dictionary<CharPropertyEnum, int>();
        }
        if (!Property.ContainsKey(Type))
        {
            Property.Add(Type , 0 );
        }
        return Property[Type];
    }

    public void UpdatePropertyData(CharPropertyEnum Type, int NewNUm)
    {
        if (Property == null)
        {
            Property = new Dictionary<CharPropertyEnum, int>();
        }

        if (!Property.ContainsKey(Type))
        {
            Property.Add(Type, NewNUm);
            return;
        }

        Property[Type] = NewNUm;
    }

    public void GenDerivedValuePropertyData()
    {
        int SANPoint = GetPropertyData(CharPropertyEnum.POW);
        int MPPoint = GetPropertyData(CharPropertyEnum.POW) / 5;
        int HPPoint = (  GetPropertyData(CharPropertyEnum.SIZE) + GetPropertyData(CharPropertyEnum.CON)  ) / 10;

        int MOVPoint = 8;
        if (GetPropertyData(CharPropertyEnum.STR) < GetPropertyData(CharPropertyEnum.SIZE) && GetPropertyData(CharPropertyEnum.DEX) < GetPropertyData(CharPropertyEnum.SIZE))
        {
            MOVPoint = 7;
        }else if (GetPropertyData(CharPropertyEnum.STR) > GetPropertyData(CharPropertyEnum.SIZE) && GetPropertyData(CharPropertyEnum.DEX) > GetPropertyData(CharPropertyEnum.SIZE))
        {
            MOVPoint = 9;
        }
      

        Property.Add(CharPropertyEnum.SAN , SANPoint);
        Property.Add(CharPropertyEnum.MP, MPPoint);
        Property.Add(CharPropertyEnum.HP, HPPoint);
        Property.Add(CharPropertyEnum.MOV, MOVPoint);

        int STRSIZE = GetPropertyData(CharPropertyEnum.STR) + GetPropertyData(CharPropertyEnum.SIZE);

        if (STRSIZE >= 2 && STRSIZE <= 64)
        {
            DamageBouns = " -2 ";
            Build = " -2 ";
        }
        else if (STRSIZE >= 65 && STRSIZE <= 84)
        {
            DamageBouns = " -1 ";
            Build = " -1 ";
        }
        else if (STRSIZE >= 85 && STRSIZE <= 124)
        {
            DamageBouns = " 0 ";
            Build = " 0 ";
        }
        else if (STRSIZE >= 125 && STRSIZE <= 164)
        {
            DamageBouns = " +1D4 ";
            Build = " +1 ";
        }
        else if (STRSIZE >= 165 && STRSIZE <= 204)
        {
            DamageBouns = " +1D6 ";
            Build = " +2 ";
        }
        else if (STRSIZE >= 205 && STRSIZE <= 284)
        {
            DamageBouns = " +2D6 ";
            Build = " +3 ";
        }
        else if (STRSIZE >= 285 && STRSIZE <= 364)
        {
            DamageBouns = " +3D6 ";
            Build = " +4 ";
        }
        else if (STRSIZE >= 365 && STRSIZE <= 444)
        {
            DamageBouns = " +4D6 ";
            Build = " +5 ";
        }
        else if (STRSIZE >= 445 && STRSIZE <= 524)
        {
            DamageBouns = " +5D6 ";
            Build = " +6 ";
        }
    }
}
