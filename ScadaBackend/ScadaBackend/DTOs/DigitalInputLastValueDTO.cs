using ScadaBackend.Models;

namespace ScadaBackend.DTOs
{
    public class DigitalInputLastValueDTO
    {
        public DigitalInput DigitalInput { get; set; }
        public TagChange LastTagChange { get; set; }
    }
}
