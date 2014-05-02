using System;
using System.Collections.Generic;
using System.Web;

using System.Data;

public sealed class clsCorreios : System.IDisposable

{

public System.Data.DataSet BuscaCEP(string pCEP)

{

string vCorreiosURL = "http://www.bronzebusiness.com.br/webservices/wscep.asmx/cep?strcep=" + pCEP;

System.Data.DataSet dsCorreios = new System.Data.DataSet();

dsCorreios.ReadXml(GetURLStream(vCorreiosURL, "", "", "", ""));

return dsCorreios;

}

private System.IO.Stream GetURLStream(string pURL, string pProxyAddress, string pProxyPort, string pProxyUserName, string pProxyPassword)

{

System.Net.WebRequest Request;

System.Net.WebResponse Response;

Request = System.Net.WebRequest.Create(pURL);

System.Net.WebProxy wProxy = new System.Net.WebProxy("http://" + pProxyAddress + ":" + pProxyPort, true);

wProxy.Credentials = new System.Net.NetworkCredential(pProxyUserName, pProxyPassword);

if (pProxyAddress != "")

Request.Proxy = wProxy;

 

Response = Request.GetResponse();

System.IO.Stream responseStream = Response.GetResponseStream();

return responseStream;

}

public double CalculaSedex(string pCEPOrigem, string pCEPDestino, double pPeso, bool pMaoPropria, bool pAvisoRecebimento)

{

return CalculaSedex(pCEPOrigem, pCEPDestino, pPeso, pMaoPropria, pAvisoRecebimento, 0);

}

public double CalculaSedex(string pCEPOrigem, string pCEPDestino, double pPeso, bool pMaoPropria, bool pAvisoRecebimento, double pValorDeclarado)

{

//Cria uma requisi‡Æo ao service dos correios, com os dados informados

string vURL = "http://www.correios.com.br/encomendas/precos/calculo.cfm?";

vURL += "cepOrigem=" + pCEPOrigem + "&cepDestino=" + pCEPDestino;

vURL += "&peso=" + pPeso.ToString().Replace(",", ".") + "&resposta=xml";

System.Net.WebRequest Req = System.Net.WebRequest.Create(vURL);

System.Net.WebResponse Resp = Req.GetResponse();

System.IO.StreamReader sr = new System.IO.StreamReader(Resp.GetResponseStream(), System.Text.Encoding.UTF7);

DataSet ds = new DataSet();

//Coloca os dados recebidos em um DataSet

ds.ReadXml(sr);

sr.Close();

Resp.Close();

if ((int)ds.Tables["erro"].Rows[0]["codigo"] != 0)

{

throw new Exception(ds.Tables["erro"].Rows[0]["descricao"].ToString());

}

else

{

return Convert.ToDouble(ds.Tables["Dados_Postais"].Rows[0]["preco_postal"].ToString().Replace(".", ","));

}

}

public double CalculaEncomenda(string pCEPOrigem, string pCEPDestino, double pPeso, bool pMaoPropria, double pFormato,

bool pAvisoRecebimento)

{

return CalculaEncomenda(pCEPOrigem, pCEPDestino, pPeso, pMaoPropria, pFormato, pAvisoRecebimento, 14, 14, 9, 41027, 0.0);

}

public double CalculaEncomenda(string pCEPOrigem, string pCEPDestino, double pPeso, bool pMaoPropria, double pFormato,

bool pAvisoRecebimento, double pAltura)

{

return CalculaEncomenda(pCEPOrigem, pCEPDestino, pPeso, pMaoPropria, pFormato, pAvisoRecebimento, pAltura, 14, 9, 41027, 0.0);

}

public double CalculaEncomenda(string pCEPOrigem, string pCEPDestino, double pPeso, bool pMaoPropria, double pFormato,

bool pAvisoRecebimento, double pAltura, double pLargura)

{

return CalculaEncomenda(pCEPOrigem, pCEPDestino, pPeso, pMaoPropria, pFormato, pAvisoRecebimento, pAltura, pLargura, 9, 41027, 0.0);

}

public double CalculaEncomenda(string pCEPOrigem, string pCEPDestino, double pPeso, bool pMaoPropria, double pFormato,

bool pAvisoRecebimento, double pAltura, double pLargura, double pComprimento)

{

return CalculaEncomenda(pCEPOrigem, pCEPDestino, pPeso, pMaoPropria, pFormato, pAvisoRecebimento, pAltura, pLargura, pComprimento, 41027, 0.0);

}

public double CalculaEncomenda(string pCEPOrigem, string pCEPDestino, double pPeso, bool pMaoPropria, double pFormato,

bool pAvisoRecebimento, double pAltura, double pLargura, double pComprimento, double pTipoServico)

{

return CalculaEncomenda(pCEPOrigem, pCEPDestino, pPeso, pMaoPropria, pFormato, pAvisoRecebimento, pAltura, pLargura, pComprimento, pTipoServico, 0.0);

}

public double CalculaEncomenda(string pCEPOrigem, string pCEPDestino, double pPeso, bool pMaoPropria, double pFormato,

bool pAvisoRecebimento, double pAltura, double pLargura, double pComprimento, double pTipoServico, double pValorDeclarado)

{

//Cria uma requisi‡Æo ao service dos correios, com os dados informados

string vURL = "http://www.correios.com.br/encomendas/precos/calculo.cfm?";

vURL += "cepOrigem=" + pCEPOrigem + "&cepDestino=" + pCEPDestino;

vURL += "&peso=" + pPeso.ToString().Replace(",", ".") + "&resposta=xml";

vURL += "&servico=" + pTipoServico + "&cepOrigem=" + pCEPOrigem + pCEPDestino;

vURL += "&peso=" + pPeso.ToString().Replace(",", ".") + "&Formato=" + pFormato;

vURL += "&Comprimento=" + pComprimento + "&Largura=" + pLargura + "&Altura=" + pAltura;

System.Net.WebRequest Req = System.Net.WebRequest.Create(vURL);

System.Net.WebResponse Resp = Req.GetResponse();

System.IO.StreamReader sr = new System.IO.StreamReader(Resp.GetResponseStream(), System.Text.Encoding.UTF7);

DataSet ds = new DataSet();

//Coloca os dados recebidos em um DataSet

ds.ReadXml(sr);

sr.Close();

Resp.Close();

if ((int)ds.Tables["erro"].Rows[0]["codigo"] != 0)

{

throw new Exception(ds.Tables["erro"].Rows[0]["descricao"].ToString());

}

else

{

return Convert.ToDouble(ds.Tables["Dados_Postais"].Rows[0]["preco_postal"].ToString().Replace(".", ","));

}

}

public void Dispose()

{

System.GC.SuppressFinalize(this);

}

}