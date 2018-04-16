using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{

    public enum CellState
    {
        empty,
        busy,
        aura,
        striked,
        missed,
        killed
    }



    public delegate void MyDelegate(CellState[,] map);

    public class Brain
    {

        public ShipType[] st = {ShipType.D4,
                          ShipType.D3, ShipType.D3,
                          ShipType.D2, ShipType.D2, ShipType.D2,
                          ShipType.D1, ShipType.D1, ShipType.D1, ShipType.D1};

        public int stIndex = -1;
        public CellState[,] map = new CellState[10, 10];
        List<Ship> units = new List<Ship>();

        MyDelegate invoker;
        public Brain(MyDelegate invoker)
        {
            this.invoker = invoker;
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    map[i, j] = CellState.empty;
                }
            }
            invoker.Invoke(map);


        }

        public bool Process2(string msg)
        {
            bool successShoot = false;

            string[] val = msg.Split('_');
            int i = int.Parse(val[0]);
            int j = int.Parse(val[1]);

            switch (map[i, j])
            {
                case CellState.empty:
                    map[i, j] = CellState.missed;
                    break;
                case CellState.busy:
                    map[i, j] = CellState.striked;
                    successShoot = true;

                    int index = -1;
                    for (int k = 0; k < units.Count; ++k)
                    {
                        foreach (ShipPoint p in units[k].body)
                        {
                            if (p.X == i && p.Y == j)
                            {
                                index = k;
                                break;
                            }
                        }
                        if (index != -1)
                        {
                            break;
                        }

                    }

                    if (index != -1)
                    {
                        bool killed = true;

                        foreach (ShipPoint p in units[index].body)
                        {
                            if (map[p.X, p.Y] != CellState.striked)
                            {
                                killed = false;
                                break;
                            }
                        }

                        if (killed)
                        {

                            foreach (ShipPoint p in units[index].body)
                            {
                                map[p.X, p.Y] = CellState.killed;

                            }

                            MarkAuraLocation(units[index], CellState.missed);

                        }
                    }

                    break;
                case CellState.aura:
                    map[i, j] = CellState.missed;
                    break;
                case CellState.striked:
                    break;
                case CellState.missed:
                    break;
                case CellState.killed:
                    break;
                default:
                    break;
            }

            invoker.Invoke(map);
            return successShoot;
        }

        public void Process(string msg)
        {
            string[] val = msg.Split('_');
            int i = int.Parse(val[0]);
            int j = int.Parse(val[1]);
            Point p = new Point(i, j);

            ShipPlacement(p);

        }

        private bool IsGoodCell(int i, int j)
        {
            if (i < 0 || i > 9) return false;
            if (j < 0 || j > 9) return false;


            return (map[i, j] == CellState.empty);
        }
        private bool IsGoodCellForAura(int i, int j)
        {
            if (i < 0 || i > 9) return false;
            if (j < 0 || j > 9) return false;


            return (map[i, j] == CellState.empty || map[i,j] == CellState.aura);
        }
        private bool IsGoodLocated(Ship ship)
        {
            bool res = true;

            foreach (ShipPoint p in ship.body)
            {
                if (!IsGoodCell(p.X, p.Y))
                {
                    res = false;
                    break;
                }
            }

            return res;
        }


        private void MarkCell(int i, int j)
        {
            map[i, j] = CellState.busy;
        }

        private void MarkAuraCell(int i, int j, CellState cellState)
        {
            if (IsGoodCellForAura(i, j)) { 

                map[i, j] = cellState;
            }
        }
        private void MarkLocation(Ship ship)
        {
            foreach (ShipPoint p in ship.body)
            {
                MarkCell(p.X, p.Y);
            }
            
        }
        private void MarkAuraLocationRight(Ship ship, CellState cellState)
        {
            for (int i = 0; i < ship.body.Count; i++)
            {
                if (i != 0 || i != ship.body.Count - 1)
                {
                    MarkAuraCell(ship.body[i].X, ship.body[i].Y - 1, cellState);
                    MarkAuraCell(ship.body[i].X, ship.body[i].Y + 1, cellState);

                }
                if (i == 0)
                {
                    MarkAuraCell(ship.body[i].X - 1, ship.body[i].Y, cellState);
                    MarkAuraCell(ship.body[i].X - 1, ship.body[i].Y - 1, cellState);
                    MarkAuraCell(ship.body[i].X - 1, ship.body[i].Y + 1, cellState);
                    MarkAuraCell(ship.body[i].X, ship.body[i].Y - 1, cellState);
                    MarkAuraCell(ship.body[i].X, ship.body[i].Y + 1, cellState);

                }
                if (i == ship.body.Count - 1)
                {
                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y, cellState);
                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y + 1, cellState);
                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y - 1, cellState);
                    MarkAuraCell(ship.body[i].X, ship.body[i].Y - 1, cellState);
                    MarkAuraCell(ship.body[i].X, ship.body[i].Y + 1, cellState);

                }

            }
        }
        private void MarkAuraLocationLeft(Ship ship, CellState cellState)
        {
            for (int i = 0; i < ship.body.Count; i++)
            {
                if (i != 0 || i != ship.body.Count - 1)
                {
                    MarkAuraCell(ship.body[i].X, ship.body[i].Y - 1, cellState);
                    MarkAuraCell(ship.body[i].X, ship.body[i].Y + 1, cellState);

                }
                if (i == 0)
                {
                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y, cellState);
                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y + 1, cellState);
                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y - 1, cellState);
                    MarkAuraCell(ship.body[i].X, ship.body[i].Y - 1, cellState);
                    MarkAuraCell(ship.body[i].X, ship.body[i].Y + 1, cellState);

                }
                if (i == ship.body.Count - 1)
                {
                    MarkAuraCell(ship.body[i].X - 1, ship.body[i].Y, cellState);
                    MarkAuraCell(ship.body[i].X - 1, ship.body[i].Y - 1, cellState);
                    MarkAuraCell(ship.body[i].X - 1, ship.body[i].Y + 1, cellState); ;
                    MarkAuraCell(ship.body[i].X, ship.body[i].Y - 1, cellState);
                    MarkAuraCell(ship.body[i].X, ship.body[i].Y + 1, cellState);
                }

            }
        }
        private void MarkAuraLocationUp(Ship ship, CellState cellState)
        {
            for (int i = 0; i < ship.body.Count; i++)
            {
                if (i != 0 || i != ship.body.Count - 1)
                {
                    MarkAuraCell(ship.body[i].X - 1, ship.body[i].Y, cellState);
                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y, cellState);

                }
                if (i == 0)
                {
                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y, cellState);
                    MarkAuraCell(ship.body[i].X - 1, ship.body[i].Y, cellState);
                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y + 1, cellState);
                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y - 1, cellState);
                    MarkAuraCell(ship.body[i].X, ship.body[i].Y + 1, cellState);

                }
                if (i == ship.body.Count - 1)
                {
                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y, cellState);
                    MarkAuraCell(ship.body[i].X - 1, ship.body[i].Y, cellState);
                    MarkAuraCell(ship.body[i].X - 1, ship.body[i].Y - 1, cellState);
                    MarkAuraCell(ship.body[i].X, ship.body[i].Y - 1, cellState);
                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y - 1, cellState);
                }

            }
        }
        private void MarkAuraLocationDown(Ship ship, CellState cellState)
        {
            for (int i = 0; i < ship.body.Count; i++)
            {
                if (i != 0 || i != ship.body.Count - 1)
                {
                    MarkAuraCell(ship.body[i].X - 1, ship.body[i].Y, cellState);
                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y, cellState);

                }
                if (i == 0)
                {
                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y, cellState);
                    MarkAuraCell(ship.body[i].X - 1, ship.body[i].Y, cellState);
                    MarkAuraCell(ship.body[i].X - 1, ship.body[i].Y - 1, cellState);
                    MarkAuraCell(ship.body[i].X, ship.body[i].Y - 1, cellState);
                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y - 1, cellState);

                }
                if (i == ship.body.Count - 1)
                {

                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y, cellState); 
                    MarkAuraCell(ship.body[i].X - 1, ship.body[i].Y, cellState);
                    MarkAuraCell(ship.body[i].X - 1, ship.body[i].Y + 1, cellState);
                    MarkAuraCell(ship.body[i].X + 1, ship.body[i].Y + 1, cellState);
                    MarkAuraCell(ship.body[i].X, ship.body[i].Y + 1, cellState);
                }

            }
        }
        private void MarkAuraLocation(Ship ship, CellState cellState)
        {
            switch (Ship.direction)
            {
                case ShipDirection.up:
                    MarkAuraLocationUp(ship, cellState);
                    break;
                case ShipDirection.down:
                    MarkAuraLocationDown(ship, cellState);
                    break;
                case ShipDirection.right:
                    MarkAuraLocationRight(ship, cellState);
                    break;
                case ShipDirection.left:
                    MarkAuraLocationLeft(ship, cellState);
                    break;
                default:
                    break;

            }
         
        }


        public void ShipPlacement(Point p)
        {
            if (stIndex + 1 < st.Length)
            {
                stIndex++;
                Ship ship = new Ship(p, st[stIndex]);
                if (IsGoodLocated(ship)) {
                    units.Add(ship);
                    MarkLocation(ship);
                    MarkAuraLocation(ship, CellState.aura);
                    invoker.Invoke(map);
                }else
                {
                    stIndex--;
                }
            }

        }

    }
}
