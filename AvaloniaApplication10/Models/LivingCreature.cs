using System;

namespace AvaloniaApplication10.Models
{
    public abstract class LivingCreature
    {
        private int _currentSpeed;
        
        public string Name { get; }
        public int MaxSpeed { get; }
        public int CurrentSpeed 
        { 
            get => _currentSpeed;
            protected set => _currentSpeed = Math.Clamp(value, 0, MaxSpeed);
        }
        
        public bool IsMoving => CurrentSpeed > 0;
        public object IsOnTree { get; }

        protected LivingCreature(string name, int maxSpeed)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            CurrentSpeed = 0;
        }

        public abstract void Move();
        public abstract void Stop();
    }
}