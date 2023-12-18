namespace WebProgrammingProject.Models.ViewModels
{
    public class PassengerDetailsViewModel
    {
        public int flightId { get; set; }
        public string flightType { get; set; }
        public int kacKisi { get; set; }
        public double price { get; set; }
        public List<string> checkedSeats { get; set; }

    }
}
