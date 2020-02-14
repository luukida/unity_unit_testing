using System;
using UnityEngine;

public class PointsCalculator
{
    public int CalculatePoints(int killedEnemies, int killedAllies, int multiplicator)
    {
        if (killedEnemies < 0)
            throw new ArgumentOutOfRangeException("killedEnemies must be zero or greater than zero");
            
        if (killedAllies < 0)
            throw new ArgumentOutOfRangeException("killedAllies must be zero or greater than zero");

        if (multiplicator < 1)
            throw new ArgumentOutOfRangeException("multiplicator must be greater than zero");

        var points = 0;

        points += killedEnemies * 100;

        points += Mathf.FloorToInt(killedEnemies / 10) * 500;

        points -= killedAllies * 100;

        if(killedAllies >= 10)
            multiplicator = 1;

        points *= multiplicator;

        if (points < 0)
            points = 0;

        return points;
    }
}
