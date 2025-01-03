using UnityEngine;

public class ColorIndex : MonoBehaviour
{
    public static ColorIndex colors;

    private void Awake()
    {
        colors = this;
    }

    [Header("Reds")]
    public Color pink;
    public Color redLight;
    public Color redJasper;
    public Color redCrimson;

    [Header("Blues")]
    public Color blueLight;
    public Color blue;
    public Color blueCobalt;

    [Header("Greens")]
    public Color greenLime;
    public Color green;
    public Color greenForest;
    public Color greenDark;

    [Header("Reds")]
    public Color yellow;

    [Header("Oranges")]
    public Color orangeLight;
    public Color orange;
    public Color orangeSienna;
    public Color orangeBurntSienna;

    [Header("Browns")]
    public Color brownLight;
    public Color brown;
    public Color brownDark;

    [Header("Purples")]
    public Color purpleMagenta;
    public Color purpleGrape;

    [Header("Greyscale")]
    public Color white;
    public Color greyLight;
    public Color grey;
    public Color greyJet;
    public Color greySlate;
    public Color greySlateGrey;
    public Color black;

    [Header("Shades")]
    public Color shadeCream;
    public Color shadeTan;
    public Color shadeSkin;
    public Color shadeDarkSkin;
}
