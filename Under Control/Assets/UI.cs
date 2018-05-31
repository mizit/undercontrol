using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	protected bool pressed;
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

	protected bool IsMouseOn
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
	protected bool IsPressed
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
	protected bool IsReleased
	{
		get
		{
			if (pressed && Input.GetMouseButtonUp(0))
			{
				//pressed = false;
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

	public virtual void Processing()
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
		if (IsPressed);
		if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(0))
		{
			pressed = false;
		}
	}

	public virtual void Draw() { }
}

public class Button : GUIElement
{
	public delegate void EvClicked();

	public event EvClicked Clicked;

	public override void Processing()
	{
		base.Processing();
		if (pressed)
		{
			text = "pressed";
		}
		else
		{
			text = "not pressed";
		}
		if (IsReleased && IsMouseOn)
		{
			if (Clicked != null)
			{
				Clicked();
			}
		}
		
	}

	public string text;

	public override void Draw()
	{
		base.Draw();
		GUI.Box(Rect, text);
	}
}