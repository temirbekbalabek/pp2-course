using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public enum ShipType
    {
        D1,
        D2,
        D3,
        D4
    }
    public enum ShipDirection
    {
        up,
        down,
        left,
        right
    }
    class Ship
    {
        public List<ShipPoint> body = new List<ShipPoint>();
        ShipType type;
        public static ShipDirection direction = ShipDirection.right;

        public Ship(Point p, ShipType type)
        {
            this.type = type;
            GenerateBody(p);
        }

        public void GenerateBody(Point p)
        {
            switch (direction)
            {
                case ShipDirection.down:
                    Down(p);
                    break;
                case ShipDirection.up:
                    Up(p);
                    break;
                case ShipDirection.right:
                    Right(p);
                    break;
                case ShipDirection.left:
                    Left(p);
                    break;
                default:
                    break;
            }


        }
        public void Up(Point p)
        {
            switch (type)
            {
                case ShipType.D1:
                    body.Add(new ShipPoint { X = p.X, Y = p.Y, PType = PartType.ShipPart });
                    break;
                case ShipType.D2:
                    for (int i = 0; i < 2; ++i)
                    {
                        body.Add(new ShipPoint { X = p.X, Y = p.Y - i, PType = PartType.ShipPart });
                    }
                    break;
                case ShipType.D3:
                    for (int i = 0; i < 3; ++i)
                    {
                        body.Add(new ShipPoint { X = p.X, Y = p.Y - i, PType = PartType.ShipPart });
                    }
                    break;
                case ShipType.D4:
                    for (int i = 0; i < 4; ++i)
                    {
                        body.Add(new ShipPoint { X = p.X, Y = p.Y - i, PType = PartType.ShipPart });
                    }
                    break;
                default:
                    break;
            }
        }
        public void Down(Point p)
        {
            switch (type)
            {
                case ShipType.D1:
                    body.Add(new ShipPoint { X = p.X, Y = p.Y, PType = PartType.ShipPart });
                    break;
                case ShipType.D2:
                    for (int i = 0; i < 2; ++i)
                    {
                        body.Add(new ShipPoint { X = p.X, Y = p.Y + i, PType = PartType.ShipPart });
                    }
                    break;
                case ShipType.D3:
                    for (int i = 0; i < 3; ++i)
                    {
                        body.Add(new ShipPoint { X = p.X, Y = p.Y + i, PType = PartType.ShipPart });
                    }
                    break;
                case ShipType.D4:
                    for (int i = 0; i < 4; ++i)
                    {
                        body.Add(new ShipPoint { X = p.X, Y = p.Y + i, PType = PartType.ShipPart });
                    }
                    break;
                default:
                    break;
            }
        }
        public void Right(Point p)
        {
            switch (type)
            {
                case ShipType.D1:
                    body.Add(new ShipPoint { X = p.X, Y = p.Y, PType = PartType.ShipPart });
                    break;
                case ShipType.D2:
                    for (int i = 0; i < 2; ++i)
                    {
                        body.Add(new ShipPoint { X = p.X + i, Y = p.Y, PType = PartType.ShipPart });
                    }
                    break;
                case ShipType.D3:
                    for (int i = 0; i < 3; ++i)
                    {
                        body.Add(new ShipPoint { X = p.X + i, Y = p.Y, PType = PartType.ShipPart });
                    }
                    break;
                case ShipType.D4:
                    for (int i = 0; i < 4; ++i)
                    {
                        body.Add(new ShipPoint { X = p.X + i, Y = p.Y, PType = PartType.ShipPart });
                    }
                    break;
                default:
                    break;
            }
        }
        public void Left(Point p)
        {
            switch (type)
            {
                case ShipType.D1:
                    body.Add(new ShipPoint { X = p.X, Y = p.Y, PType = PartType.ShipPart });
                    break;
                case ShipType.D2:
                    for (int i = 0; i < 2; ++i)
                    {
                        body.Add(new ShipPoint { X = p.X - i, Y = p.Y, PType = PartType.ShipPart });
                    }
                    break;
                case ShipType.D3:
                    for (int i = 0; i < 3; ++i)
                    {
                        body.Add(new ShipPoint { X = p.X - i, Y = p.Y, PType = PartType.ShipPart });
                    }
                    break;
                case ShipType.D4:
                    for (int i = 0; i < 4; ++i)
                    {
                        body.Add(new ShipPoint { X = p.X - i, Y = p.Y, PType = PartType.ShipPart });
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
