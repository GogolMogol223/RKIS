﻿using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
class Risovatel
    {
        static float x, y;
        static IGraphics graphics;

        public static void Initialization(Graphics newGraphics)
        {
            graphics = newGraphics;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Color.Black);
        }

        public static void SetPosition(float x0, float y0)
        {
            x = x0;
            y = y0;
        }

        public static void MakeIt(Pen pen, double isLong, double angle)
        {
            //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
            var x1 = (float)(x + isLong * Math.Cos(angle));
            var y1 = (float)(y + isLong * Math.Sin(angle));
            graphics.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Change(double isLong, double angle)
        {
            x = (float)(x + isLong * Math.Cos(angle));
            y = (float)(y + isLong * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {

        public static void Draw(int width, int height, double angleOfRotation, Graphics graphics)
        {

            Risovatel.Initialization(graphics);

            var min = Math.Min(width, height);
            var diagonalLength = Math.Sqrt(2) * (min * 0.375f + min * 0.04f) / 2;
            var x0 = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Risovatel.SetPosition(x0, y0);

            //Рисуем 1-ую сторону
            Risovatel.MakeIt(Pens.Yellow, min * 0.375f, 0);
            Risovatel.MakeIt(Pens.Yellow, min * 0.04f * Math.Sqrt(2), Math.PI / 4);
            Risovatel.MakeIt(Pens.Yellow, min * 0.375f, Math.PI);
            Risovatel.MakeIt(Pens.Yellow, min * 0.375f - min * 0.04f, Math.PI / 2);

            Risovatel.Change(min * 0.04f, -Math.PI);
            Risovatel.Change(min * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4);

            //Рисуем 2-ую сторону
            Risovatel.MakeIt(Pens.Yellow, min * 0.375f, -Math.PI / 2);
            Risovatel.MakeIt(Pens.Yellow, min * 0.04f * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
            Risovatel.MakeIt(Pens.Yellow, min * 0.375f, -Math.PI / 2 + Math.PI);
            Risovatel.MakeIt(Pens.Yellow, min * 0.375f - min * 0.04f, -Math.PI / 2 + Math.PI / 2);

            Risovatel.Change(min * 0.04f, -Math.PI / 2 - Math.PI);
            Risovatel.Change(min * 0.04f * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);

            //Рисуем 3-ю сторону
            Risovatel.MakeIt(Pens.Yellow, min * 0.375f, Math.PI);
            Risovatel.MakeIt(Pens.Yellow, min * 0.04f * Math.Sqrt(2), Math.PI + Math.PI / 4);
            Risovatel.MakeIt(Pens.Yellow, min * 0.375f, Math.PI + Math.PI);
            Risovatel.MakeIt(Pens.Yellow, min * 0.375f - min * 0.04f, Math.PI + Math.PI / 2);

            Risovatel.Change(min * 0.04f, Math.PI - Math.PI);
            Risovatel.Change(min * 0.04f * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);

            //Рисуем 4-ую сторону
            Risovatel.MakeIt(Pens.Yellow, min * 0.375f, Math.PI / 2);
            Risovatel.MakeIt(Pens.Yellow, min * 0.04f * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
            Risovatel.MakeIt(Pens.Yellow, min * 0.375f, Math.PI / 2 + Math.PI);
            Risovatel.MakeIt(Pens.Yellow, min * 0.375f - min * 0.04f, Math.PI / 2 + Math.PI / 2);

            Risovatel.Change(min * 0.04f, Math.PI / 2 - Math.PI);
            Risovatel.Change(min * 0.04f * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
        }
}
}
