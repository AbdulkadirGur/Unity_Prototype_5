using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]

public class ClickAndSwipe : MonoBehaviour
{
    private GameManager gameManager;
    private Camera cam;
    //private Vector3 mousePos;
    private Vector3 touchPos;

    private TrailRenderer trail;
    private BoxCollider col;
    private bool swiping = false;

    void Awake()
    {
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        col = GetComponent<BoxCollider>();
        trail.enabled = false;
        col.enabled = false;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

   
    void Update()
    {
        /*
        if (gameManager.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                UpdateComponents();
            }
            if (swiping)
            {
                UpdateMousePosition();
            }
        }*/

        if (gameManager.isGameActive)
        {
            // Dokunmatik ekran giri?lerini kontrol et
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                // Dokunma ba?lang?c?
                if (touch.phase == TouchPhase.Began)
                {
                    swiping = true;
                    UpdateComponents();
                }
                // Dokunma sonu
                else if (touch.phase == TouchPhase.Ended)
                {
                    swiping = false;
                    UpdateComponents();
                }

                // Dokunma devam ederken
                if (swiping)
                {
                    UpdateTouchPosition(touch);
                }
            }
        }

    }
    /*
    void UpdateMousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, 10.0f));
        transform.position = mousePos;
    }*/
    // Dokunma pozisyonunu güncelle
    void UpdateTouchPosition(Touch touch)
    {
        touchPos = cam.ScreenToWorldPoint(new Vector3(touch.position.x,
            touch.position.y, 10.0f));
        transform.position = touchPos;
    }
    /*
    void UpdateComponents()
    {
        trail.enabled = swiping;
        col.enabled = swiping;
    }*/
    // Iz sürücü ve collider'? güncelle
    void UpdateComponents()
    {
        trail.enabled = swiping;
        col.enabled = swiping;
    }

    /*
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>() )
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }*/
    // Çarp??ma olay?n? kontrol et
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }

}
