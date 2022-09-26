using System;
using UnityEngine;

public class EventHandle
{
	public static event Action<GameObject> EventTitle;

	public static void CallEventTitle(GameObject obj)
	{
		Action<GameObject> eventTitle = EventHandle.EventTitle;
		if (eventTitle == null)
		{
			return;
		}
		eventTitle(obj);
	}

	public static event Action EventOver;
	public static void CallEventOver()
    {
		Action eventOver = EventHandle.EventOver;
		if (eventOver == null)
		{
			return;
		}
		eventOver();
	}

}
