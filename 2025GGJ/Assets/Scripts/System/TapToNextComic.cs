using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToNextComic : MonoBehaviour
{
    [SerializeField] GameObject comic_1;
    [SerializeField] GameObject comic_2;
    [SerializeField] GameObject comic_3;
    [SerializeField] string sceneName;
    [SerializeField] int counts = 4;

    bool isTaping = false;
    // Start is called before the first frame update
    void Start()
    {
        comic_1.SetActive(false);
        comic_2.SetActive(false);
        comic_3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isTaping = true;
        }
        if(Input.GetMouseButtonUp(0)&&isTaping)
        {
            isTaping = false;
            counts--;
        }
        if (counts == 3)
        {
            comic_1.SetActive(true);
        }
        if (counts == 2)
        {
            comic_2.SetActive(true);
        }
        if (counts == 1)
        {
            comic_3.SetActive(true);
        }
        if (counts == 0)
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
