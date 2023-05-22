/*
 * Esse software de agenda contem nomes de cidades da Bahia, contatos telefonicos e a localização dos CICOMs da Bahia.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace SoftwareAgenda
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***********************************");
            Console.WriteLine("*       AGENDA DE CONTATOS        *");
            Console.WriteLine("***********************************");

            Console.WriteLine("\n       ####### MENU #######       \n");
            Console.WriteLine("\t( 01 ) CADASTRO");
            Console.WriteLine("\t( 02 ) CADASTRO DE USUÁRIO");
            Console.WriteLine("\t( 03 ) CIDADES DA BAHIA");
            Console.WriteLine("\t( 04 ) EDITAR/EXCLUIR USUÁRIO");
            Console.WriteLine("\t( 05 ) CADASTRO DO LOCAL");
            Console.WriteLine("\t( 06 ) BUSCAR DADO DO LOCAL");

            Console.Write("\t>> ");
            int opcaoDoMenu = int.Parse(Console.ReadLine());

            switch (opcaoDoMenu)
            {
                case 01:
                    CadastroPessoaFisica.CadastroDaInformacaoDePessoalFisica();
                    break;

                case 02:
                    CadastroPessoaFisica.CadastroDeUsuario();
                    break;

                case 03:
                    CidadesDaBahia.CidadesComCICOM();
                    break;

                case 04:
                    // Lógica para editar/excluir usuário
                    break;

                case 05:
                    CadastroDoEstabelecimento.cadastroDeDadosDoEstabelecimento();
                    break;

                case 06:
                    Console.Write("Nome da cidade do CICOM: ");
                    string cidadeDoEstabelecimento = Console.ReadLine();
                    BancoDeDadosDoSistema.BuscarDadosDoEstabelecimento(cidadeDoEstabelecimento);
                    break;
            }

            Console.ReadKey();
        }
    }

    class CadastroPessoaFisica
    {
        public static string CadastroDeUsuario()
        {
            Console.WriteLine();

            Console.Write("Nome completo: ");
            string cadDeUsuarioNomeCompleto = Console.ReadLine();

            Console.Write("E-mail: ");
            string cadDeUsuarioComEmail = Console.ReadLine();

            Console.Write("Contato: ");
            ulong cadDeUsuarioComContato = ulong.Parse(Console.ReadLine());

            Console.Write("Data de nascimento: ");
            string cadDeUsuarioComNascimento = Console.ReadLine();

            Console.Write("Sexo: ");
            string cadDeUsuarioComSexo = Console.ReadLine();

            Console.Write("CPF: ");
            ulong cadDeUsuarioComCPF = ulong.Parse(Console.ReadLine());

            cadDeUsuarioNomeCompleto = cadDeUsuarioNomeCompleto.Trim().ToUpper();
            cadDeUsuarioComEmail = cadDeUsuarioComEmail.Trim().ToUpper();
            cadDeUsuarioComSexo = cadDeUsuarioComSexo.Trim().ToUpper();


            Console.Write($@"Nome completo: {cadDeUsuarioNomeCompleto}
                             E-mail: {cadDeUsuarioComEmail}
                             Contato: {cadDeUsuarioComContato}
                             Data de nascimento: {cadDeUsuarioComNascimento}
                             Sexo: {cadDeUsuarioComSexo}
                             CPF: {cadDeUsuarioComCPF}
                             ");

            BancoDeDadosDoSistema.DB_InserirRegistroDoUsuario(cadDeUsuarioNomeCompleto, cadDeUsuarioComEmail, cadDeUsuarioComContato, cadDeUsuarioComNascimento, cadDeUsuarioComSexo, cadDeUsuarioComCPF);

            Console.ReadKey();

            return null;
        }
        public static void CadastroDaInformacaoDePessoalFisica()
        {
            Console.WriteLine();

            Console.Write("Nome completo: ");
            string cadPessoaFisicaComNomeCompleto = Console.ReadLine();

            Console.Write("E-mail: ");
            string cadPessoaFisicaComEmail = Console.ReadLine();

            Console.Write("Contato: ");
            ulong cadPessoaFisicaComContato = ulong.Parse(Console.ReadLine());

            Console.Write("Contato pertence a quem? ");
            string cadPessoaFisicaComContatoPertence = Console.ReadLine();

            Console.Write("Endereço: ");
            string cadPessoaFisicaComEndereco = Console.ReadLine();

            Console.Write("Data de nascimento: ");
            string cadPessoaFisicaComNascimento = Console.ReadLine();

            Console.Write("Sexo: ");
            string cadPessoaFisicaComSexo = Console.ReadLine();

            Console.Write("CPF: ");
            ulong cadPessoaFisicaComCPF = ulong.Parse(Console.ReadLine());

            //FORMATAÇÃO DA INFORMAÇÃO DIGITADA PELO USUARIO: 1. REMOVER ESPAÇO EM BRANCO; 2. CAIXA ALTA. 
            cadPessoaFisicaComNomeCompleto = cadPessoaFisicaComNomeCompleto.Trim().ToUpper();
            cadPessoaFisicaComEmail = cadPessoaFisicaComEmail.Trim().ToUpper();
            cadPessoaFisicaComContatoPertence = cadPessoaFisicaComContatoPertence.Trim().ToUpper();
            cadPessoaFisicaComEndereco = cadPessoaFisicaComContatoPertence.Trim().ToUpper();
            cadPessoaFisicaComSexo = cadPessoaFisicaComContatoPertence.Trim().ToUpper();

            /*
            **Console.Write($@"Nome completo: {cadPessoaComNomeCompleto}
            **                 E-mail: {cadPessoaComEmail}
            **                 Contato: {cadPessoaComContato}
            **                 Contato pertence a quem? {cadPessoaComContatoPertence}
            **                 Endereço: {cadPessoaComEndereco}
            **                 Data de nascimento: {cadPessoaComNascimento}
            **                 Sexo: {cadPessoaComSexo}
            **                 CPF: {cadPessoaComCPF}
            **                 ");
            */

            Console.WriteLine("\nCADASTRO REALIZADO COM SUCESSO!\n");

            Console.ReadKey();
        }
    }
    class CidadesDaBahia
    {
        public static void CidadesComCICOM()
        {
            List<string> cidades = new List<string>()
            {
                "Salvador", "Feira de Santana", "Vitória da Conquista", "Camaçari", "Juazeiro"
            };

            Console.WriteLine("\nCIDADES COM CICOM:\n");

            foreach (string cidade in cidades)
            {
                Console.WriteLine(cidade);
            }

            Console.ReadKey();
        }
    }
    class CadastroDoEstabelecimento
    {
        public static void cadastroDeDadosDoEstabelecimento()
        {
            Console.WriteLine();

            Console.Write("CICOM: ");
            string nomeDoEstabelecimento = Console.ReadLine();

            Console.Write("Cidade: ");
            string cidadeDoEstabelecimento = Console.ReadLine();

            Console.Write("Endereço: ");
            string enderecoDoEstabelecimento = Console.ReadLine();

            Console.Write("Telefone: ");
            int contatoDoEstabelecimento1 = int.Parse(Console.ReadLine());

            Console.Write("Telefone: ");
            int contatoDoEstabelecimento2 = int.Parse(Console.ReadLine());

            Console.Write("Celular: ");
            int contatoDoEstabelecimento3 = int.Parse(Console.ReadLine());

            nomeDoEstabelecimento = nomeDoEstabelecimento.Trim().ToUpper();
            cidadeDoEstabelecimento = cidadeDoEstabelecimento.Trim().ToUpper();
            enderecoDoEstabelecimento = enderecoDoEstabelecimento.Trim().ToUpper();
            //contatoDoEstabelecimento1 = contatoDoEstabelecimento1.Trim();
            //contatoDoEstabelecimento2 = contatoDoEstabelecimento2.Trim();
            //contatoDoEstabelecimento3 = contatoDoEstabelecimento3.Trim();

            //Console.WriteLine();
            //Console.Write($@"
            //                CICOM: {cidadeDoEstabelecimento}
            //                Cidade: {cidadeDoEstabelecimento}
            //                Endereço: {enderecoDoEstabelecimento}
            //                TELEFONE: {contatoDoEstabelecimento1}
            //                TELEFONE: {contatoDoEstabelecimento2}
            //                CELULAR: {contatoDoEstabelecimento3}
            //                ");

            BancoDeDadosDoSistema.DB_InserirRegistro(nomeDoEstabelecimento,
                cidadeDoEstabelecimento,
                enderecoDoEstabelecimento,
                contatoDoEstabelecimento1,
                contatoDoEstabelecimento2,
                contatoDoEstabelecimento3
                );

            Console.ReadKey();
        }
    }
    class BancoDeDadosDoSistema
    {
        private static SQLiteConnection ConexaoBancoDeDados()
        {
            SQLiteConnection conexao = new SQLiteConnection("Data Source=BancoDeDadosAgenda.db");
            conexao.Open();
            return conexao;
        }

        private static void CriarBancoDeDados()
        {
            string dbFilePath = "BancoDeDadosAgenda.db";

            // Criar o banco de dados se ele não existir
            SQLiteConnection.CreateFile(dbFilePath);
        }
        public static void DB_InserirRegistroDoUsuario(string cadDeUsuarioNomeCompleto, string cadDeUsuarioComEmail, ulong cadDeUsuarioComContato, string cadDeUsuarioComNascimento, string cadDeUsuarioComSexo, ulong cadDeUsuarioComCPF)
        {
            CriarBancoDeDados();

            // Conectar ao banco de dados
            SQLiteConnection conexao = ConexaoBancoDeDados();

            // Criar a tabela "TB_usuario"
            string createTableQuery = "CREATE TABLE IF NOT EXISTS TB_usuario (id INTEGER PRIMARY KEY AUTOINCREMENT, cadDeUsuarioNomeCompleto TEXT, cadDeUsuarioComEmail TEXT, cadDeUsuarioComContato TEXT, cadDeUsuarioComNascimento DECIMAL, cadDeUsuarioComSexo TEXT, cadDeUsuarioComCPF DECIMAL)";
            using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, conexao))
            {
                createTableCommand.ExecuteNonQuery();
            }

            Console.WriteLine();
            Console.WriteLine("Banco de dados e tabela criados com sucesso!");

            // Inserir registros na tabela "TB_usuario"
            string insertQuery = "INSERT INTO TB_usuario (cadDeUsuarioNomeCompleto, cadDeUsuarioComEmail, cadDeUsuarioComContato, cadDeUsuarioComNascimento, cadDeUsuarioComSexo, cadDeUsuarioComCPF) VALUES (@cadDeUsuarioNomeCompleto, @cadDeUsuarioComEmail, @cadDeUsuarioComContato, @cadDeUsuarioComNascimento, @cadDeUsuarioComSexo, @cadDeUsuarioComCPF)";
            using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, conexao))
            {
                insertCommand.Parameters.AddWithValue("@cadDeUsuarioNomeCompleto", cadDeUsuarioNomeCompleto);
                insertCommand.Parameters.AddWithValue("@cadDeUsuarioComEmail", cadDeUsuarioComEmail);
                insertCommand.Parameters.AddWithValue("@cadDeUsuarioComContato", cadDeUsuarioComContato);
                insertCommand.Parameters.AddWithValue("@cadDeUsuarioComNascimento", cadDeUsuarioComNascimento);
                insertCommand.Parameters.AddWithValue("@cadDeUsuarioComSexo", cadDeUsuarioComSexo);
                insertCommand.Parameters.AddWithValue("@cadDeUsuarioComCPF", cadDeUsuarioComCPF);
                insertCommand.ExecuteNonQuery();

                Console.WriteLine();
                Console.WriteLine("\nCADASTRO REALIZADO COM SUCESSO!\n");
            }
            conexao.Close();
        }
        public static void BuscarDadosDoUsuario()
        {

        }
        public static void DB_InserirRegistro(string nomeDoEstabelecimento, string cidadeDoEstabelecimento, string enderecoDoEstabelecimento, int contatoDoEstabelecimento1, int contatoDoEstabelecimento2, int contatoDoEstabelecimento3)
        {
            CriarBancoDeDados();

            // Conectar ao banco de dados
            SQLiteConnection conexao = ConexaoBancoDeDados();

            // Criar a tabela "TB_contatoDoEstabelecimento"
            string createTableQuery = "CREATE TABLE IF NOT EXISTS TB_contatoDoEstabelecimento (id INTEGER PRIMARY KEY AUTOINCREMENT, nomeDoEstabelecimento TEXT, cidadeDoEstabelecimento TEXT, enderecoDoEstabelecimento TEXT, contatoDoEstabelecimento1 DECIMAL, contatoDoEstabelecimento2 DECIMAL, contatoDoEstabelecimento3 DECIMAL)";
            using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, conexao))
            {
                createTableCommand.ExecuteNonQuery();
            }

            //Console.WriteLine();
            //Console.WriteLine("Banco de dados e tabela criados com sucesso!");

            // Inserir registros na tabela "TB_contatoDoEstabelecimento"
            string insertQuery = "INSERT INTO TB_contatoDoEstabelecimento (nomeDoEstabelecimento, cidadeDoEstabelecimento, enderecoDoEstabelecimento, contatoDoEstabelecimento1, contatoDoEstabelecimento2, contatoDoEstabelecimento3) VALUES (@nomeDoEstabelecimento, @cidadeDoEstabelecimento, @enderecoDoEstabelecimento, @contatoDoEstabelecimento1, @contatoDoEstabelecimento2, @contatoDoEstabelecimento3)";
            using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, conexao))
            {
                insertCommand.Parameters.AddWithValue("@nomeDoEstabelecimento", nomeDoEstabelecimento);
                insertCommand.Parameters.AddWithValue("@cidadeDoEstabelecimento", cidadeDoEstabelecimento);
                insertCommand.Parameters.AddWithValue("@enderecoDoEstabelecimento", enderecoDoEstabelecimento);
                insertCommand.Parameters.AddWithValue("@contatoDoEstabelecimento1", contatoDoEstabelecimento1);
                insertCommand.Parameters.AddWithValue("@contatoDoEstabelecimento2", contatoDoEstabelecimento2);
                insertCommand.Parameters.AddWithValue("@contatoDoEstabelecimento3", contatoDoEstabelecimento3);
                insertCommand.ExecuteNonQuery();

                //Console.WriteLine();
                //Console.WriteLine("Registros inseridos com sucesso!");
            }

            conexao.Close();
        }

        public static void BuscarDadosDoEstabelecimento(string cidadeDoEstabelecimento)
        {
            SQLiteConnection conexao = ConexaoBancoDeDados();
            SQLiteCommand comando = conexao.CreateCommand();

            // Verificar se a tabela existe
            comando.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='TB_contatoDoEstabelecimento'";
            SQLiteDataReader reader = comando.ExecuteReader();

            if (!reader.HasRows)
            {
                // A tabela não existe, então criá-la
                reader.Close();
                comando.CommandText = @"CREATE TABLE TB_contatoDoEstabelecimento (
                                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    nomeDoEstabelecimento TEXT,
                                    cidadeDoEstabelecimento TEXT,
                                    enderecoDoEstabelecimento TEXT,
                                    contatoDoEstabelecimento1 DECIMAL,
                                    contatoDoEstabelecimento2 DECIMAL,
                                    contatoDoEstabelecimento3 DECIMAL
                                )";
                comando.ExecuteNonQuery();
                Console.WriteLine("Tabela criada com sucesso!");
            }
            else
            {
                reader.Close();
            }

            // Agora, execute a consulta para buscar os dados
            comando.CommandText = $"SELECT * FROM TB_contatoDoEstabelecimento WHERE cidadeDoEstabelecimento='{cidadeDoEstabelecimento}'";
            reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string nomeDoEstabelecimento = reader.GetString(1);
                    string cidadeEstabelecimento = reader.GetString(2);
                    string enderecoDoEstabelecimento = reader.GetString(3);
                    long contatoDoEstabelecimento1 = reader.GetInt64(4);
                    long contatoDoEstabelecimento2 = reader.GetInt64(5);
                    long contatoDoEstabelecimento3 = reader.GetInt64(6);

                    ulong contato1 = contatoDoEstabelecimento1 > 0 ? (ulong)contatoDoEstabelecimento1 : 0;
                    ulong contato2 = contatoDoEstabelecimento2 > 0 ? (ulong)contatoDoEstabelecimento2 : 0;
                    ulong contato3 = contatoDoEstabelecimento3 > 0 ? (ulong)contatoDoEstabelecimento3 : 0;

                    Console.WriteLine($@"
                        Nome do estabelecimento: {nomeDoEstabelecimento}
                        Cidade do estabelecimento: {cidadeEstabelecimento}
                        Endereço do estabelecimento: {enderecoDoEstabelecimento}
                        Contato do estabelecimento1: {contato1}
                        Contato do estabelecimento2: {contato2}
                        Contato do estabelecimento3: {contato3}
                    ");
                }
            }
            else
            {
                Console.WriteLine("Nenhum estabelecimento encontrado para a cidade informada.");
            }

            reader.Close();
            conexao.Close();

            Console.ReadKey();
        }
    }
}

    //namespace SoftwareAgenda.CidadesDaBrasil
    //{
    //    class cidadesDaBahia
    //    {
    //        public static string cidadesComCICOM()
    //        {
    //            #region Nomes das cidades do estado da Bahia
    //            string[] cidadesQueTemCICOM = { "Abaíra",
    //            "Abaré",
    //            "Acajutiba",
    //            "Adustina",
    //            "Água Fria",
    //            "Aiquara",
    //            "Alagoinhas",
    //            "Alcobaça",
    //            "Almadina",
    //            "Amargosa",
    //            "Amélia Rodrigues",
    //            "América Dourada",
    //            "Anagé",
    //            "Andaraí",
    //            "Andorinha",
    //            "Angical",
    //            "Anguera",
    //            "Antas",
    //            "Antônio Cardoso",
    //            "Antônio Gonçalves",
    //            "Aporá",
    //            "Apuarema",
    //            "Araçás",
    //            "Aracatu",
    //            "Araci",
    //            "Aramari",
    //            "Arataca",
    //            "Aratuípe",
    //            "Aurelino Leal",
    //            "Baianópolis",
    //            "Baixa Grande",
    //            "Banzaê",
    //            "Barra",
    //            "Barra da Estiva",
    //            "Barra do Choça",
    //            "Barra do Mendes",
    //            "Barra do Rocha",
    //            "Barreiras",
    //            "Barro Alto",
    //            "Barro Preto",
    //            "Barrocas",
    //            "Belmonte",
    //            "Belo Campo",
    //            "Biritinga",
    //            "Boa Nova",
    //            "Boa Vista do Tupim",
    //            "Bom Jesus da Lapa",
    //            "Bom Jesus da Serra",
    //            "Boninal",
    //            "Bonito",
    //            "Boquira",
    //            "Botuporã",
    //            "Brejões",
    //            "Brejolândia",
    //            "Brotas de Macaúbas",
    //            "Brumado",
    //            "Buerarema",
    //            "Buritirama",
    //            "Caatiba",
    //            "Cabaceiras do Paraguaçu",
    //            "Cachoeira",
    //            "Caculé",
    //            "Caém",
    //            "Caetanos",
    //            "Caetité",
    //            "Cafarnaum",
    //            "Cairu",
    //            "Caldeirão Grande",
    //            "Camacan",
    //            "Camaçari",
    //            "Camamu",
    //            "Campo Alegre de Lourdes",
    //            "Campo Formoso",
    //            "Canápolis",
    //            "Canarana",
    //            "Canavieiras",
    //            "Candeal",
    //            "Candeias",
    //            "Candiba",
    //            "Cândido Sales",
    //            "Cansanção",
    //            "Canudos",
    //            "Capela do Alto Alegre",
    //            "Capim Grosso",
    //            "Caraíbas",
    //            "Caravelas",
    //            "Cardeal da Silva",
    //            "Carinhanha",
    //            "Casa Nova",
    //            "Castro Alves",
    //            "Catolândia",
    //            "Catu",
    //            "Caturama",
    //            "Central",
    //            "Chorrochó",
    //            "Cícero Dantas",
    //            "Cipó",
    //            "Coaraci",
    //            "Cocos",
    //            "Conceição da Feira",
    //            "Conceição do Almeida",
    //            "Conceição do Coité",
    //            "Conceição do Jacuípe",
    //            "Conde",
    //            "Condeúba",
    //            "Contendas do Sincorá",
    //            "Coração de Maria",
    //            "Cordeiros",
    //            "Coribe",
    //            "Coronel João Sá",
    //            "Correntina",
    //            "Cotegipe",
    //            "Cravolândia",
    //            "Crisópolis",
    //            "Cristópolis",
    //            "Cruz das Almas",
    //            "Curaçá",
    //            "Dário Meira",
    //            "Dias d\"Ávila",
    //            "Dom Basílio",
    //            "Dom Macedo Costa",
    //            "Elísio Medrado",
    //            "Encruzilhada",
    //            "Entre Rios",
    //            "Érico Cardoso",
    //            "Esplanada",
    //            "Euclides da Cunha",
    //            "Eunápolis",
    //            "Fátima",
    //            "Feira da Mata",
    //            "Feira de Santana",
    //            "Filadélfia",
    //            "Firmino Alves",
    //            "Floresta Azul",
    //            "Formosa do Rio Preto",
    //            "Gandu",
    //            "Gavião",
    //            "Gentio do Ouro",
    //            "Glória",
    //            "Gongogi",
    //            "Governador Mangabeira",
    //            "Guajeru",
    //            "Guanambi",
    //            "Guaratinga",
    //            "Heliópolis",
    //            "Iaçu",
    //            "Ibiassucê",
    //            "Ibicaraí",
    //            "Ibicoara",
    //            "Ibicuí",
    //            "Ibipeba",
    //            "Ibipitanga",
    //            "Ibiquera",
    //            "Ibirapitanga",
    //            "Ibirapuã",
    //            "Ibirataia",
    //            "Ibitiara",
    //            "Ibititá",
    //            "Ibotirama",
    //            "Ichu",
    //            "Igaporã",
    //            "Igrapiúna",
    //            "Iguaí",
    //            "Ilhéus",
    //            "Inhambupe",
    //            "Ipecaetá",
    //            "Ipiaú",
    //            "Ipirá",
    //            "Ipupiara",
    //            "Irajuba",
    //            "Iramaia",
    //            "Iraquara",
    //            "Irará",
    //            "Irecê",
    //            "Itabela",
    //            "Itaberaba",
    //            "Itabuna",
    //            "Itacaré",
    //            "Itaetê",
    //            "Itagi",
    //            "Itagibá",
    //            "Itagimirim",
    //            "Itaguaçu da Bahia",
    //            "Itaju do Colônia",
    //            "Itajuípe",
    //            "Itamaraju",
    //            "Itamari",
    //            "Itambé",
    //            "Itanagra",
    //            "Itanhém",
    //            "Itaparica",
    //            "Itapé",
    //            "Itapebi",
    //            "Itapetinga",
    //            "Itapicuru",
    //            "Itapitanga",
    //            "Itaquara",
    //            "Itarantim",
    //            "Itatim",
    //            "Itiruçu",
    //            "Itiúba",
    //            "Itororó",
    //            "Ituaçu",
    //            "Ituberá",
    //            "Iuiú",
    //            "Jaborandi",
    //            "Jacaraci",
    //            "Jacobina",
    //            "Jaguaquara",
    //            "Jaguarari",
    //            "Jaguaripe",
    //            "Jandaíra",
    //            "Jequié",
    //            "Jeremoabo",
    //            "Jiquiriçá",
    //            "Jitaúna",
    //            "João Dourado",
    //            "Juazeiro",
    //            "Jucuruçu",
    //            "Jussara",
    //            "Jussari",
    //            "Jussiape",
    //            "Lafaiete Coutinho",
    //            "Lagoa Real",
    //            "Laje",
    //            "Lajedão",
    //            "Lajedinho",
    //            "Lajedo do Tabocal",
    //            "Lamarão",
    //            "Lapão",
    //            "Lauro de Freitas",
    //            "Lençóis",
    //            "Licínio de Almeida",
    //            "Livramento de Nossa Senhora",
    //            "Luís Eduardo Magalhães",
    //            "Macajuba",
    //            "Macarani",
    //            "Macaúbas",
    //            "Macururé",
    //            "Madre de Deus",
    //            "Maetinga",
    //            "Maiquinique",
    //            "Mairi",
    //            "Malhada de Pedras",
    //            "Malhada",
    //            "Manoel Vitorino",
    //            "Mansidão",
    //            "Maracás",
    //            "Maragogipe",
    //            "Maraú",
    //            "Marcionílio Souza",
    //            "Mascote",
    //            "Mata de São João",
    //            "Matina",
    //            "Medeiros Neto",
    //            "Miguel Calmon",
    //            "Milagres",
    //            "Mirangaba",
    //            "Mirante",
    //            "Monte Santo",
    //            "Morpará",
    //            "Morro do Chapéu",
    //            "Mortugaba",
    //            "Mucugê",
    //            "Mucuri",
    //            "Mulungu do Morro",
    //            "Mundo Novo",
    //            "Muniz Ferreira",
    //            "Muquém do São Francisco",
    //            "Muritiba",
    //            "Mutuípe",
    //            "Nazaré",
    //            "Nilo Peçanha",
    //            "Nordestina",
    //            "Nova Canaã",
    //            "Nova Fátima",
    //            "Nova Ibiá",
    //            "Nova Itarana",
    //            "Nova Redenção",
    //            "Nova Soure",
    //            "Nova Viçosa",
    //            "Novo Horizonte",
    //            "Novo Triunfo",
    //            "Olindina",
    //            "Oliveira dos Brejinhos",
    //            "Ouriçangas",
    //            "Ourolândia",
    //            "Palmas de Monte Alto",
    //            "Palmeiras",
    //            "Paramirim",
    //            "Paratinga",
    //            "Paripiranga",
    //            "Pau Brasil",
    //            "Paulo Afonso",
    //            "Pé de Serra",
    //            "Pedrão",
    //            "Pedro Alexandre",
    //            "Piatã",
    //            "Pilão Arcado",
    //            "Pindaí",
    //            "Pindobaçu",
    //            "Pintadas",
    //            "Piraí do Norte",
    //            "Piripá",
    //            "Piritiba",
    //            "Planaltino",
    //            "Planalto",
    //            "Poções",
    //            "Pojuca",
    //            "Ponto Novo",
    //            "Porto Seguro",
    //            "Potiraguá",
    //            "Prado",
    //            "Presidente Dutra",
    //            "Presidente Jânio Quadros",
    //            "Presidente Tancredo Neves",
    //            "Queimadas",
    //            "Quijingue",
    //            "Quixabeira",
    //            "Rafael Jambeiro",
    //            "Remanso",
    //            "Retirolândia",
    //            "Riachão das Neves",
    //            "Riachão do Jacuípe",
    //            "Riacho de Santana",
    //            "Ribeira do Amparo",
    //            "Ribeira do Pombal",
    //            "Ribeirão do Largo",
    //            "Rio de Contas",
    //            "Rio do Antônio",
    //            "Rio do Pires",
    //            "Rio Real",
    //            "Rodelas",
    //            "Ruy Barbosa",
    //            "Salinas da Margarida",
    //            "Salvador",
    //            "Santa Bárbara",
    //            "Santa Brígida",
    //            "Santa Cruz Cabrália",
    //            "Santa Cruz da Vitória",
    //            "Santa Inês",
    //            "Santa Luzia",
    //            "Santa Maria da Vitória",
    //            "Santa Rita de Cássia",
    //            "Santa Teresinha",
    //            "Santaluz",
    //            "Santana",
    //            "Santanópolis",
    //            "Santo Amaro",
    //            "Santo Antônio de Jesus",
    //            "Santo Estêvão",
    //            "São Desidério",
    //            "São Domingos",
    //            "São Felipe",
    //            "São Félix",
    //            "São Félix do Coribe",
    //            "São Francisco do Conde",
    //            "São Gabriel",
    //            "São Gonçalo dos Campos",
    //            "São José da Vitória",
    //            "São José do Jacuípe",
    //            "São Miguel das Matas",
    //            "São Sebastião do Passé",
    //            "Sapeaçu",
    //            "Sátiro Dias",
    //            "Saubara",
    //            "Saúde",
    //            "Seabra",
    //            "Sebastião Laranjeiras",
    //            "Senhor do Bonfim",
    //            "Sento Sé",
    //            "Serra do Ramalho",
    //            "Serra Dourada",
    //            "Serra Preta",
    //            "Serrinha",
    //            "Serrolândia",
    //            "Simões Filho",
    //            "Sítio do Mato",
    //            "Sítio do Quinto",
    //            "Sobradinho",
    //            "Souto Soares",
    //            "Tabocas do Brejo Velho",
    //            "Tanhaçu",
    //            "Tanque Novo",
    //            "Tanquinho",
    //            "Taperoá",
    //            "Tapiramutá",
    //            "Teixeira de Freitas",
    //            "Teodoro Sampaio",
    //            "Teofilândia",
    //            "Teolândia",
    //            "Terra Nova",
    //            "Tremedal",
    //            "Tucano",
    //            "Uauá",
    //            "Ubaíra",
    //            "Ubaitaba",
    //            "Ubatã",
    //            "Uibaí",
    //            "Umburanas",
    //            "Una",
    //            "Urandi",
    //            "Uruçuca",
    //            "Utinga",
    //            "Valença",
    //            "Valente",
    //            "Várzea da Roça",
    //            "Várzea do Poço",
    //            "Várzea Nova",
    //            "Varzedo",
    //            "Vera Cruz",
    //            "Vereda",
    //            "Vitória da Conquista",
    //            "Wagner",
    //            "Wanderley",
    //            "Wenceslau Guimarães",
    //            "Xique-Xique"};
    //            #endregion

    //            Console.WriteLine();

    //            for(int i = 0; i < cidadesQueTemCICOM.Length; i++)
    //            {
    //                string cidadeBahia = cidadesQueTemCICOM[i];
    //                int contDeCidade = i + 1;

    //                Console.WriteLine($"\t{contDeCidade} - {cidadeBahia}");
    //            }

    //            Console.ReadKey();
    //            return null;
    //        }
    //    }
    //}

//namespace SoftwareAgenda.BancoDeDadosDoSistema
//{
//    class bancoDeDados
//    {
//        public static string DB_InserirRegistro(string cidadeDoEstabelecimento, long telDoEstabelecimento1, long telDoEstabelecimento2, long telDoEstabelecimento3)
//        {
//            Console.WriteLine();

//            string dbFilePath = "DB_SoftwareAgenda.sqlite";
//            // Criar o banco de dados se ele não existir
//            SQLiteConnection.CreateFile(dbFilePath);

//            // Conectar ao banco de dados
//            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
//            {
//                connection.Open();

//                // Criar a tabela "TB_contatoDoEstabelecimento"
//                string createTableQuery = "CREATE TABLE IF NOT EXISTS TB_contatoDoEstabelecimento (id INTEGER PRIMARY KEY AUTOINCREMENT, cidadeDoEstabelecimento TEXT, telDoEstabelecimento1 DECIMAL, telDoEstabelecimento2 DECIMAL, telDoEstabelecimento3 DECIMAL)";
//                using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection))
//                {
//                    createTableCommand.ExecuteNonQuery();
//                }

//                Console.WriteLine();
//                Console.WriteLine("Banco de dados e tabela criados com sucesso!");

//                // Inserir registros na tabela "TB_contatoDoEstabelecimento"
//                string insertQuery = "INSERT INTO TB_contatoDoEstabelecimento (cidadeDoEstabelecimento, telDoEstabelecimento1, telDoEstabelecimento2, telDoEstabelecimento3) VALUES (@cidadeDoEstabelecimento, @telDoEstabelecimento1, @telDoEstabelecimento2, @telDoEstabelecimento3)";
//                using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
//                {
//                    insertCommand.Parameters.AddWithValue("@cidadeDoEstabelecimento", cidadeDoEstabelecimento);
//                    insertCommand.Parameters.AddWithValue("@telDoEstabelecimento1", telDoEstabelecimento1);
//                    insertCommand.Parameters.AddWithValue("@telDoEstabelecimento2", telDoEstabelecimento2);
//                    insertCommand.Parameters.AddWithValue("@telDoEstabelecimento3", telDoEstabelecimento3);
//                    insertCommand.ExecuteNonQuery();

//                    //Limpara os parâmetros antes de definir novos valores
//                    insertCommand.Parameters.Clear();
                

//                    //insertCommand.Parameters.AddWithValue("@cidadeDoEstabelecimento", "AMARGOSA");
//                    //insertCommand.Parameters.AddWithValue("@telDoEstabelecimento1", 7536310000);
//                    //insertCommand.Parameters.AddWithValue("@telDoEstabelecimento2", 7536310001);
//                    //insertCommand.Parameters.AddWithValue("@telDoEstabelecimento3", 75998140000);
//                    //insertCommand.ExecuteNonQuery();

//                }

//                Console.WriteLine();
//                Console.WriteLine("Registros inseridos com sucesso!");

//            }

//            Console.ReadKey();

//            return null;
//        }

        /* O QUE EU VOU PRECISSAR FAZER AQUI?
         * 1. Conectar o Banco de Dados e a Tabela;
         * 2. Resolver o problema do BD que está rescrevendo a primeira linha da tabela. É como se o
         * auto incremento não estivesse funcionando.
         * 3. O problema está em algum lugar do código abaixo. Verifiquei o BD e está salvando as informações,
         * porém, em algum lugar abaixo está apagando o conteúdo do código.
         * 
         * O QUE QUERO FAZER?
         * NA LINHA 62, REFERENTE AO COMANDO DA LINHA 30 "( 06 ) BUSCAR DADO DO LOCAL", O USUÁRIO VAI
         * INFORMAR O NOME DA CIDADE... E APÓS ISSO, SERÁ DIRECIONADO PARA AQUI ("DB_Buscar"). ESTE
         * LOCAL É RESPONSÁVEL POR EXIBIR A LEITURA DO REGISTRO DA TABELA.
         */
//        internal static string DB_Buscar(string cidadeDoEstabelecimento)
//        {
//            string dbFilePath = "DB_SoftwareAgenda.sqlite";

//            // Criar o banco de dados se ele não existir
//            SQLiteConnection.CreateFile(dbFilePath);

//            // Conectar ao banco de dados
//            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
//            {
//                connection.Open();

//                // Criar a tabela "TB_contatoDoEstabelecimento"
//                string createTableQuery = "CREATE TABLE IF NOT EXISTS TB_contatoDoEstabelecimento (id INTEGER PRIMARY KEY AUTOINCREMENT, cidadeDoEstabelecimento TEXT, telDoEstabelecimento1 DECIMAL, telDoEstabelecimento2 DECIMAL, telDoEstabelecimento3 DECIMAL)";
//                using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection))
//                {
//                    createTableCommand.ExecuteNonQuery();
//                }

//                // Ler registros da tabela "TB_contatoDoEstabelecimento"
//                string selectQuery = "SELECT id, cidadeDoEstabelecimento, telDoEstabelecimento1, telDoEstabelecimento2, telDoEstabelecimento3 FROM TB_contatoDoEstabelecimento";
//                using (SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection))
//                {
//                    using (SQLiteDataReader reader = selectCommand.ExecuteReader())
//                    {
//                        Console.WriteLine();
//                        Console.WriteLine("Registros encontrados na tabela 'TB_contatoDoEstabelecimento':");
//                        while (reader.Read())
//                        {
//                            int id = reader.GetInt32(0);
//                            string nome = reader.GetString(1);
//                            decimal tel1 = reader.GetDecimal(2);
//                            decimal tel2 = reader.GetDecimal(3);
//                            decimal tel3 = reader.GetDecimal(4);

//                            Console.WriteLine("########################################");
//                            Console.WriteLine($"ID: {id}\nCidade do CICOM: {nome}\nTel. #1: {tel1}\nTel. #2: {tel2}\nCel. #3: {tel3}");
//                            Console.WriteLine("########################################");
//                        }
//                    }
//                }
//            }
//            return null;
//        }
//    }
//}
