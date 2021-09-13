using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toGameClear : MonoBehaviour
{
    //アニメーションで使う関数
    public void ChangeScene()
    {
        SceneManager.LoadScene("GameClearScene");
    }

  
}
