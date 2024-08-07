using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction
{
    West,
    East,
    North,
    South
}
public static class MapHelper 
{


    public static Vector2 ToPoint(this Direction dir)
    {
        return dir switch
        {
            Direction.East => new Vector2(1, 0),
            Direction.West => new Vector2(-1, 0),
            Direction.North => new Vector2(0, 1),
            Direction.South => new Vector2(0, -1),
            _ => throw new System.NotImplementedException(),
        };
    }

    public static bool Exists<T>(this T[][] array, int y, int x)
    {
        return (y >= 0 && y < array.Length && x >= 0 && x < array[y].Length);
    }

    public static T Get<T>(this T[][] array, int y, int x, Direction direction, T errorValue)
    {
        var point = direction.ToPoint();

        if (array.Exists(y + (int)point.y, x + (int)point.x))
        { 
            return array[y + (int)point.y][x + (int)point.x];
        }

        return errorValue;
    }
}
