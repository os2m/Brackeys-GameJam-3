using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ScoreManager))]
[RequireComponent(typeof(PlaygroundManager))]
public class ItemManager : MonoBehaviour
{
    [Header("Cam")]
    public Image camButton;
    public Sprite camBtnNormal;
    public Sprite camBtnHightlighted;
    public Camera cam;
    public float camDuration = 5f;
    public Transform normalPos;
    public Transform funnyPos;
    [Header("Arrow")]
    public Shake shake;
    public float noShakeDuration = 10f;
    public Image arrowButton;
    public Sprite arrowBtnNormal;
    public Sprite arrowBtnHightlighted;
    [Header("Lock")]
    public GameObject[] plates;
    public float lockDuration = 5f;
    public Image lockButton;
    public Sprite lockBtnNormal;
    public Sprite lockBtnHightlighted;
    [Header("Time")]
    public float highlightTimeDuration = 2f;
    public Image timeButton;
    public Sprite timeBtnNormal;
    public Sprite timeBtnHightlighted;
    public float timeToAdd = 5f;
    [Header("Jump")]
    public float highlightJumpDuration = 2f;
    public Image jumpButton;
    public Sprite jumpBtnNormal;
    public Sprite jumpBtnHightlighted;
    public int jumpsToAdd = 1;
    public int jumps = 5;
    public TMP_Text jumpText;
    public Image spaceKeyImage;
    [Header("Spawn items")]
    public int itemCount = 5;
    private int currentItemCount;
    public GameObject[] items;
    List<GameObject> spawner;

    // Start is called before the first frame update
    void Start()
    {
        plates = GameObject.FindGameObjectsWithTag("Lock");
        TogglePlates();

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        jumpText.text = "" + jumps;

        if (jumps < 1)
            spaceKeyImage.gameObject.SetActive(false);
        else
            spaceKeyImage.gameObject.SetActive(true);

        if (currentItemCount < itemCount)
            SpawnItems();
    }

    public void SpawnItems()
    {
        List<GameObject> spawner = new List<GameObject>();

        for (int i = 0; i < GetComponent<PlaygroundManager>().spawner.Count; i++)
        {
            spawner.Add(GetComponent<PlaygroundManager>().spawner[i]);
        }

        for (int i = 0; i < itemCount; i++)
        {
            int spawnIndex = Random.Range(0, (spawner.Count));
            int itemIndex = Random.Range(0, (items.Length));

            GameObject item = Instantiate(items[itemIndex], spawner[spawnIndex].transform);
            item.transform.SetParent(GetComponent<PlaygroundManager>().zRotator);
            currentItemCount++;
            spawner.Remove(spawner[spawnIndex]);
        }
    }

    public IEnumerator ArrowItem()
    {
        GetComponent<AudioSource>().Play();

        arrowButton.sprite = arrowBtnHightlighted;

        shake.enabled = false;
        yield return new WaitForSeconds(noShakeDuration);
        shake.enabled = true;

        arrowButton.sprite = arrowBtnNormal;
        currentItemCount--;
    }

    public void TogglePlates()
    {
        for (int i = 0; i < plates.Length; i++)
        {
            plates[i].SetActive(!plates[i].activeInHierarchy);
        }
    }

    public IEnumerator LockItem()
    {
        GetComponent<AudioSource>().Play();

        lockButton.sprite = lockBtnHightlighted;
        TogglePlates();

        yield return new WaitForSeconds(lockDuration);

        TogglePlates();
        lockButton.sprite = lockBtnNormal;
        currentItemCount--;
    }

    public IEnumerator CameraItem()
    {
        GetComponent<AudioSource>().Play();

        camButton.sprite = camBtnHightlighted;

        cam.transform.position = funnyPos.position;
        cam.transform.rotation = funnyPos.rotation;
        yield return new WaitForSeconds(camDuration);
        cam.transform.position = normalPos.position;
        cam.transform.rotation = normalPos.rotation;

        camButton.sprite = camBtnNormal;
        currentItemCount--;
    }

    public IEnumerator TimeItem()
    {
        GetComponent<AudioSource>().Play();

        timeButton.sprite = timeBtnHightlighted;

        GetComponent<ScoreManager>().CurrentTime += timeToAdd;
        yield return new WaitForSeconds(highlightTimeDuration);

        timeButton.sprite = timeBtnNormal;
        currentItemCount--;
    }

    public IEnumerator JumpItem()
    {
        GetComponent<AudioSource>().Play();

        jumpButton.sprite = jumpBtnHightlighted;

        jumps += jumpsToAdd;
        yield return new WaitForSeconds(highlightJumpDuration);

        jumpButton.sprite = jumpBtnNormal; 
        currentItemCount--;
    }
}
