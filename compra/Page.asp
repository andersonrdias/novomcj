<%@ Language="VBScript" 


 protected void btnCalcular_Click(object sender, EventArgs e)
{
        try
        {
               HttpWebRequest req;
               HttpWebResponse resp; 
               DataSet ds; 
               StreamReader sr;

        // 1 - Atribui os valores dos campos a variáveis
        string servico = ddlServico.SelectedValue;
        string cepOrigem = txtCEPOrigem.Text;
        string cepDestino = txtCEPDesino.Text;
        string peso = txtPeso.Text;
        string maopropria = ddlEmMaos.SelectedValue;
        string avisorecebimento = ddlAvisoRecebimento.SelectedValue;

        // 2 - Faz uma requisição a URL passando os valores selecionados via QueryString (resposta em XML)
        req = (HttpWebRequest)WebRequest.Create("http://www.correios.com.br/encomendas/precos/calculo.cfm?" +
                                                                    "Servico=" + servico + "&cepOrigem=" + cepOrigem + "&cepDestino=" + cepDestino +
                                                                    "&peso=" + peso.Replace(",", ".") + "&MaoPropria=" + maopropria + 
                                                                    "&AvisoRecebimento=" + avisorecebimento + "&resposta=xml");

        // 3 - Armazena a resposta da requisição
        resp = (HttpWebResponse)req.GetResponse();

        // 4 - Converte a resposta (XML) da requisição para um StreamReader
        sr = new StreamReader(resp.GetResponseStream(), System.Text.Encoding.UTF8); ds = new DataSet();

        // 5 - Lê o StreamReader (XML) e carrega em um DataSet
        ds.ReadXml(sr);

        sr.Close();
        resp.Close();

        // 6 - Verifica se a consulta retornou erro
        if (Convert.ToInt32(ds.Tables["erro"].Rows[0]["codigo"]) != 0)
        {
              throw new Exception(ds.Tables["erro"].Rows[0]["descricao"].ToString());
        }
        // 7 - Caso a Consulta não tenha retornado erro, carrega o resultado no Label
        else
        {
              lblValor.Text = ds.Tables["Dados_Postais"].Rows[0]["preco_postal"].ToString().Replace(".", ",");
        }

    }
    catch (Exception ex)
    { 
            lblValor.Text = ex.Message;
    }

} 














%>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8" />
        <title></title>
    </head>
    <body>
        


         <table cellpadding="0" cellspacing="0">
            <tr>
                  <td>Serviço:&nbsp;&nbsp;</td>
                  <td>
                        <asp:DropDownList ID="ddlServico" runat="server">
                              <asp:ListItem Value="40010">SEDEX</asp:ListItem>
                              <asp:ListItem Value="40215">SEDEX 10</asp:ListItem>
                        </asp:DropDownList>
                  </td>
            </tr>
            <tr>
                  <td>CEP de Origem:&nbsp;&nbsp;</td>
                  <td><asp:TextBox ID="txtCEPOrigem" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                  <td>CEP de Destino:&nbsp;&nbsp;</td>
                  <td><asp:TextBox ID="txtCEPDesino" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                  <td>Peso:&nbsp;&nbsp;</td>
                  <td><asp:TextBox ID="txtPeso" runat="server" Width="80px"></asp:TextBox></td>
            </tr>
            <tr>
                  <td>Em Mãos:&nbsp;&nbsp;</td>
                  <td>
                        <asp:DropDownList ID="ddlEmMaos" runat="server">
                              <asp:ListItem Value="s">Sim</asp:ListItem>
                              <asp:ListItem Value="n">Não</asp:ListItem>
                        </asp:DropDownList>
                  </td>
            </tr>
            <tr>
                  <td>Valor Declarado:&nbsp;&nbsp;</td>
                  <td><asp:TextBox ID="txtValorDeclarado" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                  <td>Aviso Recebimento:&nbsp;&nbsp;</td>
                  <td>
                        <asp:DropDownList ID="ddlAvisoRecebimento" runat="server">
                              <asp:ListItem Value="s">Sim</asp:ListItem>
                              <asp:ListItem Value="n">Não</asp:ListItem>
                        </asp:DropDownList>
                  </td>
            </tr>
            <tr>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
            </tr>
            <tr>
                  <td>&nbsp;</td>
                  <td style="margin-left: 40px">
                        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" onclick="btnCalcular_Click" style="height: 26px" />
                  </td>
            </tr>
            <tr>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
            </tr>
            <tr>
                  <td colspan="2">
                        <asp:Label ID="lblValor" runat="server" style="text-align: center"></asp:Label>
                  </td>
            </tr>




      </table>
    </body>
</html>

