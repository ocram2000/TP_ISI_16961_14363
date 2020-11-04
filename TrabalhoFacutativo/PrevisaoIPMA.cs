/*
*	<copyright file="PrevisaoDia.cs" company="IPCA">
*		Copyright (c) 2020 All Rights Reserved
*	</copyright>
* 	<author>Oscar Ribeiro</author>
*   <date></date>
*	<description></description>
**/

using System;

namespace TP_EX_1_2
{
    /// <summary>
    /// Classe Auxiliar
    /// </summary>
    class PrevisaoIPMA
    {
            public string owner { get; set; }
            public string country { get; set; }
            public PrevisaoDia[] data { get; set; }
            public int globalIdLocal { get; set; }
            public DateTime dataUpdate { get; set; }

          // ---- 
          public string local { get; set; }
    }

       
}

// copiar o conteúdo do ficheiro .Json, 
// e usar a opção Edit > Paste Special  > PAste JSON as classes

    /* 
public class rootobject
{
    public string owner { get; set; }
    public string country { get; set; }
    public datum[] data { get; set; }
    public int globalidlocal { get; set; }
    public datetime dataupdate { get; set; }
}

public class datum
{
    public string precipitaprob { get; set; }
    public string tmin { get; set; }
    public string tmax { get; set; }
    public string predwinddir { get; set; }
    public int idweathertype { get; set; }
    public int classwindspeed { get; set; }
    public string longitude { get; set; }
    public string forecastdate { get; set; }
    public int classprecint { get; set; }
    public string latitude { get; set; }
}
--------------------------------------  */


