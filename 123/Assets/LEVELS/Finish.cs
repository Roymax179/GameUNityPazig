using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            BannerCollection.MyInstance.Finish();
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        UImanager.MyInstance.HideVictoryConditions();
    //    }
    //}
}