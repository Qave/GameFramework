using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameFramework.Factory
{
    public abstract class AbstractFactory
    {
        private readonly Random _rnd = new Random();
        protected readonly World _world;
        public TraceSource TraceSource { get; set; }

        public AbstractFactory(World world, TraceSource traceSource)
        {
            _world = world;
            TraceSource = traceSource;
        }

        public Position RndPos()
        {
            Position newPos = new Position(_rnd.Next(1, _world.SizeX - 1), _rnd.Next(1, _world.SizeY - 1));
            List<(int, int)> ExistingPositions = new List<(int, int)>();
            foreach (var item in _world.WorldObjects)
            {
                ExistingPositions.Add((item.Position.PosX, item.Position.PosY));
            }
            if (ExistingPositions.Contains((newPos.PosX, newPos.PosY)))
            {
                RndPos();
            }
            return newPos;
        }
    }
}
