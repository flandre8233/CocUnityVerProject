using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControll : SingletonMonoBehavior<MenuControll>
{
    public void ToDiceScene()
    {
        SceneChanger.ToDice();
    }
    public void ToConFrontationScene()
    {
        SceneChanger.ToConFrontation();
    }
}
