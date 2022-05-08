using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UImanager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtBanners, txtWin;
    [SerializeField] GameObject victoryConditon;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);

        }
    }
    private static UImanager instance;
    public static UImanager MyInstance
    {
        get
        {
            if(instance==null)
            {
                instance=new UImanager();
            }
            return instance;
        }
    }
    public void BannerUI(int _banners, int _victoryConditon)
    {
        txtBanners.text="Banners: " + _banners +" / " + _victoryConditon;
    }
    public void ShowVictoryConditions(int _banners, int _victoryCondition)
    {
        victoryConditon.SetActive(true);
        txtWin.text = "You need" + (_victoryCondition - _banners) + "more Banners";
    }
    public void HideVictoryConditions()
    {
        victoryConditon.SetActive(false);
       
    }
    public void Win()
    {
        victoryConditon.SetActive(true);
        txtWin.text = "You Win!";
    }
}
