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

#region Math Variables
#if UNIGINE_DOUBLE
using Vec3 = Unigine.dvec3;
using Mat4 = Unigine.dmat4;
#else
using Vec3 = Unigine.vec3;
using Mat4 = Unigine.mat4;
#endif
#endregion

[Component(PropertyGuid = "8ee246dc2c6b2b6615c3ad62c5d5cd3bb9fcc65e")]
public class VFXController : Component
{
	// NodeReference для эффектов вспышки выстрела и попадания
    [ParameterFile(Filter = ".node")]
    public string hitPrefab = null;

    [ParameterFile(Filter = ".node")]
    public string muzzleFlashPrefab = null;

    public void OnShoot(Mat4 transform)
    {
   	 // если не задан NodeReference эффекта вспышки, ничего не делаем
   	 if (string.IsNullOrEmpty(muzzleFlashPrefab))
   		 return;

   	 // загружаем NodeReference эффекта выстрела
   	 Node muzzleFlashVFX = World.LoadNode(muzzleFlashPrefab);
   	 // устанавливаем положение вспышки на указанные координаты дула пистолета
   	 muzzleFlashVFX.WorldTransform = transform;
    }

    public void OnHit(Vec3 hitPoint, vec3 hitNormal, Unigine.Object hitObject)
    {
   	 // если нода эффекта попадания не указана ничего не делаем
   	 if (string.IsNullOrEmpty(hitPrefab))
   		 return;

   	 // загружаем ноду эффекта попадания из файла
   	 Node hitVFX = World.LoadNode(hitPrefab);
   	 // устанавливаем загруженную ноду в указанную точку попадания и разворачиваем ее в направлении вектора нормали
   	 hitVFX.Parent = hitObject;
   	 hitVFX.WorldPosition = hitPoint;
   	 hitVFX.SetWorldDirection(hitNormal, vec3.UP, MathLib.AXIS.Y);
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