using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public enum GlassesType
{
    cat,
    normal,
    stars
};

public enum GlassesColors
{
    blue,
    black,
    green
};

public class UIManager : MonoBehaviour
{
    [SerializeField] GlassesManager glassesManager;
    [SerializeField] ARFaceManager faceManager;
    [SerializeField] Button catButton, normalButton, starsButton;
    [SerializeField] Button blueButton, blackButton, greenButton;
    public MeshRenderer currentGlass;
    public Color currentColor;

    private MeshRenderer catG;
    private MeshRenderer normalG;

    private MeshRenderer starsG;

    // Start is called before the first frame update
    void Start()
    {
        glassesManager = faceManager.facePrefab.GetComponent<GlassesManager>();
        //ReloadCurrentGlasses();
        catButton.onClick.AddListener(() => ChangeGlasses(GlassesType.cat));
        normalButton.onClick.AddListener(() => ChangeGlasses(GlassesType.normal));
        starsButton.onClick.AddListener(() => ChangeGlasses(GlassesType.stars));
        blueButton.onClick.AddListener(()=>ChangeColor(GlassesColors.blue));
        blackButton.onClick.AddListener(()=>ChangeColor(GlassesColors.black));
        greenButton.onClick.AddListener(()=>ChangeColor(GlassesColors.green));
        catG = glassesManager.cat;
        normalG = glassesManager.normal;
        starsG = glassesManager.stars;
    }

    public void ChangeGlasses(GlassesType glassesType)
    {
        catG.enabled = glassesType == GlassesType.cat;
        normalG.enabled = glassesType == GlassesType.normal;
        starsG.enabled = glassesType == GlassesType.stars;
        currentGlass = catG.enabled ? catG : normalG.enabled ? normalG : starsG;
    }

    public void ChangeColor(GlassesColors glassesColors)
    {
        currentGlass.material.color = glassesColors == GlassesColors.blue
            ? Color.blue
            : glassesColors == GlassesColors.black
                ? Color.black
                : Color.green;
        currentColor = glassesColors == GlassesColors.blue? Color.blue : glassesColors == GlassesColors.black ? Color.black : Color.green;
    }

   
    public void ReloadCurrentGlasses()
    {
        currentGlass.GetComponent<MeshRenderer>().enabled = true;
        currentGlass.GetComponent<MeshRenderer>().material.color = currentColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}