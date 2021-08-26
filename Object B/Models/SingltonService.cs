using System.Collections.Generic;
using static Object_B.Services.CalculationCoordinatesService;

namespace Object_B.Models
{
    public class SingltonService
    {
        public List<Square[]> rooms { get; set; }
        public Dictionary<string, Square> dictionaryCoords { get; set; }
    }
}
