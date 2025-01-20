using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class TapToBoom : MonoBehaviour
{
    public GameObject Boom;
    public GameObject firstShowBackGround;
    public GameObject lastShowBackGround;
    bool isTapped = false;
    [SerializeField]BoomAnimeEvents BoomAnimeEvents;
    [SerializeField] AudioClip AudioClip;

    [SerializeField] float volume=5.0f;

    private void Start()
    {
        Boom.SetActive(false);
        lastShowBackGround.SetActive(false);
        firstShowBackGround.SetActive(true);

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isTapped = true;
            if (Boom != null)
            {
                AudioSystemBehaviour.Instance.effectSource.PlayOneShot(AudioClip, volume);


                Boom.SetActive(true); // ¼¤»îÎïÌå
                Debug.Log("Boom activated!");
            }
            else
            {
                Debug.LogWarning("Boom object is not assigned!");
            }
        }

        if (isTapped && BoomAnimeEvents.IsDied)
        {
            Boom.SetActive(false);
            lastShowBackGround.SetActive(true);
            firstShowBackGround.SetActive(false);
        }
    }
}