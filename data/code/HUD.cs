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

[Component(PropertyGuid = "530942ed52879003506d9dfaee3941821f844db7")]
public class HUD : Component
{
	// параметры прицела
    public AssetLink crosshairImage = null;
    public int crosshairSize = 16;

    private WidgetSprite sprite = null;
    private Gui screenGui = null;
    private ivec2 prev_size = new ivec2(0, 0);
	
	private void Init()
	{
		// write here code to be called on component initialization
		// получаем текущий экранный GUI
   	 screenGui = Gui.GetCurrent();

   	 // создаем виджет WidgetSprite для прицела
   	 sprite = new WidgetSprite(screenGui, crosshairImage.AbsolutePath);
   	 // задаем размер спрайта
   	 sprite.Width = crosshairSize;
   	 sprite.Height = crosshairSize;

   	 // добавляем спрайт к GUI так, чтобы он всегда был посередине экрана и поверх всех остальных виджетов
   	 screenGui.AddChild(sprite, Gui.ALIGN_CENTER | Gui.ALIGN_OVERLAP);
   	 // привязываем время жизни виджета к миру
   	 sprite.Lifetime = Widget.LIFETIME.WORLD;
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		ivec2 new_size = screenGui.Size;
   	 	if (prev_size != new_size)
   	 	{
   			 screenGui.RemoveChild(sprite);
   			 screenGui.AddChild(sprite, Gui.ALIGN_CENTER | Gui.ALIGN_OVERLAP);
   	 	}
   		prev_size = new_size;
	}
}