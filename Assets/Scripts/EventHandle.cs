using System;
using UnityEngine;

public class EventHandle
{

	public static event Action EventChangeScene;
	public static void CallEventChangeScene()
	{
		Action events = EventHandle.EventChangeScene;
		if (events == null)
		{
			return;
		}
		events();
	}
	public static event Action EventShowLineTip;
	public static void CallEventShowLineTip()
	{
		Action events = EventHandle.EventShowLineTip;
		if (events == null)
		{
			return;
		}
		events();
	}

	public static event Action EventHideLineTip;
	public static void CallEventHideLineTip()
	{
		Action events = EventHandle.EventHideLineTip;
		if (events == null)
		{
			return;
		}
		events();
	}
}
