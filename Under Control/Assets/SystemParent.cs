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

	public override void Draw()
	{
		base.Draw();
		GUI.Box(Rect, Mouse.Position.x.ToString() + " " + Mouse.Position.y.ToString());
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
		sys_draw.Draw();
    }
    //Update is called once per turn
    public virtual void Turn()
    {

    }
}
