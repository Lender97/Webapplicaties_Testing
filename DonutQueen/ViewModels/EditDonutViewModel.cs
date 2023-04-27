using System;

namespace DonutQueen.ViewModels
{
    public class EditDonutViewModel
    {
        public int DonutId { get; set; }
        public string Naam { get; set; }

        public string Topping { get; set; }

        public string Glazuur { get; set; }

        public string Vulling { get; set; }

        public string Omschrijving { get; set; }

        public bool IsVegan { get; set; }

        public string Afbeelding { get; set; }

        public Decimal Prijs { get; set; }
    }
}