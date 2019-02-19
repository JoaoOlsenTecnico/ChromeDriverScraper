using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        // Método que inicia os sites
        public static List<string> IniciarSites(ChromeDriver chromeDriver, string url, string nome, string preco, string ms)
        {
            // Acessa pagina da URL designada
            chromeDriver.Navigate().GoToUrl(url);
            // Pega os dados dentro da pagina
            var nomeProd = chromeDriver.FindElementByXPath(nome).Text;
            var precoProd = chromeDriver.FindElementByXPath(preco).Text;
            var msProd = chromeDriver.FindElementByXPath(ms).Text;
            var dados = new List<string>
            {
                nomeProd, precoProd, msProd
            };
            // Retorna lista com dados
            return dados;
        }
        // Lista URLs(Links) das paginas que serão acessadas
        public static List<string> ListaDeUrls()
        {
            // Definindo valor das URLs
            var urlDorflexComp_Onofre = "https://www.onofre.com.br/saude/medicamentos/analgesico/dorflex-36-comprimidos?utm_campaign=consultaremedio&utm_medium=comparadordepreco&utm_source=consultaremedio&utm_term=26532";
            var urlDorflexGotas_Onofre = "https://www.onofre.com.br/saude/medicamentos/analgesico/dorflex-gotas-com-20ml";
            var urlDorflexComp_Raia = "https://www.drogaraia.com.br/dorflex-analgesico-36-comprimidos.html?utm_content=6942&utm_medium=cpc&utm_source=comparador-consultaremedios.com.br";
            var urlDorflexGotas_Raia = "https://www.drogaraia.com.br/dorflex-solucao-gotas-20-ml.html";

            var urls = new List<string>
            {
                urlDorflexComp_Onofre, urlDorflexGotas_Onofre, urlDorflexComp_Raia, urlDorflexGotas_Raia
            };
            // Retorna lista com URLs
            return urls;
        }

        public static void AcessaLinks(ChromeDriver chromeDriver)
        {
            // Pega o método dos links e guarda em uma variavel
            var link = ListaDeUrls();
            // Pega o método com as regras e guarda em uma variavel
            var regrasOnofre = RegrasOnofre();
            var regraRaia = RegrasRaia();

            // Entra nas paginas com as configurações incrementadas
            var Dorflex_Comprimidos_Onofre = IniciarSites(chromeDriver, link[0], regrasOnofre[0], regrasOnofre[1], regrasOnofre[2]);
            var Dorflex_Gotas_Onofre = IniciarSites(chromeDriver, link[1], regrasOnofre[0], regrasOnofre[1], regrasOnofre[2]);
            var Dorflex_Comprimidos_Raia = IniciarSites(chromeDriver, link[2], regraRaia[0], regraRaia[1], regraRaia[2]);
            var Dorflex_Gotas_Raia = IniciarSites(chromeDriver, link[3], regraRaia[0], regraRaia[1], regraRaia[2]);
            //Relatorio no console
            Console.Write("\n ---- ONOFRE ----\n");
            for (var x = 0; x < Dorflex_Comprimidos_Onofre.Count; x++)
            {
                Console.Write(Dorflex_Comprimidos_Onofre[x] + "\n");
            }
            Console.Write(" ----------------- \n");
            for (var x = 0; x < Dorflex_Gotas_Onofre.Count; x++)
            {
                Console.Write(Dorflex_Gotas_Onofre[x] + "\n");
            }
            Console.Write(" ----------------- \n");
            Console.Write("\n ----- RAIA -----\n");
            for (var x = 0; x < Dorflex_Comprimidos_Raia.Count; x++)
            {
                Console.Write(Dorflex_Comprimidos_Raia[x] + "\n");
            }
            Console.Write(" ----------------- \n");

            for (var x = 0; x < Dorflex_Gotas_Raia.Count; x++)
            {
                Console.Write(Dorflex_Gotas_Raia[x] + "\n");
            }
            Console.Write(" ----------------- \n");
        }

        // Método que retorna lista com regras de busca da ONOFRE
        public static List<string> RegrasOnofre()
        {

            var nomeProd  = "//h1[@class='product-information__title']";
            var precProd = "//div[@class='price-box clearfix price-box--no-border']/div[@class='price-box__info' and 1]/h4[@class='price-box__actual' and 1]";
            var msProd    = "//div[@id='product-registration-code']";

            var regras = new List<string>
            {
                nomeProd, precProd, msProd
            };
            return regras; 
        }

        // Método que retorna lista com regras de busca da RAIA
        public static List<string> RegrasRaia()
        {

            var nomeProd  = "//h1/span[1]";
            var precoProd = "//p[@class='special-price']";
            var msProd    = "//tr[8]/td[@class='data last' and 1]";

            var regras = new List<string>
            {
                nomeProd, precoProd, msProd
            };
            return regras;
        }

        // Método principal
        static void Main()
        {
            // Define opções do driver de navegador
            var options = new ChromeOptions();
            // Adiciona argumento que remove corpo do navegador(Deixando apenas visual pelo console)
            options.AddArguments("--headless");
            // Inicia o navegador
            var chromeDriver = new ChromeDriver(options);

            // Inicia método que acessa as paginas
            AcessaLinks(chromeDriver);

            // Fecha o driver navegador
            chromeDriver.Close();

        }
    }
}
