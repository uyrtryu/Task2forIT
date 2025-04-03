using System;

namespace AvaloniaApplication10.Models
{
    public class Panther : LivingCreature
    {
        public event Action<string>? RoarEvent = null;
        
        public bool IsOnTree { get; private set; }

        public Panther(string name) : base(name, 100) { }

        public override void Move()
        {
            CurrentSpeed += 20;
        }

        public override void Stop()
        {
            CurrentSpeed -= 20;
        }

        public void ClimbTree()
        {
            IsOnTree = true;
        }

        public void DescendFromTree()
        {
            IsOnTree = false;
        }

        public void Roar()
        {
            RoarEvent?.Invoke($"{Name} рычит: РРРРР!");
        }
    }
}