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
    

   // pulic HistoricoDesc {get{return _Itens.OrderByDescending(P => p.ProdutoId) }}

    public void AdicionarItem(int produtoID, int codproduto,string descricao, decimal preco)
    {
        _Itens.Add( new HistoricoItem {ProdutoID = produtoID, CodProduto = codproduto, Descricao = descricao, Preco = preco } );
    }
    public void Limpar()
    {
        _Itens.Clear();
    }
    public void RemoverItem(int index)
    {
        _Itens.RemoveAt(index);
    }
    

}