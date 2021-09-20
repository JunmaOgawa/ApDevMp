using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageHandler : MonoBehaviour
{
    public void ChangeColor(int bulletNum)
    {
        Color color = Color.red;
        switch (bulletNum)
        {
            case 0:
                color = Color.red;
                break;
            case 1:
                color = Color.green;
                break;
            case 2:
                color = Color.blue;
                break;
        }
        GetComponent<Image>().color = color;
    }
}
