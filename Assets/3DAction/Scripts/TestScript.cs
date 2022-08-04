using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void BackScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}