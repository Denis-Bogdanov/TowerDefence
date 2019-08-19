using UnityEngine;
using System.Collections;

public class TowerPlace : MonoBehaviour
{
    // Можно строить?
    bool _isCanBuild = true;

    public GameObject tower;

    // Клавиша мыши нажата, курсор находится над объектом
    public void MouseDown()
    {
        if (_isCanBuild)
        {
            _isCanBuild = false;
            Instantiate(tower, transform.position, transform.rotation);
            GetComponent<Renderer>().material.color = new Color(0.17f, 0.67f, 0.03f);
        }
    }

    // Клавиша мыши отпущена, курсор находится над объектом
    public void MouseUp()
    {
    }

    // Если курсор мыши оказался над объектом
    public void MouseEnter()
    {
        if (_isCanBuild)
            GetComponent<Renderer>().material.color = new Color(0.29f, 1f, 0.26f);
    }

    // Если курсор мыши больше не находится над объектом
    public void MouseLeave()
    {
        if (_isCanBuild)
            GetComponent<Renderer>().material.color = new Color(0f, 0.34f, 0.02f);
    }
}