using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger
{
    public static void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public static void ToConFrontation()
    {
        SceneManager.LoadScene("ConFrontation");
    }
    public static void ToDice()
    {
        SceneManager.LoadScene("Dice");
    }


}
