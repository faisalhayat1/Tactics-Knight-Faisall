using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotyManager : MonoBehaviour
{


    void Start()
    {
      var c = new AndroidNotificationChannel()
      {
        Id = "channel_id",
        Name = "Default Channel",
        Importance = Importance.High,
        Description = "Generic notifications",
      };
      AndroidNotificationCenter.RegisterNotificationChannel(c);

      Notify();
      Notify4();
    }

    // Update is called once per frame
    public void Notify()
    {
      if (PlayerPrefs.GetInt("Notify") != 0) AndroidNotificationCenter.CancelNotification(PlayerPrefs.GetInt("Notify"));


      var notification = new AndroidNotification();
      notification.Title = Titles();
      notification.Text = Descript();
      //notification.LargeIcon = "icon_1";
      notification.FireTime = System.DateTime.Now.AddHours(24);

      int id = AndroidNotificationCenter.SendNotification(notification, "channel_id");
      PlayerPrefs.SetInt("Notify", id);

    }

    public string Descript(){
      string desc = "Return to game = (";
      if (Application.systemLanguage == SystemLanguage.Russian ) desc = "Возвращайся в игру =(";

      return desc;
    }

    public string Titles(){
      string titl = "WE MISS YOU";
      if (Application.systemLanguage == SystemLanguage.Russian ) titl = "МЫ СКУЧАЕМ ПО ТЕБЕ";

      return titl;
    }
    ////*********************************************************************************

    public void Notify4()
    {
      if (PlayerPrefs.GetInt("Notify4") != 0) AndroidNotificationCenter.CancelNotification(PlayerPrefs.GetInt("Notify4"));


      var notification = new AndroidNotification();
      notification.Title = Titles2();
      notification.Text = Descript2();
      notification.FireTime = System.DateTime.Now.AddHours(100);


      int id = AndroidNotificationCenter.SendNotification(notification, "channel_id");
      PlayerPrefs.SetInt("Notify4", id);

    }

        public string Descript2(){
          string desc = "I'm really looking forward to you, come and play!";
          if (Application.systemLanguage == SystemLanguage.Russian ) desc = "Я тебя очень жду, заходи поиграть!";

          return desc;
        }

        public string Titles2(){
          string titl = "Have you forgotten me?";
          if (Application.systemLanguage == SystemLanguage.Russian ) titl = "Ты совсем забыл меня?";

          return titl;
        }


}
