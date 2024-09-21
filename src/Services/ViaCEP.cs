using RestSharp;

namespace Ultracar.Services;

public class ViaCEP
{
    private readonly RestClient _client;

    public ViaCEP()
    {
        _client = new RestClient("https://viacep.com.br");
    }

    public async Task<ViaCepResponse> GetAddress(string cep)
    {
        var req = new RestRequest($"/ws/{cep}/json");
        var address = await _client.GetAsync<ViaCepResponse>(req);

        if (address == null)
            throw new Exception("Ocorreu um erro ao buscar o endereço");

        return address;
    }
}

public class ViaCepResponse
{
    public string Logradouro { get; set; } = null!;
    public string Bairro { get; set; } = null!;
    public string Localidade { get; set; } = null!;
    public string Estado { get; set; } = null!;
}