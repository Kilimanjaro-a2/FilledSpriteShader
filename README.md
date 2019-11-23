# FilledSpriteShader

## Description

This is a shader that allows Sprite to do the same as Image.FillMethod.Radial360 in Unity.

https://docs.unity3d.com/ja/2018.4/ScriptReference/UI.Image.FillMethod.Radial360.html


## Demo
This is a demo built with WebGL

https://kilimanjaro-a2.github.io/FilledSpriteShader/


## Usage
Save the following file as **FilledSprite360.shader**.

https://gist.github.com/Kilimanjaro-a2/cc6317b43b3809b205a7273efb91372e

Then attach any material to the sprite and change the shader to **Unlit/FilledSprite360**.


```C#
Material mat = mySpriteGameObject.GetComponent<SpriteRenderer>().material;

/*
  By assigning a value to _FillAmount,
  you can change the size of the sprite display area.
  The value can be assigned a range from 0 to 1,
  and the value is mapped from 0 to 360 degrees.
  For example, if it is 0.75, the sprite display area will be 0 to 270 degrees.
*/
mat.SetFloat("_FillAmount", 0.75);


/*
  By assigning a value to _Clockwise, 
  You can set whether the direction of increasing the sprite display area is clockwise.
  The value can only be set to 0 or 1.
  If it is 1, it will be clockwise.
*/
mat.SetFloat("_Clockwise", 0);


/*
  By assigning values ​​to _FillOriginX and _FillOriginY,
  you can determine the direction from which the sprite display area starts.
  Each value ranges from -1 to 1.
  For example, if _FillOriginX is 1 and _FillOriginY is 0,
  the direction from which the display area starts is from the center of the right edge.
*/
mat.SetFloat("_FillOriginX", 1);
mat.SetFloat("_FillOriginY", 0);
```

Refer to **Assets/Plugin/FilledSprite/Samples** for detailed usage.