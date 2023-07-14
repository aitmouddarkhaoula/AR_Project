using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class UIManager : MonoBehaviour
{
    [SerializeField] GlassesManager glassesManager;
    [SerializeField] ARFaceManager faceManager;
    [SerializeField] Button catButton, normalButton, starsButton;
    [SerializeField] Button blueButton, blackButton, greenButton;
    public GameObject currentGlass;
    public Color currentColor;
    // Start is called before the first frame update
    void Start()
    {
        glassesManager = faceManager.facePrefab.GetComponent<GlassesManager>();
        //ReloadCurrentGlasses();
        catButton.onClick.AddListener(CatOnClick);
        normalButton.onClick.AddListener(NormalOnClick);
        starsButton.onClick.AddListener(StarsOnClick);
        blueButton.onClick.AddListener(ChangeToBlueColor);
        blackButton.onClick.AddListener(ChangeToBlackColor);
        greenButton.onClick.AddListener(ChangeToGreenColor);
    }
    public void CatOnClick()
    {
        glassesManager.cat.GetComponent<MeshRenderer>().enabled = true;
        glassesManager.normal.GetComponent<MeshRenderer>().enabled = false;
        glassesManager.stars.GetComponent<MeshRenderer>().enabled = false;
        currentGlass = glassesManager.cat;


    }
    public void NormalOnClick()
    {
        glassesManager.cat.GetComponent<MeshRenderer>().enabled = false;
        glassesManager.normal.GetComponent<MeshRenderer>().enabled = true;
        glassesManager.stars.GetComponent<MeshRenderer>().enabled = false;
        currentGlass = glassesManager.normal;

    }
    public void StarsOnClick()
    {
        glassesManager.cat.GetComponent<MeshRenderer>().enabled = false;
        glassesManager.normal.GetComponent<MeshRenderer>().enabled = false;
        glassesManager.stars.GetComponent<MeshRenderer>().enabled = true;
        currentGlass = glassesManager.stars;

    }
    public void ChangeToBlueColor()
    {
        currentGlass.GetComponent<MeshRenderer>().material.color = Color.blue;
        currentColor = Color.blue;
    }
    public void ChangeToBlackColor()
    {
        currentGlass.GetComponent<MeshRenderer>().material.color = Color.black;
        currentColor = Color.black;
    }
    public void ChangeToGreenColor()
    {
        currentGlass.GetComponent<MeshRenderer>().material.color = Color.green;
        currentColor = Color.green;
    }
    public void ReloadCurrentGlasses()
    {
        currentGlass.GetComponent<MeshRenderer>().enabled = true;
        currentGlass.GetComponent<MeshRenderer>().material.color = currentColor;

    }
    // Update is called once per frame
    void Update()
    {
        glassesManager = GameObject.FindWithTag("Glasses").GetComponent<GlassesManager>();
    }
}
