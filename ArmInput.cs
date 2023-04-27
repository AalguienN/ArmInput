using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports; //Si da errores ir a Project Settings > Player > Api Compatibility Leve > cambiar a .NET Framework
using System.Runtime.CompilerServices;

public class ArmInput
{

    //Inputs
    public static KeyCode inputForSignal1 = KeyCode.F;
    public static KeyCode inputForSignal2 = KeyCode.J;
    public static KeyCode inputForSignal3 = KeyCode.D;
    public static KeyCode inputForSignal4 = KeyCode.K;


    //Serial port
    private static float[] valuesSerialPorts = new float[4];
    private static SerialPort serialPort = new SerialPort("COM4", 9600);
    //en función de Serial.begin(n); en el arduino

    //Cada señal es equivalente a un eje
    public enum Signal
    {
        S1, S2, S3, S4,
        LBiceps, RBiceps, LTriceps, RTriceps
    }

    public static float GetSignal(string SignalName)
    {
        portCheck();

        switch (SignalName)
        {
            case "S1":
            case "LBiceps":
                return Input.GetKey(inputForSignal1) ||
                    valuesSerialPorts[0] == 1 ? 1 : 0;
            case "S2":
            case "RBiceps":
                return Input.GetKey(inputForSignal2) ||
                    valuesSerialPorts[1] == 1 ? 1 : 0;
            case "S3":
            case "LTriceps":
                return Input.GetKey(inputForSignal3) ||
                    valuesSerialPorts[2] == 1 ? 1 : 0;
            case "S4":
            case "RTriceps":
                return Input.GetKey(inputForSignal4) ||
                    valuesSerialPorts[3] == 1 ? 1 : 0;
        }
        return 0;
    }
    public static float GetSignal(Signal signal)
    {
        portCheck();

        switch (signal)
        {
            case Signal.S1:
            case Signal.LBiceps:
                return Input.GetKey(inputForSignal1) ||
                    valuesSerialPorts[0] == 1 ? 1 : 0;
            case Signal.S2:
            case Signal.RBiceps:
                return Input.GetKey(inputForSignal2) ||
                    valuesSerialPorts[1] == 1 ? 1 : 0;
            case Signal.S3:
            case Signal.LTriceps:
                return Input.GetKey(inputForSignal3) ||
                    valuesSerialPorts[2] == 1 ? 1 : 0;
            case Signal.S4:
            case Signal.RTriceps:
                return Input.GetKey(inputForSignal4) ||
                    valuesSerialPorts[3] == 1 ? 1 : 0;
        }
        return 0;
    }

    private static void portCheck()
    {
        try
        {
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
                serialPort.ReadTimeout = 1;
            }
            string[] s = serialPort.ReadLine().Split(',');
            for (int i = 0; i < s.Length; i++)
                valuesSerialPorts[i] = float.Parse(s[i]);
        }
        catch
        {

        }
    }

    public static Vector2 GetSignalLeftArm()
    {
        return new Vector2(GetSignal(Signal.LBiceps), GetSignal(Signal.LTriceps));
    }

    public static Vector2 GetSignalRightArm()
    {
        return new Vector2(GetSignal(Signal.RBiceps), GetSignal(Signal.RTriceps));
    }

    public static Vector4 GetAllSignals()
    {
        return new Vector4(GetSignal(Signal.S1), GetSignal(Signal.S2), GetSignal(Signal.S3), GetSignal(Signal.S4));
    }
}
