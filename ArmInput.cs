using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmInput : MonoBehaviour {

    public static ArmInput instance;

    [Header("Inputs")]

    [HeaderAttribute("fdsaf")]
    public KeyCode inputForAxis1 = KeyCode.F;
    public KeyCode inputForAxis2 = KeyCode.J;
    public KeyCode inputForAxis3 = KeyCode.D;
    public KeyCode inputForAxis4 = KeyCode.K;


    //Cada señal es equivalente a un eje
    private static float Signal1;
    private static float Signal2;
    private static float Signal3;
    private static float Signal4;


    public enum axis{
        A1, A2, A3, A4,
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
        if (Input.GetKey(inputForAxis1)) Signal1 = 1; else Signal1 = 0;
        if (Input.GetKey(inputForAxis2)) Signal2 = 1; else Signal2 = 0;
        if (Input.GetKey(inputForAxis3)) Signal3 = 1; else Signal3 = 0;
        if (Input.GetKey(inputForAxis4)) Signal4 = 1; else Signal4 = 0;
    }

    public static float GetAxis(string axisName) {
        switch (axisName) {
            case "A1":
            case "LBiceps":
                return Signal1;
            case "A2":
            case "RBiceps":
                return Signal2;
            case "A3":
            case "LTriceps":
                return Signal3;
            case "A4":
            case "RTriceps":
                return Signal4;
        }
        return 0;
    }
    public static float GetAxis(axis axis)
    {
        switch (axis)
        {
            case axis.A1:
            case axis.LBiceps:
                return Signal1;
            case axis.A2:
            case axis.RBiceps:
                return Signal2;
            case axis.A3:
            case axis.LTriceps:
                return Signal3;
            case axis.A4:
            case axis.RTriceps:
                return Signal4;
        }
        return 0;
    }
}
