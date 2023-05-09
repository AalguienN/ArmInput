using System;
using System.Collections;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;


public class Recorder : MonoBehaviour{

    public float secToWait = 0.1f;

    private long count;

    public static Recorder entity;

    Session session;

    private bool rec;

    

    private void Start()
    {
        count = 0;

        if (entity == null)
        {
            entity = this;
        }
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) { StartRecording(); }
        if (Input.GetKeyDown(KeyCode.A)) { StopRecording(); }
    }

    public IEnumerator tick() {
        yield return new WaitForSeconds(secToWait);
        if (rec)
            StartCoroutine(tick());
        Vector4 aux = ArmInput.GetAllSignals();
        Debug.Log(aux.x.ToString()+aux.y.ToString()+aux.z.ToString()+aux.w.ToString() + "," + (count++) );
        actualizarSesion();
        
    }

    public void actualizarSesion() {
        Vector4 aux = ArmInput.GetAllSignals();
        if (session != null)
        {
            session.Update(aux.x.ToString() + aux.y.ToString() + aux.z.ToString() + aux.w.ToString());
        }
        else rec = false;
    }

    public void StartRecording() {
        count = 0;
        StopRecording();
        session = new Session();
        rec = true;
        StartCoroutine(tick());
    }

    public void StopRecording() {
        if (session != null) { 
            session.Save();
        }
        rec = false;
        session = null;
    }
}
