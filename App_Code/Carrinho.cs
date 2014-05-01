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

    //Endereço de entrega
    public string Logradouro = "";
    public string Numero = "";
    public string Complemento = "";
    public string Bairro = "";
    public string Cidade = "";
    public string Cep = "";
    public string Estado = "";

    //Aviso do Sistema
    public bool msgCarrinhoCompra = false;

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

    public void DefinirEnderecoEntrega (string _logradouro, string _numero ,string _complemento, string _bairro, string _cidade, string _cep, string _estado){
        
        Logradouro = _logradouro;
        Numero = _numero;
        Complemento = _complemento;
        Bairro = _bairro;
        Cep = _cep;
        Cidade = _cidade;
        Estado = _estado;


    }

        public void DefinirMensagemCompra (bool _aviso){
        
        msgCarrinhoCompra = _aviso;
      


    }

}