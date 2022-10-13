using System;
using UnityEngine;

public class EventHandle
{

	public static event Action EventStart;
	public static void CallEventStart()
	{
		Action eventStart = EventHandle.EventStart;
		if (eventStart == null)
		{
			return;
		}
		eventStart();
	}

}
