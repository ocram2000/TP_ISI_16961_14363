/*
*	<copyright file="PrevisaoDia.cs" company="IPCA">
*		Copyright (c) 2020 All Rights Reserved
*	</copyright>
* 	<author>Oscar Ribeiro</author>
*   <date></date>
*	<description></description>
**/

namespace TP_EX_1_2
{
    /// <summary>
    /// Classe Auxiliar
    /// </summary>
    public class PrevisaoDia
        {
            public string precipitaProb { get; set; }
            public string tMin { get; set; }
            public string tMax { get; set; }
            public string predWindDir { get; set; }
            public int idWeatherType { get; set; }
            public int classWindSpeed { get; set; }
            public string longitude { get; set; }
            public string forecastDate { get; set; }
            public int classPrecInt { get; set; }
            public string latitude { get; set; }
        }
   
}
