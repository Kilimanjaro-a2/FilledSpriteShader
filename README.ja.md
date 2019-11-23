# FilledSpriteShader

## Description

これは、SpriteでImage.FillMethod.Radial360の動きを再現するためのシェーダーです。

https://docs.unity3d.com/ja/2018.4/ScriptReference/UI.Image.FillMethod.Radial360.html


## Demo
WebGL版のビルドです

https://kilimanjaro-a2.github.io/FilledSprite/


## Usage
以下のファイルをFilledSprite360.shaderとして保存します。

https://gist.github.com/Kilimanjaro-a2/cc6317b43b3809b205a7273efb91372e

その後、スプライトに任意のマテリアルをアタッチし、シェーダーをUnlit/FilledSprite360に変更します。


```C#
Material mat = mySpriteGameObject.GetComponent<SpriteRenderer>().material;

/*
  _FillAmountに値を代入することで、
  スプライトの表示領域の大きさを変えることができます。
  値は0から1の範囲を代入でき、その値は0から360°にマッピングされます。
  例えば0.75であれば0°から270°までの範囲でスプライトが表示されます。
*/
mat.SetFloat("_FillAmount", 0.75);


/*
  _Clockwiseに値を代入することで、
  スプライトの表示領域が増える方向が時計周りかどうかを設定できます。
  値は0か1のみを設定することができ、1の場合に時計回りになります。
*/
mat.SetFloat("_Clockwise", 0);


/*
  _FillOriginX, _FillOriginYに値を代入することで、
  スプライトの表示領域が開始される方角を決めることができます。
  値はそれぞれ-1から1までの値をとります。
  例えば_FillOriginXが1で、_FillOriginYが0の場合、
  表示領域が開始する方角は右端の中央からになります。
*/
mat.SetFloat("_FillOriginX", 1);
mat.SetFloat("_FillOriginY", 0);
```


詳しい使い方はAssets/Plugin/FilledSprite/Samplesを参照してください。