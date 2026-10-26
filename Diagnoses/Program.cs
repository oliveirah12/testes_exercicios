using System;

class Program
{
    static void Main()
    {
        var listaDeProdutos = new List<Produto>();

        listaDeProdutos.Add(new Produto { Descricao = "Caneca", PrecoUnitario = 35.0m, Quantidade = 2 });
        listaDeProdutos.Add(new Produto { Descricao = "Xícara", PrecoUnitario = 25.0m, Quantidade = 3 });
        listaDeProdutos.Add(new Produto { Descricao = "Prato", PrecoUnitario = 20.0m, Quantidade = 1 });

        try
        {
            Console.WriteLine(SumTotalOfProducts(listaDeProdutos, 0));
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    static decimal SumTotalOfProducts(List<Produto> produtos, decimal desconto)
    {
        if(desconto < 0 || desconto > 30)
        {
            throw new ArgumentOutOfRangeException("Valor do desconto precisa estar entre 0 e 30%");
        }

        decimal total = 0;
        foreach(Produto produto in produtos)
        {
            total += SumTotal(produto.PrecoUnitario, produto.Quantidade);
        }

        return total * (1.0m - (desconto/100));
    }

    static decimal SumTotal(decimal precoUnitario, int quantidade)
    {
        var subTotal = quantidade * precoUnitario;


        return subTotal;
    }
}

class Produto
{
    public string Descricao { get; set; } = string.Empty;
    public decimal PrecoUnitario { get; set; }
    public int Quantidade { get; set; }
}
