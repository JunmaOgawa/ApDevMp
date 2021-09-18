using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;



public class NotificationHandler : MonoBehaviour
{

    int hours = 0;
    int minutes = 10;
    int seconds = 0;

    private void BuildDefaultNotificationChannel()
    {
        string channel_id = "default";

        string title = "Default Channel";

        Importance importance = Importance.Default;

        string description = "default Channel for this game";

        AndroidNotificationChannel defaultChannel =
            new AndroidNotificationChannel(channel_id, title, description, importance);

        AndroidNotificationCenter.RegisterNotificationChannel(defaultChannel);
    }

    private void Awake()
    {
        BuildDefaultNotificationChannel();
    }

    public void changeTimeHours(int hur)
    {
        hours = hur;
    }

    public void changeTimeMinutes(int min)
    {
        minutes = min;
    }

    public void changeTimeSeconds(int sec)
    {
        seconds = sec;
    }

    public void SendSimpleNotif()
    {
        string notif_title = "Simple Notif";

        string notif_message = "This is a simple notification";

        System.DateTime fireTime = System.DateTime.Now.AddSeconds(10);

        AndroidNotification notif = new AndroidNotification(notif_title,
                                                            notif_message,
                                                            fireTime);

        notif.SmallIcon = "icon_0";
        notif.LargeIcon = "icon_1";

        AndroidNotificationCenter.SendNotification(notif, "default");
    }
    private void BuildRepeatNotificationChannel()
    {
        string channel_id = "repeat";

        string title = "Repeat Channel";

        Importance importance = Importance.Default;

        string description = "Channel for repeating notifs";

        AndroidNotificationChannel repeatChannel =
            new AndroidNotificationChannel(channel_id, title, description, importance);

        AndroidNotificationCenter.RegisterNotificationChannel(repeatChannel);
    }
    public void SendRepeatNotif()
    {
        string notif_title = "Repeat Notif";

        string notif_message = "this is a repeat notification";

        System.DateTime fireTime = System.DateTime.Now.AddSeconds(10);

        System.TimeSpan interval = new System.TimeSpan(hours, minutes, seconds);

        AndroidNotification notif = new AndroidNotification(notif_title,
                                                            notif_message,
                                                            fireTime,
                                                            interval);
        notif.SmallIcon = "icon_0";
        notif.LargeIcon = "icon_1";
        AndroidNotificationCenter.SendNotification(notif, "repeat");
    }
}
