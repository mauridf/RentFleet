namespace RentFleet.Domain.Enums
{
    public enum TipoVeiculo
    {
        Carro,
        Moto,
        Caminhao
    }

    public enum CategoriaVeiculo
    {
        Economico,
        Intermediario,
        Luxo
    }

    public enum TipoCombustivel
    {
        Gasolina,
        Diesel,
        Eletrico,
        Flex
    }

    public enum TipoTransmissao
    {
        Manual,
        Automatica
    }

    public enum TipoTracao
    {
        Dianteira,
        Traseira,
        Integral
    }

    public enum StatusInspecao
    {
        Aprovado,
        Reprovado,
        Pendente
    }

    public enum StatusVeiculo
    {
        Disponivel,
        Alugado,
        EmManutencao
    }

    public enum StatusLocacao
    {
        Ativa,
        Finalizada
    }

    public enum TipoMoto
    {
        Esportiva,
        Custom,
        Scooter
    }

    public enum TipoCaminhao
    {
        Cegonha,
        Bau,
        Cacamba
    }

    public enum TipoCarroceria
    {
        Aberta,
        Fechada,
        Refrigerada
    }

    public enum TipoManutencao
    {
        Preventiva,
        Corretiva
    }

    public enum StatusReserva
    {
        Ativa,
        Cancelada
    }

    public enum TipoRegra
    {
        Desconto,
        Juros
    }
}