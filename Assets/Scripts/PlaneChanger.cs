using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlaneChanger : MonoBehaviour
{
    [SerializeField] Image planeImage;
    [SerializeField] GameObject planePrefab;

    [SerializeField] List<Sprite> imageOptions = new List<Sprite>();
    [SerializeField] List<GameObject> options = new List<GameObject>();

    private int currentOption = 0;

    [System.Obsolete]
    public void NextOption()
    {
        currentOption++;
        if(currentOption >= imageOptions.Count)
        {
            currentOption = 0;
        }

        planeImage.sprite = imageOptions[currentOption];

        PrefabUtility.ReplacePrefab(options[currentOption], planePrefab);

    }

    [System.Obsolete]
    public void PreviousOption()
    {
        currentOption--;
        if(currentOption < 0)
        {
            currentOption = imageOptions.Count - 1;
        }
        
        planeImage.sprite = imageOptions[currentOption];

        PrefabUtility.ReplacePrefab(options[currentOption], planePrefab);
    }
}
