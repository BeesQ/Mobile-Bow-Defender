using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    private static Camera _camera;
    public static Camera Camera
    {
        get
        {
            if (_camera == null) { _camera = Camera.main; }
            return _camera;
        }
    }

    private static readonly Dictionary<float, WaitForSeconds> WaitDictionary = new Dictionary<float, WaitForSeconds>();
    public static WaitForSeconds GetWaitInSeconds(float  time)
    {
        if (WaitDictionary.TryGetValue(time, out var wait)) { return wait; }

        WaitDictionary[time] = new WaitForSeconds(time);
        return WaitDictionary[time];
    } 
}
