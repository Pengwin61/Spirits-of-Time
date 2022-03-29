﻿using System.Collections.Generic;
using UnityEngine;

public static class Yielders
{
    private class FloatComparer : IEqualityComparer<float>
    {
        bool IEqualityComparer<float>.Equals(float x, float y) => x == y;

        int IEqualityComparer<float>.GetHashCode(float obj) => obj.GetHashCode();
    }

    private static Dictionary<float, WaitForSeconds> _timeIntervals =
        new Dictionary<float, WaitForSeconds>(100, new FloatComparer());

    private static WaitForEndOfFrame _endOfFrame = new WaitForEndOfFrame();
    private static WaitForFixedUpdate _fixedUpdate = new WaitForFixedUpdate();

    public static WaitForEndOfFrame EndOfFrame => _endOfFrame;
    public static WaitForFixedUpdate FixedUpdate => _fixedUpdate;

    public static WaitForSeconds WaitForSeconds(float seconds)
    {
        if (!_timeIntervals.TryGetValue(seconds, out var waitForSeconds))
        {
            _timeIntervals.Add(seconds, waitForSeconds = new WaitForSeconds(seconds));
        }
        return waitForSeconds;
    }

    //TO DO: Simple impl is not working
    public static WaitForSecondsRealtime WaitForSecondsRealtime(float seconds) => new WaitForSecondsRealtime(seconds);
}