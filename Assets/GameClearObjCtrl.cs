using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearObjCtrl : MonoBehaviour
{
    public GameObject player;
    public void ToGameClear()
    {
        SceneManager.LoadScene("GameClearScene");
    }

}
