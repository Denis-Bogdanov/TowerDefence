using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    Camera camera;
    TowerPlace currentPlace;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        // Испускаем луч из камеры туда где сейчас находится курсор мыши
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        // Переменная для хранения результата пересечения луча
        RaycastHit hit;

        // Если луч пересёкся с каким то объектом и этот объект имеет тег "TowerPlace"
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("TowerPlace"))
        {
            bool isMouseDown = Input.GetMouseButtonDown(0);
            bool isMouseUp = Input.GetMouseButtonUp(0);
            TowerPlace tp = hit.collider.gameObject.GetComponent<TowerPlace>();

            if (isMouseDown || isMouseUp)
            {
                if (isMouseDown)
                {
                    tp.MouseDown();
                }
                else if (isMouseUp)
                {
                    tp.MouseUp();
                }
            }
            else
            {
                if (currentPlace != tp)
                {
                    if (currentPlace != null)
                        currentPlace.MouseLeave();

                    tp.MouseEnter();
                    currentPlace = tp;
                }
            }
        }
        else
        {
            if (currentPlace != null)
                currentPlace.MouseLeave();

            currentPlace = null;
        }
    }
}
