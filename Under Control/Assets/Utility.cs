using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Point
{
    public float x;
    public float y;
    public Point (float X, float Y)
    {
        x = X;
        y = Y;
    }
    public Point (Vector2 vec)
    {
        x = vec.x;
        y = vec.y;
    }
    public Point (Vector3 vec)
    {
        x = vec.x;
        y = vec.y;
    }
    public Point (Rect rec)
    {
        x = rec.x;
        y = rec.y;
    }
    public Point (Point p)
    {
        x = p.x;
        y = p.y;
    }
    public static Point operator+ (Point p1, Point p2)
    {
        return new Point(p1.x + p2.x, p1.y + p2.y);
    }
    public static Point operator- (Point p1, Point p2)
    {
        return new Point(p1.x - p2.x, p1.y - p2.y);
    }
}

public class GraphMath
{
    public static bool IsPointInRect(Point p, Rect r)
    {
        if ((p.x > r.x) && (p.x < r.x + r.width) &&
            (p.y > r.y) && (p.y < r.y + r.height))
        {
            return true;
        }
        //Debug.Log(p.x.ToString() + " " + p.y.ToString() + " " + r.x.ToString() + " " + r.y.ToString() + " " + r.width.ToString() + " " + r.height.ToString());
        return false;
    }
    /*public static Point SetPointInRect(Point p, Rect r)
    {
        Point ans = new Point(p);
        ans.x = Mathf.Max(Mathf.Min(p.x, r.width), 0);
        ans.y = Mathf.Max(Mathf.Min(p.y, r.height), 0);
        return ans;
    }*/
}

public class Mouse
{
    public static Point Position
    {
        get
        {
            return new Point(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        }
    }
}