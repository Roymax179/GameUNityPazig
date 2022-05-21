using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            BannerCollection.MyInstance.Finish();
            new WaitForSeconds(10000);
            SceneManager.LoadScene("MainMenu");
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
