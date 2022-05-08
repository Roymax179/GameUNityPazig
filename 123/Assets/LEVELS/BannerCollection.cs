using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BannerCollection : MonoBehaviour
{

    private int CollectedBanners = 0;
    private int victoryconditions=1;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);

        }
    }
    private static BannerCollection instance;
    public static BannerCollection MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new BannerCollection();
            }
            return instance;
        }
    }
    private void Start()
    {
        UImanager.MyInstance.BannerUI(CollectedBanners, victoryconditions);
    }
    public void AddBanner(int _banners)
    {
        CollectedBanners += 1;
        Debug.Log(CollectedBanners);
        UImanager.MyInstance.BannerUI(CollectedBanners, victoryconditions);


    }
    public void Finish()
    {
        //if (CollectedBanners >= victoryconditions)
        //{
        //    UImanager.MyInstance.Win();
        //}
        //else
        //{
        //    UImanager.MyInstance.ShowVictoryConditions(CollectedBanners, victoryconditions);
        //}
        UImanager.MyInstance.Win();
    }
}
