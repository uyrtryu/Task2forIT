using System;

namespace AvaloniaApplication10.Models
{
    public class Dog : LivingCreature
    {
        public event Action<string>? BarkEvent = null;

        public Dog(string name) : base(name, 40) { }

        public override void Move()
        {
            CurrentSpeed += 10;
        }

        public override void Stop()
        {
            CurrentSpeed -= 10;
        }

        public void Bark()
        {
            BarkEvent?.Invoke($"{Name} лает: Гав-гав!");
        }
    }
}