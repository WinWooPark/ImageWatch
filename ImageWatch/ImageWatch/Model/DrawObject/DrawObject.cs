﻿namespace ImageWatch.Model.DrawObject
{
    public class DrawObject
    {
        public DrawObject()
        {
            drawEllipses = new Queue<DrawEllipse>();
            drawLines = new Queue<DrawLine>();
            drawRects = new Queue<DrawRect>(); 
        }
        public Queue<DrawEllipse> drawEllipses;
        public Queue<DrawLine> drawLines;
        public Queue<DrawRect> drawRects;

        public void DeleteAllDrawObject() 
        {
            if(drawEllipses.Count != 0)
                drawEllipses.Clear();

            if (drawLines.Count != 0)
                drawLines.Clear();

            if (drawRects.Count != 0)
                drawRects.Clear();
        }
    }
}
