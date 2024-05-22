using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

try
{
    // Cria a suíte
    Suite suitePremium = new(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);
    Suite suiteMaster = new(tipoSuite: "Master", capacidade: 4, valorDiaria: 50);

    // Cria os modelos de hóspedes e cadastra na lista de hóspedes
    List<Pessoa> hospedes = new();
    List<Pessoa> hospedes2 = new();

    hospedes.Add(new Pessoa(nome: "João", sobrenome: "Silva"));
    hospedes.Add(new Pessoa(nome: "Maria", sobrenome: "Oliveira"));

    hospedes2.Add(new Pessoa(nome: "Samir", sobrenome: "Oliveira"));
    hospedes2.Add(new Pessoa(nome: "Alex", sobrenome: "Figueira"));
    hospedes2.Add(new Pessoa(nome: "Luana", sobrenome: "Lopes"));

    // Cria uma nova reserva, passando a suíte e os hóspedes
    List<Reserva> reservas = new List<Reserva>();

    Reserva reserva1 = new(diasReservados: 5);
    reserva1.CadastrarSuite(suitePremium);
    reserva1.CadastrarHospedes(hospedes);
    reservas.Add(reserva1);

    Reserva reserva2 = new(diasReservados: 12);
    reserva2.CadastrarSuite(suiteMaster);
    reserva2.CadastrarHospedes(hospedes2);
    reservas.Add(reserva2);

    // Exibe a quantidade de hóspedes e o valor da diária
    foreach (var reserva in reservas)
    {
        Console.WriteLine($"\nHóspedes: {reserva.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria():C}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Exceção ocorrida: {ex.Message}");
}