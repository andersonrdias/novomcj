using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
/// <summary>
/// 
/// </summary>
public class Historico
{
    private List<HistoricoItem> _Itens = new List<HistoricoItem>();
    public List<HistoricoItem> Itens { get { return _Itens; } }
    public decimal ValorTotal { get { return _Itens.Sum(p => p.Preco); } }
    public string LocalEntrega = "";

    public void AdicionarItem(int produtoID, string descricao, decimal preco)
    {
        _Itens.Add( new HistoricoItem { ProdutoID = produtoID, Descricao = descricao, Preco = preco } );
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