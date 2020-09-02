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

    [SerializeField]
    GameObject[] Lines;

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
        SpawnPropertyBox(CharData.CharPropertyEnum.STR, 0 + (.2f * 0), false , Lines[0]);
        SpawnPropertyBox(CharData.CharPropertyEnum.DEX, 0 + (.2f * 1), false, Lines[0]);
        SpawnPropertyBox(CharData.CharPropertyEnum.CON, 0 + (.2f * 2),  false, Lines[0]);
        SpawnPropertyBox(CharData.CharPropertyEnum.APP, 0 + (.2f * 3),  false, Lines[0]);
        SpawnPropertyBox(CharData.CharPropertyEnum.POW, 0 + (.2f * 4),  false, Lines[0]);

        SpawnChooseBox(RandomType, 0 + (.14f * 0) , Lines[1]);
        SpawnChooseBox(RandomType, 0 + (.14f * 1) , Lines[1]);
        SpawnChooseBox(RandomType, 0 + (.14f * 2), Lines[1]);
        SpawnChooseBox(RandomType, 0 + (.14f * 3), Lines[1]);
        SpawnChooseBox(RandomType, 0 + (.14f * 4), Lines[1]);
        SpawnChooseBox(RandomType, 0 + (.14f * 5), Lines[1]);
        SpawnChooseBox(RandomType, 0 + (.14f * 6), Lines[1]);
    }

    void OnSecCreateStep()
    {
        int RandomType = 2;

        
        SpawnPropertyBox(CharData.CharPropertyEnum.STR, 0 + (.2f * 0), true, Lines[0]);
        SpawnPropertyBox(CharData.CharPropertyEnum.DEX, 0 + (.2f * 1), true, Lines[0]);
        SpawnPropertyBox(CharData.CharPropertyEnum.CON, 0 + (.2f * 2), true, Lines[0]);
        SpawnPropertyBox(CharData.CharPropertyEnum.APP, 0 + (.2f * 3), true, Lines[0]);
        SpawnPropertyBox(CharData.CharPropertyEnum.POW, 0 + (.2f * 4), true, Lines[0]);

        SpawnPropertyBox(CharData.CharPropertyEnum.INT, 0 + (.2f * 0) , false, Lines[1]);
        SpawnPropertyBox(CharData.CharPropertyEnum.SIZE, 0 + (.2f * 1) , false, Lines[1]);
        SpawnPropertyBox(CharData.CharPropertyEnum.EDU, 0 + (.2f * 2) , false, Lines[1]);
        
        SpawnChooseBox(RandomType, 0 + (.14f * 0), Lines[2]);
        SpawnChooseBox(RandomType, 0 + (.14f * 1), Lines[2]);
        SpawnChooseBox(RandomType, 0 + (.14f * 2), Lines[2]);
        SpawnChooseBox(RandomType, 0 + (.14f * 3), Lines[2]);
    }

    void OnThirdCreateStep()
    {
        int RandomType = 1;

        SpawnPropertyBox(CharData.CharPropertyEnum.STR, 0 + (.2f * 0), true, Lines[0]);
        SpawnPropertyBox(CharData.CharPropertyEnum.DEX, 0 + (.2f * 1), true, Lines[0]);
        SpawnPropertyBox(CharData.CharPropertyEnum.CON, 0 + (.2f * 2), true, Lines[0]);
        SpawnPropertyBox(CharData.CharPropertyEnum.APP, 0 + (.2f * 3), true, Lines[0]);
        SpawnPropertyBox(CharData.CharPropertyEnum.POW, 0 + (.2f * 4), true, Lines[0]);

        SpawnPropertyBox(CharData.CharPropertyEnum.INT, 0 + (.2f * 0), true, Lines[1]);
        SpawnPropertyBox(CharData.CharPropertyEnum.SIZE, 0 + (.2f * 1), true, Lines[1]);
        SpawnPropertyBox(CharData.CharPropertyEnum.EDU, 0 + (.2f * 2), true, Lines[1]);

        SpawnPropertyBox(CharData.CharPropertyEnum.LUCK, 0 + (.2f * 0), false, Lines[2]);

        SpawnChooseBox(RandomType, 0 + (.14f * 0), Lines[3]);
        SpawnChooseBox(RandomType, 0 + (.14f * 0), Lines[3]);
    }

    void OnResultCreateStep()
    {
        SpawnPropertyBox(CharData.CharPropertyEnum.STR, 0 + (.2f * 0), true, Lines[0]);
        SpawnPropertyBox(CharData.CharPropertyEnum.DEX, 0 + (.2f * 1), true, Lines[0]);
        SpawnPropertyBox(CharData.CharPropertyEnum.CON, 0 + (.2f * 2), true, Lines[0]);
        SpawnPropertyBox(CharData.CharPropertyEnum.APP, 0 + (.2f * 3), true, Lines[0]);
        SpawnPropertyBox(CharData.CharPropertyEnum.POW, 0 + (.2f * 4), true, Lines[0]);

        SpawnPropertyBox(CharData.CharPropertyEnum.INT, 0 + (.2f * 0), true, Lines[1]);
        SpawnPropertyBox(CharData.CharPropertyEnum.SIZE, 0 + (.2f * 1), true, Lines[1]);
        SpawnPropertyBox(CharData.CharPropertyEnum.EDU, 0 + (.2f * 2), true, Lines[1]);

        SpawnPropertyBox(CharData.CharPropertyEnum.LUCK, 0 + (.2f * 0), false, Lines[2]);

        charData.GenDerivedValuePropertyData();

        SpawnPropertyBox(CharData.CharPropertyEnum.SAN, 0 + (.2f * 0), true, Lines[3]);
        SpawnPropertyBox(CharData.CharPropertyEnum.MP, 0 + (.2f * 1), true, Lines[3]);
        SpawnPropertyBox(CharData.CharPropertyEnum.HP, 0 + (.2f * 2), true, Lines[3]);
        SpawnPropertyBox(CharData.CharPropertyEnum.MOV, 0 + (.2f * 3), true, Lines[3]);

        SpawnDBBox(0 + (.2f * 0), Lines[4]);
        SpawnBuildBox(0 + (.2f * 1), Lines[4]);

    }


    PropertyBoxControll SpawnPropertyBox(CharData.CharPropertyEnum Type , float AnchorsX , bool ReadOnly , GameObject Line)
    {
        GameObject SpawnObj = Instantiate(PropertyBoxPrefab);
        SpawnObj.GetComponent<RectTransform>().parent = Line.transform;
        SpawnObj.GetComponent<RectTransform>().anchorMin = new Vector2(AnchorsX,0);
        SpawnObj.GetComponent<RectTransform>().anchorMax = new Vector2(AnchorsX + 0.2f,1) ;
        SpawnObj.GetComponent<RectTransform>().anchoredPosition = new Vector2();
        SpawnObj.GetComponent<RectTransform>().sizeDelta = new Vector2();

        SpawnObj.transform.localScale = new Vector3(1, 1, 1);

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

    PropertyBoxControll SpawnDBBox( float AnchorsX, GameObject Line)
    {
        GameObject SpawnObj = Instantiate(PropertyBoxPrefab);
        SpawnObj.GetComponent<RectTransform>().parent = Line.transform;
        SpawnObj.GetComponent<RectTransform>().anchorMin = new Vector2(AnchorsX, 0);
        SpawnObj.GetComponent<RectTransform>().anchorMax = new Vector2(AnchorsX + 0.2f, 1);
        SpawnObj.GetComponent<RectTransform>().anchoredPosition = new Vector2();
        SpawnObj.GetComponent<RectTransform>().sizeDelta = new Vector2();
        SpawnObj.transform.localScale = new Vector3(1, 1, 1);


        SpawnObj.GetComponent<PropertyBoxControll>().value = charData.DamageBouns;
        SpawnObj.GetComponent<PropertyBoxControll>().SpecValueViewText = "DB";
        SpawnObj.GetComponent<PropertyBoxControll>().TextDisplayOnly = true;

        SpawnedObjs.Add(SpawnObj);
        propertyBoxControlls.Add(SpawnObj.GetComponent<PropertyBoxControll>());
        return SpawnObj.GetComponent<PropertyBoxControll>();
    }
    PropertyBoxControll SpawnBuildBox( float AnchorsX, GameObject Line)
    {
        GameObject SpawnObj = Instantiate(PropertyBoxPrefab);
        SpawnObj.GetComponent<RectTransform>().parent = Line.transform;
        SpawnObj.GetComponent<RectTransform>().anchorMin = new Vector2(AnchorsX, 0);
        SpawnObj.GetComponent<RectTransform>().anchorMax = new Vector2(AnchorsX + 0.2f, 1);
        SpawnObj.GetComponent<RectTransform>().anchoredPosition = new Vector2();
        SpawnObj.GetComponent<RectTransform>().sizeDelta = new Vector2();
        SpawnObj.transform.localScale = new Vector3(1, 1, 1);


        SpawnObj.GetComponent<PropertyBoxControll>().value = charData.Build;
        SpawnObj.GetComponent<PropertyBoxControll>().SpecValueViewText = "BUILD";
        SpawnObj.GetComponent<PropertyBoxControll>().TextDisplayOnly = true;

        SpawnedObjs.Add(SpawnObj);
        propertyBoxControlls.Add(SpawnObj.GetComponent<PropertyBoxControll>());
        return SpawnObj.GetComponent<PropertyBoxControll>();
    }

    ValRandomBase SpawnChooseBox(int RandomType, float AnchorsX, GameObject Line)
    {
        GameObject SpawnObj = Instantiate(ChooseBoxPrefab);
        SpawnObj.GetComponent<RectTransform>().parent = Line.transform;
        SpawnObj.GetComponent<RectTransform>().anchorMin = new Vector2(AnchorsX, 0);
        SpawnObj.GetComponent<RectTransform>().anchorMax = new Vector2(AnchorsX + 0.12f, 1);
        SpawnObj.GetComponent<RectTransform>().anchoredPosition = new Vector2();
        SpawnObj.GetComponent<RectTransform>().sizeDelta = new Vector2();

        SpawnObj.transform.localScale = new Vector3(1,1,1);

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
