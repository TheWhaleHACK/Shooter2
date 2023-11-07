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
#else
using Vec3 = Unigine.vec3;
#endif
#endregion

[Component(PropertyGuid = "9cbb1bd6153b1fd00faeaeba4942284a995ce6dc")]
public class WeaponController : Component
{
	public PlayerDummy shootingCamera = null;
    public ShootInput shootInput = null;
    public NodeDummy weaponMuzzle = null;
    public VFXController vfx = null;
    public int damage = 1;

    // маска Intersection чтобы определить, в какие объекты могут попадать пули
    [ParameterMask(MaskType = ParameterMaskAttribute.TYPE.INTERSECTION)]
    public int mask = ~0;

    public void Shoot()
    {
        // визуализируем эффект выстрела
   	    if (weaponMuzzle)
   		     vfx.OnShoot(weaponMuzzle.WorldTransform);
        // задаем начало отрезка (p0) в позиции камеры и конец (p1) - в точке удаленной на 100 единиц в направлении взгляда камеры
        Vec3 p0 = shootingCamera.WorldPosition;
        Vec3 p1 = shootingCamera.WorldPosition + shootingCamera.GetWorldDirection()  * 100;

        // создаем объект для хранения intersection-нормали
        WorldIntersectionNormal hitInfo = new WorldIntersectionNormal();
        // ищем первый объект, который пересекает отрезок (p0,p1)
        Unigine.Object hitObject = World.GetIntersection(p0, p1, mask, hitInfo);

        // если пересечение найдено
        if (hitObject)
        {
          	// отрисовываем нормаль к поверхности в точке попадания при помощи Visualizer
        	Visualizer.RenderVector(hitInfo.Point, hitInfo.Point + hitInfo.Normal, vec4.RED, 0.25f, false, 2.0f);
            // визуализируем эффект попадания в точке пересечения
   		    vfx.OnHit(hitInfo.Point, hitInfo.Normal, hitObject);
        }
    }
	private void Init()
	{
		// write here code to be called on component initialization
		
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		   	 // обработка пользовательского ввода: проверяем нажата ли клавиша “огонь”
   	 if (shootInput.IsShooting())
   		 Shoot();
	}
}