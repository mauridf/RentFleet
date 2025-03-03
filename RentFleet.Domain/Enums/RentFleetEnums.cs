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
        Economico, // Carro
        Intermediario, // Carro
        Utilitario, // Carro
        Luxo, // Carro
        Compacto, // Carro
        Sedan, // Carro
        Hatch, // Carro
        SUV, // Carro
        Croosover, // Carro
        Picate, // Carro
        Esportivo, // Carro
        Cupe, // Carro
        Conversivel, // Carro
        Minivan, // Carro
        Eletrico_Hibrido, // Carro
        Utilitario_Esportivo, // Carro
        Perua, // Carro
        Compacto_SUV, // Carro
        Microcarro, // Carro
        Classico_Antigo, // Carro
        Limusine, // Carro
        Van, // Carro
        Supercarro, // Carro
        Hypercarro, // Carro
        Compacto_Esportivo, // Carro
        Seda_Esportivo, // Carro
        SUV_Esportivo, // Carro
        Picape_Esportiva, // Carro
        Carro_de_Competicao, // Carro
        Esportiva, // Moto
        Naked, // Moto
        Custom, // Moto
        Scooter, // Moto
        OffRoad, // Moto e Carro
        Touring, // Moto
        Leve, // Caminhao
        Medio, // Caminhao
        Pesado, // Caminhao
        CavaloMecanico, // Caminhao
        Basculante, // Caminhao
        Cegonha, // Caminhao
        Tanque, // Caminhao
        Frigorifico // Caminhao
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