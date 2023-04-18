using UnityEngine;

public class MaterialHelper
{
    private const byte KMaxByteForOverexposedColor = 191; //internal Unity const

    public static float GetMaterialEmissionIntensity(Material material)
    {
        Color emissionColor = material.GetColor("_EmissionColor");
        var maxColorComponent = emissionColor.maxColorComponent;
        var scaleFactor = KMaxByteForOverexposedColor / maxColorComponent;
        return Mathf.Log(255f / scaleFactor) / Mathf.Log(2f);
    }
}