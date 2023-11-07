/* Copyright (C) 2005-2023, UNIGINE. All rights reserved.
*
* This file is a part of the UNIGINE 2 SDK.
*
* Your use and / or redistribution of this software in source and / or
* binary form, with or without modification, is subject to: (i) your
* ongoing acceptance of and compliance with the terms and conditions of
* the UNIGINE License Agreement; and (ii) your inclusion of this notice
* in any version of this software that you use or redistribute.
* A copy of the UNIGINE License Agreement is available by contacting
* UNIGINE. at http://unigine.com/
*/

using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "21f75368c3082380e1330bec990ab7e70d58055e")]
public class ShootInput : Component
{
	public bool IsShooting()
    {
   	 // возвращаем текущее состояние левой кнопки мыши и проверяем захват мыши в окне
   	 return Input.IsMouseButtonDown(Input.MOUSE_BUTTON.LEFT)  && Input.MouseGrab;;
    }
	private void Init()
	{
		// write here code to be called on component initialization
		
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		
	}
}