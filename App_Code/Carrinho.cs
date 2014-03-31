using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
/// <summary>
/// TecnoSite carrinho de compras
/// </summary>
public class Carrinho
{
    private List<CarrinhoItem> _Itens = new List<CarrinhoItem>();
    public List<CarrinhoItem> Itens { get { return _Itens; } }
    public decimal ValorTotal { get { return _Itens.Sum(p => p.Preco); } }
    public string LocalEntrega = "";

    public void AdicionarItem(int produtoID, string descricao, decimal preco)
    {
        _Itens.Add( new CarrinhoItem { ProdutoID = produtoID, Descricao = descricao, Preco = preco } );
    }
    public void Limpar()
    {
        _Itens.Clear();
    }
    public void RemoverItem(int index)
    {
        _Itens.RemoveAt(index);
    }
    public void DefinirUF_Entrega (string UF){
        LocalEntrega = UF;
    }

}