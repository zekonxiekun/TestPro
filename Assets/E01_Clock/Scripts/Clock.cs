using System.Collections;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    public Transform transform_Hour;
    public Transform transform_Minute;
    public Transform transform_Second;
    IEnumerator updateArms;
    int a;

    private void Awake()
    {
        updateArms = UpdateArms();
        a = 0;
    }

    private void Start()
    {
        StartCoroutine(updateArms);

    }

    private IEnumerator UpdateArms()
    {
        WaitForSeconds wfs = new WaitForSeconds(1);
        TimeSpan now;
        while (wfs!=null)
        {
            now = DateTime.Now.TimeOfDay;
            Debug.Log("hour:"+(float)now.TotalHours+" | minute:"+ (float)now.TotalMinutes+" | second:"+ (float)now.Seconds);
            transform_Hour.localRotation = Quaternion.Euler(0f, (float)now.TotalHours * 30f, 0);
            transform_Minute.localRotation = Quaternion.Euler(0f, (float)now.TotalMinutes * 6f, 0);
            transform_Second.localRotation = Quaternion.Euler(0f, now.Seconds * 6f, 0);
            yield return wfs;
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(updateArms);
    }

}
