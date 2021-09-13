using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionCtrl : MonoBehaviour
{
  //アニメーションで使う関数用
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
