/* 
                   Instituto Politecnico Do Cávado e Do Ave 

                                2020/2021

                                  LESI

                        Integração de Sistemas Informação
                            
                        Joao Pedro Araujo - 14363
                
                        Marco Henriques   - 16961
                            
                                04/11/2020
 
 
 
 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TP_EX_1_2
{
    class Program
    {
        static Dictionary<int, string> ReadLocal(string ficheiro)
        {
            Dictionary<int, string> metroLocal = new Dictionary<int, string>();
            String erString = @"^[0-9]{7},[123],([1-9]?\d,){2}[A-Z]{3},([^,\n]*)$";
            Regex g = new Regex(erString);
            using (StreamReader r = new StreamReader(ficheiro))
            {
                string line;

                while ((line = r.ReadLine()) != null)
                {
                    // Tenta correspondência (macthing) da ER com cada linha do ficheiro
                    Match m = g.Match(line);
                    if (m.Success)
                    {
                        //  estrutura de cada linha com correspondência:
                        //      globalIdLocal,idRegiao,idDistrito,idConcelho,idAreaAviso,local
                        //  separar pelas vírgulas...
                        string[] campos = m.Value.Split(',');
                        int codLocal = int.Parse(campos[0]);
                        string cidade = campos[5];
                        // Guardar na estrutura de dados dicionário
                        // dicLocais.Add( CHAVE ,  VALOR )
                        metroLocal.Add(codLocal, cidade);
                    }
                    else
                    {
                        Console.WriteLine($"Linha inválida: {line}");
                    }
                }
            }
            return metroLocal;
        }
        static PrevisaoIPMA LerFicheiroPrevisao(int globalIdLocal)
        {
            String jsonString = null;
            using (StreamReader reader =
                       new StreamReader(@"../../data_forecast/" + globalIdLocal + ".json"))
            {
                jsonString = reader.ReadToEnd();
            }
            PrevisaoIPMA obj = JsonSerializer.Deserialize<PrevisaoIPMA>(jsonString);
            
            return obj;
        }
        
        static void Main(string[] args)
        {
            Dictionary<int, string> dicLocais = ReadLocal(@"../../locais.csv");

            // Apenas para mostrar o conteúdo da estrutura dicinário...
            foreach (KeyValuePair<int, string> kv in dicLocais)
            {                
                // para cada linha do ficheiro CSV ... 
                PrevisaoIPMA previsaoIPMA = LerFicheiroPrevisao(kv.Key);
                       
                previsaoIPMA.local = kv.Value;

                string json = JsonConvert.SerializeObject(previsaoIPMA);

                string jsnopath = $"./output{kv.Key}-detalhe.json";
                
                //Altera o nome do ficheiro inicial
                File.WriteAllText(jsnopath + "-detalhe.json", json);

                // Converte para xml os ficheiros de previsao
                XmlDocument xml = JsonConvert.DeserializeXmlNode(json, "main");
                xml.Save(kv.Key + "--detalhe.xml");

                
            }Console.WriteLine("Operação efetuada com sucesso");
        }
    }
}

