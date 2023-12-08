namespace EventReservationSystem.Commands
{
    public class UpdateReservaCommand
    {
        public int ReservaId { get; set; }
        public string NovoStatus { get; set; } 
        public DateTime NovaData { get; set; } 
    }
}
