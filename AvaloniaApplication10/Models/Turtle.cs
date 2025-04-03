namespace AvaloniaApplication10.Models
{
    public class Turtle : LivingCreature
    {
        public Turtle(string name) : base(name, 5) { }

        public override void Move()
        {
            CurrentSpeed += 1;
        }

        public override void Stop()
        {
            CurrentSpeed -= 1;
        }
    }
}