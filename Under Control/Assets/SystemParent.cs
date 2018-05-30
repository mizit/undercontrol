using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BaseSlider
{
    public BaseSlider()
    {
        min_value = 0;
        max_value = 100;
        value = 50;
    }
    private float value;
    private float min_value;
    private float max_value;

    public float Min_value
    {
        get
        {
            return min_value;
        }

        set
        {
             min_value = Mathf.Min(value, max_value);
             if (this.value < min_value)
             {
                this.value = min_value;
             }
        }
    }
    public float Max_value
    {
        get
        {
            return max_value;
        }
        set
        {
            max_value = Mathf.Max(value, min_value);
            if (this.value > max_value)
            {
                this.value = max_value;
            }
        }
    }
    public float Value
    {
        get
        {
            return value;
        }

        set
        {
            this.value = Mathf.Min(Mathf.Max(value, min_value), max_value);
        }
    }
}

/*public class Event
{
    private MonoBehaviour goal;
    private 
}*/

public class GUIElement
{
    private Rect rect;
    private Point position;
    public Rect Rect
    {
        get
        {
            return rect;
        }

        set
        {
            rect = value;
            position.x = rect.x;
            position.y = rect.y;
        }
    }
    public Point Position
    {
        get
        {
            return position;
        }

        set
        {
            position = value;
            rect.x = position.x;
            rect.y = position.y;
        }
    }

    private bool dnd;
    private bool dnd_allowed;
    private bool pressed;
    private Point dnd_offset;

    private bool DnD
    {
        get
        {
            return dnd;
        }

        set
        {
            if (DnD_allowed)
            {
                dnd = value;
            }
            else
            {
                dnd = false;
            }
        }
    }
    public bool DnD_allowed
    {
        get
        {
            return dnd_allowed;
        }

        set
        {
            dnd_allowed = value;
            if (dnd_allowed == false)
            {
                DnD = false;
            }
        }
    }

    private bool IsMouseOn
    {
        get
        {
            if (GraphMath.IsPointInRect(new Point(Mouse.Position), Rect))
            {
                return true;
            }
            return false;
        }
    }
    private bool IsPressed
    {
        get
        {
            if (IsMouseOn && Input.GetMouseButtonDown(0))
            {
                pressed = true;
                return true;
            }
            return false;
        }
    }
    private bool IsReleased
    {
        get
        {
            if (pressed && Input.GetMouseButtonUp(0))
            {
                pressed = false;
                return true;
            }
            return false;
        }
    }

    public GUIElement()
    {
        Rect = new Rect();
        Position = new Point();
    }

    private Point Dnd_offset
    {
        get
        {
            return dnd_offset;
        }

        set
        {
            dnd_offset = value;
        }
    }

    public void Processing()
    {
        if (DnD_allowed)
        {
            if (IsPressed)
            {
                DnD = true;
                Dnd_offset = Position - (new Point(Mouse.Position));
            }
            if (IsReleased)
            {
                DnD = false;
            }
        }
        if (DnD)
        {
            Position = (new Point(Mouse.Position)) + Dnd_offset;
        }
    }
}

public class SystemDraw : GUIElement
{
    private Texture2D back;
    private Texture2D slider;
    private string name;
    

    public Texture2D Back
    {
        get
        {
            return back;
        }

        set
        {
            back = value;
        }
    }
    public Texture2D Slider
    {
        get
        {
            return slider;
        }

        set
        {
            slider = value;
        }
    }
    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }
    


}

public class SystemParent : MonoBehaviour
{
    public BaseSlider Strength;
    protected float fear;
    protected float brokennes;
    protected SystemDraw sys_draw;

    public float Fear       //ползунок страха ограниченный, максимум и минимумом силы
    {
        get
        {
            return fear;
        }
        set
        {
            fear = Mathf.Min(Mathf.Max(value, Strength.Min_value), Strength.Max_value);
        }
    }
    public float Brokennes       //ползунок сокрушённости ограниченный, максимум и минимумом силы
    {
        get
        {
            return brokennes;
        }
        set
        {
            brokennes = Mathf.Min(Mathf.Max(value, Strength.Min_value), Strength.Max_value);
        }
    }

    // Use this for initialization
    void Start()
    {
        Strength = new BaseSlider();
        sys_draw = new SystemDraw();
        sys_draw.DnD_allowed = true;
        sys_draw.Rect = new Rect(0, 0, 100, 50);
        sys_draw.Name = "One";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Right"))
        {
            Strength.Value += 10;
            Debug.Log("Current strength - " + Strength.Value);
        }
        if (Input.GetButtonDown("Left"))
        {
            Strength.Value -= 10;
            Debug.Log("Current strength - " + Strength.Value);
        }
        sys_draw.Processing();
    }


    void OnGUI()
    {
        GUI.Box(sys_draw.Rect, Mouse.Position.x.ToString() + " " + Mouse.Position.y.ToString());//sys_draw.Name);
    }
    //Update is called once per turn
    void Turn()
    {

    }
}
