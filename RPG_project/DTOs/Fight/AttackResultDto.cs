namespace RPG_project.DTOs.Fight
{
    public class AttackResultDto
    {
        public int AttackerId { get; set; }
        public string AttackerName { get; set; }
        public int AttakerHP { get; set; }
        public int OpponentId { get; set; }
        public string OpponentName { get; set; }
        public int OpponentHp { get; set; }
        public int Damage { get; set; }
    }
}