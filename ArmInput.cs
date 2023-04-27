using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmInput : MonoBehaviour {

    public static ArmInput instance;

    [Header("Inputs")]

    public KeyCode inputForSignal1 = KeyCode.F;
    public KeyCode inputForSignal2 = KeyCode.J;
    public KeyCode inputForSignal3 = KeyCode.D;
    public KeyCode inputForSignal4 = KeyCode.K;


    //Cada señal es equivalente a un eje
    private static float Signal1;
    private static float Signal2;
    private static float Signal3;
    private static float Signal4;


    public enum Signal{
        S1, S2, S3, S4,
        LBiceps, RBiceps, LTriceps, RTriceps
    }

    // Start is called before the first frame update
    void Start()
    {
        if (ArmInput.instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(inputForSignal1)) Signal1 = 1; else Signal1 = 0;
        if (Input.GetKey(inputForSignal2)) Signal2 = 1; else Signal2 = 0;
        if (Input.GetKey(inputForSignal3)) Signal3 = 1; else Signal3 = 0;
        if (Input.GetKey(inputForSignal4)) Signal4 = 1; else Signal4 = 0;
    }

    public static float GetSignal(string SignalName) {
        switch (SignalName) {
            case "S1":
            case "LBiceps":
                return Signal1;
            case "S2":
            case "RBiceps":
                return Signal2;
            case "S3":
            case "LTriceps":
                return Signal3;
            case "S4":
            case "RTriceps":
                return Signal4;
        }
        return 0;
    }
    public static float GetSignal(Signal signal)
    {
        switch (signal)
        {
            case Signal.S1:
            case Signal.LBiceps:
                return Signal1;
            case Signal.S2:
            case Signal.RBiceps:
                return Signal2;
            case Signal.S3:
            case Signal.LTriceps:
                return Signal3;
            case Signal.S4:
            case Signal.RTriceps:
                return Signal4;
        }
        return 0;
    }
}
