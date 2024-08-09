using Microsoft.AspNetCore.Components;
using PokemonBlazor.Services;

namespace PokemonBlazor.Components.Pages
{
    public partial class Benzin
    {
        private List<GasPricePoint>? miles95PricePoints;
        private List<GasPricePoint>? dieselPricePoints;

        protected override async Task OnInitializedAsync()
        {
            miles95PricePoints = await CircleKApi.GetAsync<List<GasPricePoint>?>("miles95");
            dieselPricePoints = await CircleKApi.GetAsync<List<GasPricePoint>?>("diesel");
        }

        public class GasPricePoint
        {
            public decimal Price { get; set; }
            public DateTime Date { get; set; }
        }
    }
}