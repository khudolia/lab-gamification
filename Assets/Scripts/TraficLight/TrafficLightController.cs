using System.Collections;
using UnityEngine;

public enum State
{
    None,
    All,
    Red,
    Yellow,
    RedAndYellow,
    GreenAndYellow,
    Green
}

public class TrafficLightController : MonoBehaviour
{
    [Header("Settings")] public State currentState;
    public float animationDuration = 1f;
    public Material targetNoneMaterial;

    [Header("Lights")] 
    public GameObject[] redLight;
    public GameObject[] yellowLight;
    public GameObject[] greenLight;

    private Color _targetRedMaterial = Color.black;
    private Color _targetYellowMaterial = Color.black;
    private Color _targetGreenMaterial = Color.black;
    private Color _targetNoneColor;

    private float _targetIntensity = 4.416924f;
    private float _elapsedTime;
    private State _previousState = State.All;
    
    private Coroutine _redCoroutine;
    private Coroutine _yellowCoroutine;
    private Coroutine _greenCoroutine;

    void Start()
    {
        _targetRedMaterial = redLight[0].GetComponent<Renderer>().material.color;
        _targetYellowMaterial = yellowLight[0].GetComponent<Renderer>().material.color;
        _targetGreenMaterial = greenLight[0].GetComponent<Renderer>().material.color;
        _targetNoneColor = targetNoneMaterial.color;

        _targetIntensity = MaterialHelper.GetMaterialEmissionIntensity(redLight[0].GetComponent<Renderer>().material);
        
        TurnOnTrafficLight(State.None);
    }

    private void Update()
    {
        if (_previousState != currentState)
        {
            _previousState = currentState;

            TurnOffTrafficLight(currentState);
            TurnOnTrafficLight(currentState);
        }
    }

    public void TurnOnTrafficLight(State state)
    {
        switch (state)
        {
            case State.Red:
                ChangeLight(redLight, _targetRedMaterial, _redCoroutine);
                break;
            case State.RedAndYellow:
                ChangeLight(yellowLight, _targetYellowMaterial, _yellowCoroutine);
                ChangeLight(redLight, _targetRedMaterial, _redCoroutine);
                break;
            case State.GreenAndYellow:
                ChangeLight(yellowLight, _targetYellowMaterial, _yellowCoroutine);
                ChangeLight(greenLight, _targetGreenMaterial, _greenCoroutine);
                break;
            case State.Yellow:
                ChangeLight(yellowLight, _targetYellowMaterial, _yellowCoroutine);
                break;
            case State.Green:
                ChangeLight(greenLight, _targetGreenMaterial, _greenCoroutine);
                break;
            case State.All:
                ChangeLight(greenLight, _targetGreenMaterial, _greenCoroutine);
                ChangeLight(yellowLight, _targetYellowMaterial, _yellowCoroutine);
                ChangeLight(redLight, _targetRedMaterial, _redCoroutine);
                break;
        }
    }

    private void TurnOffTrafficLight(State state)
    {
        switch (state)
        {
            case State.Red:
                ChangeLight(greenLight, _targetNoneColor, _greenCoroutine);
                ChangeLight(yellowLight, _targetNoneColor, _yellowCoroutine);
                break;
            case State.Yellow:
                ChangeLight(greenLight, _targetNoneColor, _greenCoroutine);
                ChangeLight(redLight, _targetNoneColor, _redCoroutine);
                break;
            case State.Green:
                ChangeLight(redLight, _targetNoneColor, _redCoroutine);
                ChangeLight(yellowLight, _targetNoneColor, _yellowCoroutine);
                break;
            case State.GreenAndYellow:
                ChangeLight(redLight, _targetNoneColor, _redCoroutine);
                break;
            case State.RedAndYellow:
                ChangeLight(greenLight, _targetNoneColor, _greenCoroutine);
                break;
            case State.None:
                ChangeLight(redLight, _targetNoneColor, _redCoroutine);
                ChangeLight(yellowLight, _targetNoneColor, _yellowCoroutine);
                ChangeLight(greenLight, _targetNoneColor, _greenCoroutine);
                break;
        }
    }

    IEnumerator ChangeColor(GameObject targetObject, Color targetColor)
    {
        var currentMaterial = targetObject.GetComponent<Renderer>().material;

        _elapsedTime = 0f;

        while (_elapsedTime < animationDuration)
        {
            float t = Mathf.Clamp01(_elapsedTime / animationDuration);
            var currentColor = Color.Lerp(currentMaterial.color, targetColor, t);
            Color currentEmission = Color.Lerp(currentMaterial.GetColor("_EmissionColor"),
                targetColor * _targetIntensity * 3.65f, t);

            currentMaterial.color = currentColor;
            currentMaterial.SetColor("_EmissionColor", currentEmission);

            yield return null;

            _elapsedTime += Time.deltaTime;
        }
    }

    private void ChangeLight(GameObject[] targetObjects, Color targetColor, Coroutine coroutine)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        for (var i = 0; i < targetObjects.Length; i++)
        {
            coroutine = StartCoroutine(ChangeColor(targetObjects[i], targetColor));
        }
    }
}