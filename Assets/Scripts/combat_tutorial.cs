using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat_tutorial : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    [SerializeField]
    GameObject wait;
    [SerializeField]
    GameObject QTE;
    [SerializeField]
    GameObject QTE_explain;
    [SerializeField]
    GameObject stick;
    [SerializeField]
    GameObject good_luck;

    public bool line1;
    public bool played;
    // Start is called before the first frame update
    void Start()
    {
        wait.SetActive(false);
        line1 = false;
        QTE.SetActive(false);
        QTE_explain.SetActive(false);
        stick.SetActive(false);
        good_luck.SetActive(false);
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (line1 == true)
        {
            if (wait.activeSelf == false)
            {
                line1 = false;
                QTE.SetActive(true);
                QTE_explain.SetActive(true);
                stick.SetActive(true);
            }
        }
        if (QTE.activeSelf)
        {
            if (QTE_explain.activeSelf == false)
            {
                stick.transform.position += new Vector3(500, 0, 0) * Time.deltaTime;
                if (stick.transform.position.x >= 1800)
                {
                    good_luck.SetActive(true);
                    stick.SetActive(false);
                    QTE.SetActive(false);
                    played = true;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && stick.activeSelf)
        {
            stick.SetActive(false);
            QTE.SetActive(false);
            good_luck.SetActive(true);
            played = true;
        }
        if (played == true && good_luck.activeSelf == false)
        {
            door.SetActive(true);
            Destroy(gameObject);
        }
    }
    public void OnObjectClicked()
    {
        wait.SetActive(true);
        line1 = true;
    }

    private void OnMouseDown()
    {
        // Detect mouse click on the object's collider
        OnObjectClicked();
    }
}
