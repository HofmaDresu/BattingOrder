namespace BattingOrder.Models
{
    public class Player
    {
        public Player(string name, Gender gender)
        {
            Name = name;
            Gender = gender;
        }

        public string Name { get; set; }
        public Gender Gender { get; set; }
    }
}
